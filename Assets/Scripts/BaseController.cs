using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class SpinVelocity
{
    public float velocity = 0f;
    public float Min = 0.05f;
    public float Max = 6f;
    public float DecayMultiplier = 1f;
    public SpinVelocity(float min,float max,float decay)
    {
        Min = min;
        Max = max;
        DecayMultiplier = decay;
    }
}
public class BaseController : MonoBehaviour {

	public static BaseController instance;
    public bool canSpin = true;
    public GameObject Cam,CamParent;

    private float yTouch = 100;

    public SpinVelocity VerticalSpin = new SpinVelocity(.005f,6f,1f);
    public SpinVelocity HorizontalSpin = new SpinVelocity(0, 6f, 1f);

    public GameObject textLine;

    public Vector2 startPos;
    public Vector2 direction;

   
 
   
    public RectTransform bottomMarker;
    
    bool moveDown = false;
    bool moveUp = false;
    public RectTransform data2;
    bool moveDownBat = false;
    bool moveUpBat = false;
    public RectTransform dataBat;
    

    
    private string hitTag;
    bool timer = false;
    float timerTime;
   

    public float speed =1;
    

    
    

   // public HighlightGroup_Group Exterior;



    public bool StopNextMotion = false;
    private Vector3 pMousePos = Vector3.zero;
    private Vector2 pDoubleTouchOffset = Vector2.zero;
    private float pastMagnitude = 0;
    private void Awake()
    {
        Cam = Camera.main.gameObject;
        CamParent = Cam.transform.parent.gameObject;
        instance = this.GetComponent<BaseController>();
        data2.anchoredPosition = bottomMarker.position;
        dataBat.anchoredPosition = bottomMarker.position;
    }
    // Update is called once per frame

