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
    public GameObject textLine2;
    public GameObject textLine3;
    public GameObject textLine4;
    public GameObject textLine5;
    public GameObject textLine6;
    public GameObject textLine7;
    public GameObject textLine8;
    public GameObject textLine9;
    public GameObject textLine10;
    public GameObject textLine11;
    public GameObject textLine12;
    public GameObject textLine13;
    public GameObject textLine14;

    public Vector2 startPos;
    public Vector2 direction;

   
 int state = 0;
   
    public RectTransform bottomMarker;
    
    bool moveDown = false;
    bool moveUp = false;
    public RectTransform Adhesivebonding;
    public RectTransform Coversealing;
    public RectTransform HVconnectorsystem;
    public RectTransform LVconnector;
    public RectTransform FluidConnectors;
    public RectTransform Structuralbonding;
    public RectTransform ModuleEndPlates;
    public RectTransform InnovativeDesignforHybridCoolingPlate;
    public RectTransform ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules;
    public RectTransform PlasticCellHolders;
    public RectTransform BatteryCelltoPackStructuralBonding;
    public RectTransform PrismaticCellBonding;
    public RectTransform Celltocellinsulation;
    public RectTransform ImmersionCooling;
    //bool moveDownBat = false;
    //bool moveUpBat = false;
   
    public Material caseMat;
    bool caseMatFade = false;
    float caseMatFloat = 0;

    
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

        /*

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
        */

        switch(state)
        {
            case 0:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
             
                 if (caseMatFloat>0){
                 caseMat.SetFloat("Vector1_824EC8D0",caseMatFloat -=Time.deltaTime);
                 
                 }else{
                     caseMatFloat = 0;
                 }
             
            break;

            case 1:
            MoveTextUp(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
            MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);   
             if (caseMatFloat<1){
                 caseMat.SetFloat("Vector1_824EC8D0",caseMatFloat +=Time.deltaTime);
                 
                 }else{
                     caseMatFloat = 1;
                 }         
            break;

            case 2:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextUp(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 3:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextUp(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 4:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextUp(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 5:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextUp(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 6:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextUp(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 7:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextUp(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 8:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextUp(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 9:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextUp(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 10:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextUp(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 11:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextUp(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 12:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextUp(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 13:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextUp(Celltocellinsulation,1000);
             MoveTextDown(ImmersionCooling,1000);
            break;

            case 14:
            MoveTextDown(Adhesivebonding,1000);
            MoveTextDown(Coversealing,1000);
            MoveTextDown(HVconnectorsystem,1000);
           MoveTextDown(LVconnector,1000);
            MoveTextDown(FluidConnectors,1000);
             MoveTextDown(Structuralbonding,1000);
             MoveTextDown(ModuleEndPlates,1000);
             MoveTextDown(InnovativeDesignforHybridCoolingPlate,1000);
             MoveTextDown(ThermalConductiveInterfaceBetweenCoolingPlateandBatteryModules,1000);
             MoveTextDown(PlasticCellHolders,1000);
             MoveTextDown(BatteryCelltoPackStructuralBonding,1000);
             MoveTextDown(PrismaticCellBonding,1000);
             MoveTextDown(Celltocellinsulation,1000);
             MoveTextUp(ImmersionCooling,1000);
            break;


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
                            Debug.Log(hitTag);                        

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

                                if(startPos.y > textLine.transform.position.y && startPos.y > textLine2.transform.position.y&& startPos.y > textLine3.transform.position.y&& startPos.y > textLine4.transform.position.y&& startPos.y > textLine5.transform.position.y&& startPos.y > textLine6.transform.position.y&& startPos.y > textLine7.transform.position.y&& startPos.y > textLine8.transform.position.y&& startPos.y > textLine9.transform.position.y&& startPos.y > textLine10.transform.position.y&& startPos.y > textLine11.transform.position.y&& startPos.y > textLine12.transform.position.y&& startPos.y > textLine13.transform.position.y&& startPos.y > textLine14.transform.position.y )
        {
                             if(hitTag == "background" && hitEnd.collider.tag == "background")
                            {
                                state = 0;  
                                 //todo fade everything in                            
                            } 
        }
                            if (hitTag == "Betamate Adhesive Bonding" && hitEnd.collider.tag == hitTag)
                            {
                              state = 1;
                              //todo fade everything but this
                            }
                            if (hitTag == "Cover Sealing" && hitEnd.collider.tag == hitTag)
                            {
                               state = 2;
                                //todo fade everything but this
                            }
                            if (hitTag == "HV Connector System" && hitEnd.collider.tag == hitTag)
                            {
                               state = 3;
                                //todo fade everything but this
                            }
                             if (hitTag == "LV Connector" && hitEnd.collider.tag == hitTag)
                            {
                               state = 4;
                                //todo fade everything but this
                            }
                             if (hitTag == "Fluid Connectors" && hitEnd.collider.tag == hitTag)
                            {
                               state = 5;
                                //todo fade everything but this
                            }
                             if (hitTag == "Structural bonding" && hitEnd.collider.tag == hitTag)
                            {
                               state = 6;
                                //todo fade everything but this
                            }

                            if (hitTag == "Module End Plates" && hitEnd.collider.tag == hitTag)
                            {
                               state = 7;
                                //todo fade everything but this
                            }

                            if (hitTag == "Innovative Design for Hybrid Cooling Plate" && hitEnd.collider.tag == hitTag)
                            {
                               state = 8;
                                //todo fade everything but this
                            }

                            if (hitTag == "Thermal Conductive Interface" && hitEnd.collider.tag == hitTag)
                            {
                               state = 9;
                                //todo fade everything but this
                            }

                            if (hitTag == "Plastic Cell Holders" && hitEnd.collider.tag == hitTag)
                            {
                               state = 10;
                                //todo fade everything but this
                            }

                            if (hitTag == "Battery Cell to Pack Structural Bonding" && hitEnd.collider.tag == hitTag)
                            {
                               state = 11;
                                //todo fade everything but this
                            }

                            if (hitTag == "Prismatic Cell Bonding" && hitEnd.collider.tag == hitTag)
                            {
                               state = 12;
                                //todo fade everything but this
                            }

                            if (hitTag == "Cell to cell insulation" && hitEnd.collider.tag == hitTag)
                            {
                               state = 13;
                                //todo fade everything but this
                            }

                            if (hitTag == "Immersion Cooling" && hitEnd.collider.tag == hitTag)
                            {
                               state = 14;
                                //todo fade everything but this
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

        if(startPos.y > textLine.transform.position.y && startPos.y > textLine2.transform.position.y&& startPos.y > textLine3.transform.position.y&& startPos.y > textLine4.transform.position.y&& startPos.y > textLine5.transform.position.y&& startPos.y > textLine6.transform.position.y&& startPos.y > textLine7.transform.position.y&& startPos.y > textLine8.transform.position.y&& startPos.y > textLine9.transform.position.y&& startPos.y > textLine10.transform.position.y&& startPos.y > textLine11.transform.position.y&& startPos.y > textLine12.transform.position.y&& startPos.y > textLine13.transform.position.y&& startPos.y > textLine14.transform.position.y )
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

    void ClampCameraAngles()
    {
        float rot = CamParent.transform.eulerAngles.x;
        if (rot>0 && rot<180)
         CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 90), 0, 0);
        else if (rot >180)
            CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 270,360), 0, 0);
     

    }


}
