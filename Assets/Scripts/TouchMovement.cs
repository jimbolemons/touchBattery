using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class basicSpinVelocity
{
    public float velocity = 0f;
    public float Min = 0.05f;
    public float Max = 6f;
    public float DecayMultiplier = 1f;
    public basicSpinVelocity(float min,float max,float decay)
    {
        Min = min;
        Max = max;
        DecayMultiplier = decay;
    }
}
public class TouchMovement : MonoBehaviour
{

public bool canZoom = true;
public bool canBeMoved = true;
public static BaseController instance;
public bool canSpin = true;
GameObject Cam,CamParent;
public basicSpinVelocity VerticalSpin = new basicSpinVelocity(.005f,6f,1f);
public basicSpinVelocity HorizontalSpin = new basicSpinVelocity(0, 6f, 1f);
float minFloat = -3;
float maxFloat = -10;
private string hitTag;
public float speed =0.0009f;
Vector2 pDelta = Vector2.zero;

private Vector3 pMousePos = Vector3.zero;
private Vector2 pDoubleTouchOffset = Vector2.zero;
private float pastMagnitude = 0;    

private void Awake()
    {
        Cam = Camera.main.gameObject;
        CamParent = Cam.transform.parent.gameObject;
        instance = this.GetComponent<BaseController>();        
    }
    

void UpdateRotation(Vector2 delta)
    {
        if(canSpin){
        //if (delta == Vector2.zero)
            //return;
        float xDelta = delta.x / 4f;
        float yDelta = -delta.y / 10f;

        this.transform.localEulerAngles +=  Vector3.up * -xDelta;
        HorizontalSpin.velocity = Mathf.Clamp(xDelta, -HorizontalSpin.Max, HorizontalSpin.Max);
       // Debug.Log(xDelta);
        float rotX = CamParent.transform.eulerAngles.x;
        if ((rotX<180 && rotX +yDelta <90)||(rotX >180 && rotX +yDelta > 270) )
        {
            CamParent.transform.eulerAngles += Vector3.right * yDelta;
            VerticalSpin.velocity = Mathf.Clamp(yDelta, -VerticalSpin.Max, VerticalSpin.Max);
        }
        ClampCameraAngles();
        }
    }
void UpdateZoom(float ChangeInMag)
    {
        Cam.transform.localPosition += new Vector3(0, 0, ChangeInMag/200f);

        //Clamp
        Vector3 pos = Cam.transform.localPosition;
        pos.z = Mathf.Clamp(pos.z, maxFloat, minFloat);
         float y = .5f *((pos.z+3)/-12);

       // pos.y = Mathf.Clamp(y,0,.5f);

        Cam.transform.localPosition = pos;
    }
    
void HandleDuelInput(float Magnitude)
    {
        //Debug.Log(pastMagnitude);
        //if (pastMagnitude != 0)
      //  {
            if (pastMagnitude > 200){
                if(canZoom)
                    UpdateZoom(Magnitude - pastMagnitude);
        }else{
            Vector2 touchDeltapos = Input.GetTouch(0).deltaPosition;
                if(canBeMoved)
                CamParent.transform.Translate(-touchDeltapos.x *speed, -touchDeltapos.y *speed,0);
        }
       // }
        pastMagnitude = Magnitude;

    }
void ClampCameraAngles()
    {
        float rot = CamParent.transform.eulerAngles.x;
        if (rot>0 && rot<180)
         CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 50), 0, 0);
         //CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 90), 0, 0); for full up
        else if (rot >180)
            CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 310,360), 0, 0);
            //CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 270,360), 0, 0); for full down
    }