    void UpdateRotation(Vector2 delta)
    {
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
    void UpdateZoom(float ChangeInMag)
    {
        Cam.transform.localPosition += new Vector3(0, 0, ChangeInMag/200f);
    
        
        //Clamp
        Vector3 pos = Cam.transform.localPosition;
        pos.z = Mathf.Clamp(pos.z, -15, -3);
         float y = .5f *((pos.z+3)/-12);

        pos.y = Mathf.Clamp(y,0,.5f);

        Cam.transform.localPosition = pos;
    }
    void UpdateZoomMouse(float ChangeInMag)
    {
        Cam.transform.localPosition += new Vector3(0, 0, ChangeInMag*5f);

        //Clamp
        Vector3 pos = Cam.transform.localPosition;
        pos.z = Mathf.Clamp(pos.z, -15, -3);

        float y = .5f *((pos.z+3)/-12);

        pos.y = Mathf.Clamp(y,0,.5f);
        Cam.transform.localPosition = pos;
    }
    void HandleDuelInput(float Magnitude)
    {
        Debug.Log(pastMagnitude);
        //if (pastMagnitude != 0)
      //  {
            if (pastMagnitude > 200){
            UpdateZoom(Magnitude - pastMagnitude);
        }else{
            Vector2 touchDeltapos = Input.GetTouch(0).deltaPosition;
                CamParent.transform.Translate(-touchDeltapos.x *speed, -touchDeltapos.y *speed,0);
        }
       // }
        pastMagnitude = Magnitude;




    }
    void MoveTextDown(RectTransform d,float t)
    {
        //data2.anchoredPosition = Vector3.Lerp(Vector3.zero,bottomMarker.position,t);
        d.anchoredPosition = Vector3.MoveTowards(d.anchoredPosition, bottomMarker.position,t * Time.deltaTime);


    }
    void MoveTextUp(RectTransform d,float t)
    {
        //data2.anchoredPosition = Vector3.Lerp(Vector3.zero,bottomMarker.position,t);
        d.anchoredPosition = Vector3.MoveTowards(d.anchoredPosition, Vector3.zero,t * Time.deltaTime);

        


    }
    void CheckMoveup(bool up, RectTransform d )
    {
       
            
    }
    
    

   	Vector2 pDelta = Vector2.zero;
    void Update () 
    {

        if(CamParent.transform.position.x > 2)
        {
            CamParent.transform.Translate(-20 *Time.deltaTime, 0,0);

        }
        if(CamParent.transform.position.x < -2)
        {
            CamParent.transform.Translate(20 *Time.deltaTime, 0,0);

        }
        if(CamParent.transform.position.y > 2)
        {
            CamParent.transform.Translate(0, -20 *Time.deltaTime,0);

        }
        if(CamParent.transform.position.y < -2)
        {
           CamParent.transform.Translate(0, 20 * Time.deltaTime,0);
        }
        
      



        if (moveDown && data2.anchoredPosition.y >= bottomMarker.position.y)
        {
            MoveTextDown(data2,1000);
            if(data2.anchoredPosition.y <= bottomMarker.position.y)
           moveDown = false;

        }
         if (moveUp && data2.anchoredPosition.y <= Vector3.zero.y)
        {
            MoveTextUp(data2,1000);
            if(data2.anchoredPosition.y >= Vector3.zero.y)
           moveUp = false;

        }
         if (moveDownBat && dataBat.anchoredPosition.y >= bottomMarker.position.y)
        {
            MoveTextDown(dataBat,1000);
            if(dataBat.anchoredPosition.y <= bottomMarker.position.y)
           moveDownBat = false;

        }
         if (moveUpBat && dataBat.anchoredPosition.y <= Vector3.zero.y)
        {
            MoveTextUp(dataBat,1000);
            if(dataBat.anchoredPosition.y >= Vector3.zero.y)
           moveUpBat = false;

        }
                    
        
      //  Debug.Log(moveDownasdasdadasdasd);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.touchCount > 0 && canSpin && !StopNextMotion)//Real Touch Inputs
        {
             Touch touch = Input.GetTouch(0);


            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                   
                    startPos = touch.position;
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    timer = true;
                    if (Physics.Raycast(ray,out hit))
                    {

                        if(hit.collider != null)
                        {

                            hitTag = hit.collider.tag;
                           

                        }
                        
                    }
                    
                   
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                   
                   
                    
                    break;

                case TouchPhase.Ended:
                     // Record initial touch position.
                    
                    RaycastHit hitEnd;
                    Ray rayEnd = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(rayEnd,out hitEnd))
                    {

                        if(timerTime <= .15f)
                        {
                        if(hitEnd.collider != null)
                        {

                           
                            if (hitTag == "batt" && hitEnd.collider.tag == hitTag)
                            {
                                moveUpBat = true;
                                moveDownBat = false;
                                 moveUp = false;
                                moveDown = true;
                            }
                            
                            if (hitTag == "case" && hitEnd.collider.tag == hitTag)
                            {


                               moveUp = true;
                                moveDown = false;
                                moveUpBat = false;
                                moveDownBat = true;
                            }

                            if(hitTag == "background" && hitEnd.collider.tag == "background")
                            {
                                 moveUp = false;
                                moveDown = true;
                                moveUpBat = false;
                                moveDownBat = true;
                            }

                        }
                        }
                        
                    }
                    
                      timer = false;
                    break;

            }
            if(timer)
            {
                timerTime+= Time.deltaTime;
                //Debug.Log(timerTime);

            }else
            {
                timerTime = 0;
            }

        if(startPos.y > textLine.transform.position.y)
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
                	UpdateRotation(touchDelta);
                else if(touchDelta != Vector2.zero)
                	UpdateRotation(touchDelta);
                	

                pDelta=touchDelta;
                pDoubleTouchOffset = Vector2.zero;
                pastMagnitude = 0;
            }
        }
        
    }
        else if (Input.GetMouseButton(0) && canSpin && !StopNextMotion)
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
           // Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            if(Input.touchCount <= 0)
                UpdateZoomMouse(offset);

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
            if (StopNextMotion)
                StopNextMotion = false;

            if (HorizontalSpin.velocity > HorizontalSpin.Min)
            {
                HorizontalSpin.velocity -= Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier;
                if (HorizontalSpin.velocity < HorizontalSpin.Min)
                    HorizontalSpin.velocity = HorizontalSpin.Min;
            }
            else if (HorizontalSpin.velocity < -HorizontalSpin.Min)
            {
                HorizontalSpin.velocity += Time.fixedDeltaTime * HorizontalSpin.DecayMultiplier;
                if (HorizontalSpin.velocity > -HorizontalSpin.Min)
                    HorizontalSpin.velocity = -HorizontalSpin.Min;
            }





            this.transform.localEulerAngles -= new Vector3(0, HorizontalSpin.velocity, 0);



            if (VerticalSpin.velocity > 0)
            {
                VerticalSpin.velocity -= Time.fixedDeltaTime * VerticalSpin.DecayMultiplier;
                if (VerticalSpin.velocity < 0)
                    VerticalSpin.velocity = 0;
            }
            else if (VerticalSpin.velocity < 0)
            {
                VerticalSpin.velocity += Time.fixedDeltaTime * VerticalSpin.DecayMultiplier;
                if (VerticalSpin.velocity > 0)
                    VerticalSpin.velocity = 0;
            }
            
            CamParent.transform.eulerAngles += Vector3.right * VerticalSpin.velocity;
            ClampCameraAngles();

        }
    }

    void ClampCameraAngles()
    {
        float rot = CamParent.transform.eulerAngles.x;
        if (rot>0 && rot<180)
         CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 90), 0, 0);
        else if (rot >180)
            CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 270,360), 0, 0);
     

    }


}