void Update() {

    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
         
    if(CamParent.transform.position.x > 2)
        {
            CamParent.transform.Translate(-3 *Time.deltaTime, 0,0);

        }
    if(CamParent.transform.position.x < -2)
        {
            CamParent.transform.Translate(3 *Time.deltaTime, 0,0);

        }
    if(CamParent.transform.position.y > 2)
        {
            CamParent.transform.Translate(0, -3 *Time.deltaTime,0);

        }
    if(CamParent.transform.position.y < -2)
        {
           CamParent.transform.Translate(0, 3 * Time.deltaTime,0);
        }
         
 
    if (Input.touchCount > 0  )//Real Touch Inputs
        {                    
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
            //Debug.Log(Input.GetTouch(0).position);
            if (Input.touchCount > 1)
            {
                Vector2 currentoffset = Input.GetTouch(0).position - Input.GetTouch(1).position;
                float mag = currentoffset.magnitude;
                HandleDuelInput(mag);
            } 
            else 
            {                
            	//Debug.Log("in  " + touchDelta);
            	if(pDelta == Vector2.zero && touchDelta == Vector2.zero)
                	UpdateRotation(touchDelta/5);
                else if(touchDelta != Vector2.zero)
                	UpdateRotation(touchDelta/5);
                    pDelta=touchDelta;
                pDoubleTouchOffset = Vector2.zero;
                pastMagnitude = 0;
            }
        
        
    }
        else if (Input.GetMouseButton(0)  )
        {
            if (pMousePos == Vector3.zero)
            {
                pMousePos = Input.mousePosition;
                return;
            }
            Vector3 delta = Input.mousePosition - pMousePos;
            pDoubleTouchOffset = Vector2.zero;
            UpdateRotation(delta);       

             pMousePos = Input.mousePosition;
        }
        else
        {
            float offset = Input.GetAxis("Mouse ScrollWheel");
         
            if(Input.touchCount <= 0)
               

            if(Input.GetKey(KeyCode.LeftControl))
            {
                if(pMousePos != Vector3.zero)
                {
                    Vector3 delta = Input.mousePosition - pMousePos;
                    UpdateZoom(delta.x*10f);
                }
                pMousePos = Input.mousePosition;                
            } 
            else
            {
                pMousePos = Vector3.zero;
            }
            pDoubleTouchOffset = Vector2.zero;
            pDelta =  Vector2.zero;            

           // if (HorizontalSpin.velocity > HorizontalSpin.Min)
            //{
            //    HorizontalSpin.velocity -= Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier *5;
            //    if (HorizontalSpin.velocity < HorizontalSpin.Min)
            //        HorizontalSpin.velocity = HorizontalSpin.Min;
           // }
            //else if (HorizontalSpin.velocity < -HorizontalSpin.Min)
            //{
               // HorizontalSpin.velocity += Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier*5;
               // if (HorizontalSpin.velocity > -HorizontalSpin.Min)
               //     HorizontalSpin.velocity = -HorizontalSpin.Min;
            //}

            //this.transform.localEulerAngles -= new Vector3(0, HorizontalSpin.velocity, 0);



            

 if (HorizontalSpin.velocity > 0)
            {
                HorizontalSpin.velocity -= Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier;
                if (HorizontalSpin.velocity < 0)
                    HorizontalSpin.velocity = 0;
            }
            else if (HorizontalSpin.velocity < 0)
            {
                HorizontalSpin.velocity += Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier;
                if (HorizontalSpin.velocity > 0)
                    HorizontalSpin.velocity = 0;
            }
        this.transform.localEulerAngles -= (Vector3.up * HorizontalSpin.velocity/2)/10;

            if (VerticalSpin.velocity > 0)
            {
                VerticalSpin.velocity -= Time.fixedDeltaTime * VerticalSpin.DecayMultiplier /10;
                if (VerticalSpin.velocity < 0)
                    VerticalSpin.velocity = 0;
            }
            else if (VerticalSpin.velocity < 0)
            {
                VerticalSpin.velocity += Time.fixedDeltaTime * VerticalSpin.DecayMultiplier;
                if (VerticalSpin.velocity > 0)
                    VerticalSpin.velocity = 0;
            }
            
            CamParent.transform.eulerAngles += (Vector3.right * VerticalSpin.velocity/2)/10 ;
            ClampCameraAngles();

        }
    }
}
