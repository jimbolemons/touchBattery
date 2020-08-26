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
    GameObject Cam,CamParent;

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
    public GameObject batteryModel;

   
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
    public RectTransform CoolingLines;
   
   
    
    public Material basicREd;
    public Material blackAd;
    public Material blackPlas;
    public Material boxShapeBlack;
    public Material boxShapeMetalic;
    public Material boxShapeRed;
    public Material boxShapeWhite;
    public Material cutShader;
    public Material devider;
    public Material deviderSwerly;
    public Material dupontlogo;
    public Material genaricBlurry1;
    public Material genaricBlurry;
    public Material genaricfasteners;
    public Material mint;
    public Material nomax;
    public Material orange;
    public Material outside;
    public Material tesla;
    public Material whiteplastic;
    public Material yellow;
    public Material metal1;
    public Material ruber2;
    public Material metal3;
    public Material plastic4;
    public Material plastic5;
    public Material metal7;
    public Material plastic7;
    public Material wplastic7;
    public Material metal8;
    public Material plastic8;
    public Material black9;
    public Material red9;
    public Material white9;
    public Material metal9;
    public Material plastic9;
    public Material metal10;
    public Material plastic10;
    public Material wplastic10;
    public Material black11;
    public Material white11;
    public Material red11;
    public Material metal11;
    public Material plastic11;
    public Material black12;
    public Material white12;
    public Material red12;
    public Material metal12;
    public Material plastic12;
    public Material black13;
    public Material white13;
    public Material red13;
    public Material plastic13;
    public Material metal13;
    public Material metal14;
    public Material plastic14;
    public Material rubber15;
    public Material metal1Red;
    public Material plastic11Red;
    public Material plastic12Red;
    public Material plastic13Red;
    public Material plastic6Red;







    float basicREdFloat;
    float blackAdFloat;
    float blackPlasFloat;
    float boxShapeBlackFloat;
    float boxShapeMetalicFloat;
    float boxShapeRedFloat;
    float boxShapeWhiteFloat;
    float cutShaderFloat;
    float deviderFloat;
    float deviderSwerlyFloat;
    float dupontlogoFloat;
    float genaricBlurry1Float;
    float genaricBlurryFloat;
    float genaricfastenersFloat;
    float mintFloat;
    float nomaxFloat;
    float orangeFloat;
    float outsideFloat;
    float teslaFloat;
    float whiteplasticFloat;
    float yellowFloat;
    float metal1Float;
    float ruber2Float;
    float metal3Float;
    float plastic4Float;
    float plastic5Float;
    float metal7Float;
    float plastic7Float;
    float wplastic7Float;
    float metal8Float;
    float plastic8Float;
    float black9Float;
    float red9Float;
    float white9Float;
    float metal9Float;
    float plastic9Float;
    float metal10Float;
    float plastic10Float;
    float wplastic10Float;
    float black11Float;
    float white11Float;
    float red11Float;
    float metal11Float;
    float plastic11Float;
    float black12Float;
    float white12Float;
    float red12Float;
    float metal12Float;
    float plastic12Float;
    float black13Float;
    float white13Float;
    float red13Float;
    float plastic13Float;
    float metal13Float;
    float metal14Float;
    float plastic14Float;
    float rubber15Float;



    bool switchZoom = false;

 float minFloat = -3;
 float maxFloat = -10;


    
    float basicRedFloat = 0;

    
    private string hitTag;
    bool timer = false;
    float timerTime;
   

    public float speed =1;
    

    
    





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
        pos.z = Mathf.Clamp(pos.z, maxFloat, minFloat);
         float y = .5f *((pos.z+3)/-12);

       // pos.y = Mathf.Clamp(y,0,.5f);

        Cam.transform.localPosition = pos;
    }
    /*void UpdateZoomMouse(float ChangeInMag)
    {
        Cam.transform.localPosition += new Vector3(0, 0, ChangeInMag*5f);

        //Clamp
        Vector3 pos = Cam.transform.localPosition;
        pos.z = Mathf.Clamp(pos.z, -15, -3);

        float y = .5f *((pos.z+3)/-12);

        pos.y = Mathf.Clamp(y,0,.5f);
        Cam.transform.localPosition = pos;
    }
    */
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

      

        switch(state)
        {            
            case 0:
            minFloat = -5f;
            maxFloat = -10f;
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
             MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,.1f,0),4 *Time.deltaTime);
            
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-10),2f*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
               
                  if (Cam.transform.localPosition.z < -9.5 && Cam.transform.localPosition.z > -10.5)
                  {
                      switchZoom = false;
                  }
             }
                 if (basicRedFloat>0){
                 basicRedFloat -=Time.deltaTime;                 
                 }else{
                     basicRedFloat = 0;
                 }
                if (plastic11Red.GetFloat("Vector1_BBEE40D8") != 0)
                 {
                        plastic11Red.SetFloat("Vector1_BBEE40D8",0);
                 }
                 if (metal1Red.GetFloat("Vector1_BBEE40D8") != 0)
                 {
                        metal1Red.SetFloat("Vector1_BBEE40D8",0);
                 }
                 if (plastic12Red.GetFloat("Vector1_BBEE40D8") != 0)
                 {
                        plastic12Red.SetFloat("Vector1_BBEE40D8",0);
                 }
                 if (plastic13Red.GetFloat("Vector1_BBEE40D8") != 0)
                 {
                        plastic13Red.SetFloat("Vector1_BBEE40D8",0);
                 }
                  if (plastic6Red.GetFloat("Vector1_BBEE40D8") != 0)
                 {
                        plastic6Red.SetFloat("Vector1_BBEE40D8",0);
                 }
                
                
                
                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                metal1Red.SetFloat("Vector1_824EC8D0",1);
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);


                 
               


                 

                //todo pull camera back to look at whole object

             
            break;

            case 1:
            //HERE
            minFloat = -5f;
            maxFloat = -10f;
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,1.5f,0),4 *Time.deltaTime);
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-10),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  //Cam.transform.localPosition = Vector3.MoveTowards(Cam.transform.localPosition,new Vector3(0,0,-10),12.8f*Time.deltaTime);
                  //CamParent.transform.position = Vector3.MoveTowards(CamParent.transform.position,Vector3.zero,5*Time.deltaTime);
                  if (Cam.transform.localPosition.z < -9.5 && Cam.transform.localPosition.z > -10.5)
                  {
                      switchZoom = false;
                  }
             }
             if(!switchZoom)
             {
                 float y = metal1Red.GetFloat("Vector1_BBEE40D8");
                 if (metal1Red.GetFloat("Vector1_BBEE40D8") > 1)
                 {

                 }else{
                     y += Time.deltaTime;
                 }                
                metal1Red.SetFloat("Vector1_BBEE40D8",y);
                metal1Red.SetFloat("Vector1_824EC8D0",-y);

             }
            if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 

            if (metal1Float>0)
             {
                 metal1Float -= Time.deltaTime;
             }else{
                 metal1Float = 0;
             }

                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                //metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                 
                

            break;

            case 2:
            minFloat = -5f;
            maxFloat = -10f;
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,1.5f,0),4 *Time.deltaTime);
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-10),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z < -9.5 && Cam.transform.localPosition.z > -10.5)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                 if (ruber2Float>0)
             {
                 ruber2Float -= Time.deltaTime;
             }else{
                 ruber2Float = 0;
             }

                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                //ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
            break;

            case 3:
            minFloat = -1f;
            maxFloat = -3f;
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
              MoveTextDown(CoolingLines,1000);      
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1.41f,.2f,-2.7f),4*Time.deltaTime);
             if (switchZoom){                
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-1),2*Time.deltaTime);                
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -1.5 && Cam.transform.localPosition.z < -1)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 

                  if (metal3Float>0)
             {
                 metal3Float -= Time.deltaTime;
             }else{
                 metal3Float = 0;
             }
              if (orangeFloat>0)
             {
                 orangeFloat -= Time.deltaTime;
             }else{
                 orangeFloat = 0;
             }
              if (yellowFloat>0)
             {
                 yellowFloat -= Time.deltaTime;
             }else{
                 yellowFloat = 0;
             }
                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                //orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
               // yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
               // metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
               
            break;

            case 4:
            minFloat = -1f;
            maxFloat = -3f;
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(.915f,.1f,-2.72f),4 *Time.deltaTime);
              if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-1),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -1.5 && Cam.transform.localPosition.z < -1)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                  if (plastic4Float>0)
             {
                 plastic4Float -= Time.deltaTime;
             }else{
                 plastic4Float = 0;
             }

                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                //plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
              
            break;

            case 5:
            minFloat = -1f;
            maxFloat = -3f;
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,.3f,-2.75f),4 *Time.deltaTime);
            
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-1),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -1.5 && Cam.transform.localPosition.z < -1)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                  
               if (plastic5Float>0)
             {
                 plastic5Float -= Time.deltaTime;
             }else{
                 plastic5Float = 0;
             }


blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                //plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
            break;

            case 6:
            minFloat = -5f;
            maxFloat = -10f;
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,1.5f,0),4 *Time.deltaTime);
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-10),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z < -9.5 && Cam.transform.localPosition.z > -10.5)
                  {
                      switchZoom = false;
                  }
             }
             if(!switchZoom)
             {
                 float y = plastic6Red.GetFloat("Vector1_BBEE40D8");
                 if (plastic6Red.GetFloat("Vector1_BBEE40D8") > 1)
                 {

                 }else{
                     y += Time.deltaTime;
                 }                
                plastic6Red.SetFloat("Vector1_BBEE40D8",y);
                plastic6Red.SetFloat("Vector1_824EC8D0",-y);

             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
             if (dupontlogoFloat>0)
             {
                 dupontlogoFloat -= Time.deltaTime;
             }else{
                 dupontlogoFloat = 0;
             }
            if (outsideFloat>0)
             {
                 outsideFloat -= Time.deltaTime;
             }else{
                 outsideFloat = 0;
             }


                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
               // dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
               // outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
               // plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
               
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,1.47f),4 *Time.deltaTime);
             minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             
                if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                  if (metal14Float>0)
             {
                 metal14Float -= Time.deltaTime;
             }else{
                 metal14Float = 0;
             }
               if (plastic14Float>0)
             {
                 plastic14Float -= Time.deltaTime;
             }else{
                 plastic14Float = 0;
             }

                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
               // metal14Float = basicRedFloat;
                //plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
               
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(-1,.5f,-1.1f),4 *Time.deltaTime);
            minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                  if (metal8Float>0)
             {
                 metal8Float -= Time.deltaTime;
             }else{
                 metal8Float = 0;
             }
              if (plastic8Float>0)
             {
                 plastic8Float -= Time.deltaTime;
             }else{
                 plastic8Float = 0;
             }

                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
               // metal8Float = basicRedFloat;
               // plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
               
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(-1,.5f,1.12f),4 *Time.deltaTime);
             minFloat = -2f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 

                 if (black9Float>0)
             {
                 black9Float -= Time.deltaTime;
             }else{
                 black9Float = 0;
             }
             if (metal9Float>0)
             {
                 metal9Float -= Time.deltaTime;
             }else{
                 metal9Float = 0;
             }
             if (plastic9Float>0)
             {
                 plastic9Float -= Time.deltaTime;
             }else{
                 plastic9Float = 0;
             }
             if (red9Float>0)
             {
                 red9Float -= Time.deltaTime;
             }else{
                 red9Float = 0;
             }
             if (white9Float>0)
             {
                 white9Float -= Time.deltaTime;
             }else{
                 white9Float = 0;
             }
             if (mintFloat>0)
             {
                 mintFloat -= Time.deltaTime;
             }else{
                 mintFloat = 0;
             }

                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                //mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
               // black9Float = basicRedFloat;
               // red9Float = basicRedFloat;
               // white9Float = basicRedFloat;
                //metal9Float = basicRedFloat;
               // plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,-1.5f),4 *Time.deltaTime);
             minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 

                 if (metal10Float>0)
             {
                 metal10Float -= Time.deltaTime;
             }else{
                 metal10Float = 0;
             }
                if (plastic10Float>0)
             {
                 plastic10Float -= Time.deltaTime;
             }else{
                 plastic10Float = 0;
             }
                if (wplastic10Float>0)
             {
                 wplastic10Float -= Time.deltaTime;
             }else{
                 wplastic10Float = 0;
             }
                if (teslaFloat>0)
             {
                 teslaFloat -= Time.deltaTime;
             }else{
                 teslaFloat = 0;
             }


                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                //teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                //metal10Float = basicRedFloat;
                //plastic10Float = basicRedFloat;
                //wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
            break;

            case 11:
            //HERE
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,-.77f),4 *Time.deltaTime);
            minFloat = -1.5f;
            maxFloat =-3f;
            
             if (switchZoom){
                
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             if(!switchZoom)
             {
                 float y = plastic11Red.GetFloat("Vector1_BBEE40D8");
                 if (plastic11Red.GetFloat("Vector1_BBEE40D8") > 1)
                 {

                 }else{
                     y += Time.deltaTime;
                 }                
                plastic11Red.SetFloat("Vector1_BBEE40D8",y);
                plastic11Red.SetFloat("Vector1_824EC8D0",-y);

             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                   if (black11Float>0)
             {
                 black11Float -= Time.deltaTime;
             }else{
                 black11Float = 0;
             }
               if (metal11Float>0)
             {
                 metal11Float -= Time.deltaTime;
             }else{
                 metal11Float = 0;
             }
               if (plastic11Float>0)
             {
                 plastic11Float -= Time.deltaTime;
             }else{
                 plastic11Float = 0;
             }
               if (red11Float>0)
             {
                 red11Float -= Time.deltaTime;
             }else{
                 red11Float = 0;
             }
               if (white11Float>0)
             {
                 white11Float -= Time.deltaTime;
             }else{
                 white11Float = 0;
             }
             if(plastic11Red.GetFloat("Vector1_824EC8D0")>0){
                 float y = plastic11Red.GetFloat("Vector1_824EC8D0");
                 y -= Time.deltaTime;
             plastic11Red.SetFloat("Vector1_824EC8D0",y);
             }else{
                 plastic11Red.SetFloat("Vector1_824EC8D0",0);
             }

                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
               // black11Float = basicRedFloat;
               // white11Float = basicRedFloat;
               // red11Float = basicRedFloat;
               // metal11Float = basicRedFloat;
               // plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
               // plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
               
            break;

            case 12:
            //HERE
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,0f),4 *Time.deltaTime);
             minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
              if(!switchZoom)
             {
                 float y = plastic12Red.GetFloat("Vector1_BBEE40D8");
                 if (plastic12Red.GetFloat("Vector1_BBEE40D8") > 1)
                 {

                 }else{
                     y += Time.deltaTime;
                 }                
                plastic12Red.SetFloat("Vector1_BBEE40D8",y);
                plastic12Red.SetFloat("Vector1_824EC8D0",-y);

             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                   if (black12Float>0)
             {
                 black12Float -= Time.deltaTime;
             }else{
                 black12Float = 0;
             }
               if (metal12Float>0)
             {
                 metal12Float -= Time.deltaTime;
             }else{
                 metal12Float = 0;
             }
               if (plastic12Float>0)
             {
                 plastic12Float -= Time.deltaTime;
             }else{
                 plastic12Float = 0;
             }
               if (red12Float>0)
             {
                 red12Float -= Time.deltaTime;
             }else{
                 red12Float = 0;
             }
               if (white12Float>0)
             {
                 white12Float -= Time.deltaTime;
             }else{
                 white12Float = 0;
             }
              if(plastic12Red.GetFloat("Vector1_824EC8D0")>0){
                 float y = plastic12Red.GetFloat("Vector1_824EC8D0");
                 y -= Time.deltaTime;
             plastic12Red.SetFloat("Vector1_824EC8D0",y);
             }else{
                 plastic12Red.SetFloat("Vector1_824EC8D0",0);
             }

                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
               // black12Float = basicRedFloat;
               // white12Float = basicRedFloat;
               // red12Float = basicRedFloat;
               // metal12Float = basicRedFloat;
               //plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                //plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
            break;

            case 13:
            //HERE
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
              MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,.75f),4 *Time.deltaTime);
            minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }
             if(!switchZoom)
             {
                 float y = plastic13Red.GetFloat("Vector1_BBEE40D8");
                 if (plastic13Red.GetFloat("Vector1_BBEE40D8") > 1)
                 {

                 }else{
                     y += Time.deltaTime;
                 }                
                plastic13Red.SetFloat("Vector1_BBEE40D8",y);
                plastic13Red.SetFloat("Vector1_824EC8D0",-y);

             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                      if (black13Float>0)
             {
                 black13Float -= Time.deltaTime;
             }else{
                 black13Float = 0;
             }
               if (metal13Float>0)
             {
                 metal13Float -= Time.deltaTime;
             }else{
                 metal13Float = 0;
             }
               if (plastic13Float>0)
             {
                 plastic13Float -= Time.deltaTime;
             }else{
                 plastic13Float = 0;
             }
               if (red13Float>0)
             {
                 red13Float -= Time.deltaTime;
             }else{
                 red13Float = 0;
             }
               if (white13Float>0)
             {
                 white13Float -= Time.deltaTime;
             }else{
                 white13Float = 0;
             }
                 if (nomaxFloat>0)
             {
                 nomaxFloat -= Time.deltaTime;
             }else{
                 nomaxFloat = 0;
             }
             if(plastic13Red.GetFloat("Vector1_824EC8D0")>0){
                 float y = plastic13Red.GetFloat("Vector1_824EC8D0");
                 y -= Time.deltaTime;
             plastic13Red.SetFloat("Vector1_824EC8D0",y);
             }else{
                 plastic13Red.SetFloat("Vector1_824EC8D0",0);
             }

                

                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                //nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                //black13Float = basicRedFloat;
                //white13Float = basicRedFloat;
                //red13Float = basicRedFloat;
                //plastic13Float = basicRedFloat;
                //metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                 plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                //plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
               
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
            MoveTextDown(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(1,.5f,2.25f),4 *Time.deltaTime);
             minFloat = -1.5f;
            maxFloat =-3f;
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-3),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z > -3.5 && Cam.transform.localPosition.z < -3)
                  {
                      switchZoom = false;
                  }
             }

             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
                  if (metal7Float>0)
             {
                 metal7Float -= Time.deltaTime;
             }else{
                 metal7Float = 0;
             }
              if (plastic7Float>0)
             {
                 plastic7Float -= Time.deltaTime;
             }else{
                 plastic7Float = 0;
             }
              if (wplastic7Float>0)
             {
                 wplastic7Float -= Time.deltaTime;
             }else{
                 wplastic7Float = 0;
             }

                blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
               // metal7Float = basicRedFloat;
               // plastic7Float = basicRedFloat;
               // wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
                
            break;
            case 15:
            minFloat = -4f;
            maxFloat = -8f;
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
              MoveTextUp(CoolingLines,1000);
             batteryModel.transform.localPosition = Vector3.Lerp(batteryModel.transform.localPosition,new Vector3(0,1.5f,0),4 *Time.deltaTime);
             if (switchZoom){
                  Cam.transform.localPosition = Vector3.Slerp(Cam.transform.localPosition,new Vector3(0,0,-7.5f),2*Time.deltaTime);
                  CamParent.transform.position = Vector3.Slerp(CamParent.transform.position,Vector3.zero,2*Time.deltaTime);
                  if (Cam.transform.localPosition.z < -7.5 && Cam.transform.localPosition.z > -8)
                  {
                      switchZoom = false;
                  }
             }
             if (basicRedFloat<1.1f){                 
                 basicRedFloat +=Time.deltaTime;
                 }else{
                     basicRedFloat = 1.1f;
                 } 
             if (rubber15Float>0)
             {
                 rubber15Float -= Time.deltaTime;
             }else{
                 rubber15Float = 0;
             }
            


                 blackAdFloat = basicRedFloat;
                blackPlasFloat = basicRedFloat;
                boxShapeBlackFloat = basicRedFloat;
                boxShapeMetalicFloat = basicRedFloat;
                boxShapeRedFloat = basicRedFloat;
                boxShapeWhiteFloat = basicRedFloat;
                cutShaderFloat = basicRedFloat;
                deviderFloat = basicRedFloat;
                deviderSwerlyFloat = basicRedFloat;
                dupontlogoFloat = basicRedFloat;
                genaricBlurry1Float = basicRedFloat;
                genaricBlurryFloat = basicRedFloat;
                genaricfastenersFloat = basicRedFloat;
                mintFloat = basicRedFloat;
                nomaxFloat = basicRedFloat;
                orangeFloat = basicRedFloat;
                outsideFloat = basicRedFloat;
                teslaFloat = basicRedFloat;
                whiteplasticFloat = basicRedFloat;
                yellowFloat = basicRedFloat;
                metal1Float = basicRedFloat;
                ruber2Float = basicRedFloat;
                metal3Float = basicRedFloat;
                plastic4Float = basicRedFloat;
                plastic5Float = basicRedFloat;
                metal7Float = basicRedFloat;
                plastic7Float = basicRedFloat;
                wplastic7Float = basicRedFloat;
                metal8Float = basicRedFloat;
                plastic8Float = basicRedFloat;
                black9Float = basicRedFloat;
                red9Float = basicRedFloat;
                white9Float = basicRedFloat;
                metal9Float = basicRedFloat;
                plastic9Float = basicRedFloat;
                metal10Float = basicRedFloat;
                plastic10Float = basicRedFloat;
                wplastic10Float = basicRedFloat;
                black11Float = basicRedFloat;
                white11Float = basicRedFloat;
                red11Float = basicRedFloat;
                metal11Float = basicRedFloat;
                plastic11Float = basicRedFloat;
                black12Float = basicRedFloat;
                white12Float = basicRedFloat;
                red12Float = basicRedFloat;
                metal12Float = basicRedFloat;
                plastic12Float = basicRedFloat;
                black13Float = basicRedFloat;
                white13Float = basicRedFloat;
                red13Float = basicRedFloat;
                plastic13Float = basicRedFloat;
                metal13Float = basicRedFloat;
                metal14Float = basicRedFloat;
                plastic14Float = basicRedFloat;
                //rubber15Float = basicRedFloat;
                plastic11Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic12Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic13Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                plastic6Red.SetFloat("Vector1_824EC8D0",basicRedFloat);
                 
            break;


        }
      
                basicREd.SetFloat("Vector1_824EC8D0",basicRedFloat);
                blackAd.SetFloat("Vector1_824EC8D0",blackAdFloat);
                blackPlas.SetFloat("Vector1_824EC8D0",blackPlasFloat);
                boxShapeBlack.SetFloat("Vector1_824EC8D0",boxShapeBlackFloat);
                boxShapeMetalic.SetFloat("Vector1_824EC8D0",boxShapeMetalicFloat);
                boxShapeRed.SetFloat("Vector1_824EC8D0",boxShapeRedFloat);
                boxShapeWhite.SetFloat("Vector1_824EC8D0",boxShapeWhiteFloat);
                cutShader.SetFloat("Vector1_824EC8D0",cutShaderFloat);
                devider.SetFloat("Vector1_824EC8D0",deviderFloat);
                deviderSwerly.SetFloat("Vector1_824EC8D0",deviderSwerlyFloat);
                dupontlogo.SetFloat("Vector1_824EC8D0",dupontlogoFloat);
                genaricBlurry1.SetFloat("Vector1_824EC8D0",genaricBlurry1Float);
                genaricBlurry.SetFloat("Vector1_824EC8D0",genaricBlurryFloat);
                genaricfasteners.SetFloat("Vector1_824EC8D0",genaricfastenersFloat);
                mint.SetFloat("Vector1_824EC8D0",mintFloat);
                nomax.SetFloat("Vector1_824EC8D0",nomaxFloat);
                orange.SetFloat("Vector1_824EC8D0",orangeFloat);
                outside.SetFloat("Vector1_824EC8D0",outsideFloat);
                tesla.SetFloat("Vector1_824EC8D0",teslaFloat);
                whiteplastic.SetFloat("Vector1_824EC8D0",whiteplasticFloat);
                yellow.SetFloat("Vector1_824EC8D0",yellowFloat);
                metal1.SetFloat("Vector1_824EC8D0",metal1Float);
                ruber2.SetFloat("Vector1_824EC8D0",ruber2Float);
                metal3.SetFloat("Vector1_824EC8D0",metal3Float);
                plastic4.SetFloat("Vector1_824EC8D0",plastic4Float);
                plastic5.SetFloat("Vector1_824EC8D0",plastic5Float);
                metal7.SetFloat("Vector1_824EC8D0",metal7Float);
                plastic7.SetFloat("Vector1_824EC8D0",plastic7Float);
                wplastic7.SetFloat("Vector1_824EC8D0",wplastic7Float);
                metal8.SetFloat("Vector1_824EC8D0",metal8Float);
                plastic8.SetFloat("Vector1_824EC8D0",plastic8Float);
                black9.SetFloat("Vector1_824EC8D0",black9Float);
                red9.SetFloat("Vector1_824EC8D0",red9Float);
                white9.SetFloat("Vector1_824EC8D0",white9Float);
                metal9.SetFloat("Vector1_824EC8D0",metal9Float);
                plastic9.SetFloat("Vector1_824EC8D0",plastic9Float);
                metal10.SetFloat("Vector1_824EC8D0",metal10Float);
                plastic10.SetFloat("Vector1_824EC8D0",plastic10Float);
                wplastic10.SetFloat("Vector1_824EC8D0",wplastic10Float);
                black11.SetFloat("Vector1_824EC8D0",black11Float);
                white11.SetFloat("Vector1_824EC8D0",white11Float);
                red11.SetFloat("Vector1_824EC8D0",red11Float);
                metal11.SetFloat("Vector1_824EC8D0",metal11Float);
                plastic11.SetFloat("Vector1_824EC8D0",plastic11Float);
                black12.SetFloat("Vector1_824EC8D0",black12Float);
                white12.SetFloat("Vector1_824EC8D0",white12Float);
                red12.SetFloat("Vector1_824EC8D0",red12Float);
                metal12.SetFloat("Vector1_824EC8D0",metal12Float);
                plastic12.SetFloat("Vector1_824EC8D0",plastic12Float);
                black13.SetFloat("Vector1_824EC8D0",black13Float);
                white13.SetFloat("Vector1_824EC8D0",white13Float);
                red13.SetFloat("Vector1_824EC8D0",red13Float);
                plastic13.SetFloat("Vector1_824EC8D0",plastic13Float);
                metal13.SetFloat("Vector1_824EC8D0",metal13Float);
                metal14.SetFloat("Vector1_824EC8D0",metal14Float);
                plastic14.SetFloat("Vector1_824EC8D0",plastic14Float);
                rubber15.SetFloat("Vector1_824EC8D0",rubber15Float);    
        
      //  Debug.Log(moveDownasdasdadasdasd);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
         
         if (Input.GetMouseButtonDown(3))
           {
            //Debug.Log("fuck");
            RaycastHit hitTag2;
            startPos = Input.mousePosition; 
                    Ray rayEnd = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(rayEnd,out hitTag2))
                    {
                       // if(!(Input.touchCount > 1))                        
                       // if( timer)
                       // {
                        if(hitTag2.collider != null)
                        {    

                                if(startPos.y > textLine.transform.position.y && startPos.y > textLine2.transform.position.y&& startPos.y > textLine3.transform.position.y&& startPos.y > textLine4.transform.position.y&& startPos.y > textLine5.transform.position.y&& startPos.y > textLine6.transform.position.y&& startPos.y > textLine7.transform.position.y&& startPos.y > textLine8.transform.position.y&& startPos.y > textLine9.transform.position.y&& startPos.y > textLine10.transform.position.y&& startPos.y > textLine11.transform.position.y&& startPos.y > textLine12.transform.position.y&& startPos.y > textLine13.transform.position.y&& startPos.y > textLine14.transform.position.y )
        {
                             if(hitTag2.collider.tag == "background" )
                            {
                                state = 0;  
                                switchZoom = true;
                                                        
                            } 
        }
                            if (hitTag2.collider.tag == "Betamate Adhesive Bonding"  )
                            {
                                if (state == 0){
                                    state = 1;
                              switchZoom = true;
                                }else if (state != 1){
                                    state = 0;
                                    switchZoom =true;
                                }
                             
                            }
                           

                            if (hitTag2.collider.tag == "Cover Sealing"  )
                            {
                               if (state == 0){
                                    state = 2;
                              switchZoom = true;
                                }else if (state != 2){
                                    state = 0;
                                    switchZoom =true;
                                }
                              
                            }
                            if (hitTag2.collider.tag == "HV Connector System")
                            {
                               if (state == 0){
                                    state = 3;
                              switchZoom = true;
                                }else if (state != 3){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag2.collider.tag == "LV Connector" )
                            {
                              if (state == 0){
                                    state = 4;
                              switchZoom = true;
                                }else if (state != 4){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag2.collider.tag == "Fluid Connectors" )
                            {
                               if (state == 0){
                                    state = 5;
                              switchZoom = true;
                                }else if(state != 5){
                                    state = 0;
                                    switchZoom =true;
                                }
                                
                            }
                             if (hitTag2.collider.tag == "Structural Bonding" )
                            {
                              if (state == 0){
                                    state = 6;
                              switchZoom = true;
                                }else if (state != 6){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Module End Plates" )
                            {
                               if (state == 0){
                                    state = 7;
                              switchZoom = true;
                                }else if(state != 7){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Innovative Design for Hybrid Cooling Plate" )
                            {
                               if (state == 0){
                                    state = 8;
                              switchZoom = true;
                                }else if (state != 8){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Thermal Conductive Interface" )
                            {
                               if (state == 0){
                                    state = 9;
                              switchZoom = true;
                                }else if (state != 9){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Plastic Cell Holders" )
                            {
                               if (state == 0){
                                    state = 10;
                              switchZoom = true;
                                }else if (state != 10){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Battery Cell to Pack Structural Bonding" )
                            {
                              if (state == 0){
                                    state = 11;
                              switchZoom = true;
                                }else if (state != 11){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Prismatic Cell Bonding" )
                            {
                               if (state == 0){
                                    state = 12;
                              switchZoom = true;
                                }else if (state != 12){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Cell to Cell Insulation" )
                            {
                               if (state == 0){
                                    state = 13;
                              switchZoom = true;
                                }else if (state != 13){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag2.collider.tag == "Immersion Cooling"  )
                            {
                               if (state == 0){
                                    state = 14;
                              switchZoom = true;
                                }else if (state != 14){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag2.collider.tag == "Cooling Lines"  )
                            {
                               if (state == 0){
                                    state = 15;
                              switchZoom = true;
                                }else if (state != 15){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }


                           
                        }
                        }                        
                  //  }                    

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
                 //timer = false;      
                 if (timerTime >=.15f)
                 timer = false;
                 Debug.Log("moving finger!!");        
                    break;

                case TouchPhase.Ended:
                     // Record initial touch position.  
                                     
                    RaycastHit hitEnd;
                    Ray rayEnd = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(rayEnd,out hitEnd))
                    {
                       // if(!(Input.touchCount > 1))                        
                        if( timer)
                        {
                        if(hitEnd.collider != null)
                        {    

                                if(startPos.y > textLine.transform.position.y && startPos.y > textLine2.transform.position.y&& startPos.y > textLine3.transform.position.y&& startPos.y > textLine4.transform.position.y&& startPos.y > textLine5.transform.position.y&& startPos.y > textLine6.transform.position.y&& startPos.y > textLine7.transform.position.y&& startPos.y > textLine8.transform.position.y&& startPos.y > textLine9.transform.position.y&& startPos.y > textLine10.transform.position.y&& startPos.y > textLine11.transform.position.y&& startPos.y > textLine12.transform.position.y&& startPos.y > textLine13.transform.position.y&& startPos.y > textLine14.transform.position.y )
        {
                             if(hitTag == "background" && hitEnd.collider.tag == "background")
                            {
                                state = 0;  
                                switchZoom = true;
                                                        
                            } 
        }
                            if (hitTag == "Betamate Adhesive Bonding" && hitEnd.collider.tag == hitTag  )
                            {
                                if (state == 0){
                                    state = 1;
                              switchZoom = true;
                                }else if (state != 1){
                                    state = 0;
                                    switchZoom =true;
                                }
                             
                            }
                           

                            if (hitTag == "Cover Sealing" && hitEnd.collider.tag == hitTag  )
                            {
                               if (state == 0){
                                    state = 2;
                              switchZoom = true;
                                }else if (state != 2){
                                    state = 0;
                                    switchZoom =true;
                                }
                              
                            }
                            if (hitTag == "HV Connector System" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 3;
                              switchZoom = true;
                                }else if (state != 3){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag == "LV Connector" && hitEnd.collider.tag == hitTag)
                            {
                              if (state == 0){
                                    state = 4;
                              switchZoom = true;
                                }else if (state != 4){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag == "Fluid Connectors" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 5;
                              switchZoom = true;
                                }else if(state != 5){
                                    state = 0;
                                    switchZoom =true;
                                }
                                
                            }
                             if (hitTag == "Structural Bonding" && hitEnd.collider.tag == hitTag)
                            {
                              if (state == 0){
                                    state = 6;
                              switchZoom = true;
                                }else if (state != 6){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Module End Plates" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 7;
                              switchZoom = true;
                                }else if(state != 7){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Innovative Design for Hybrid Cooling Plate" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 8;
                              switchZoom = true;
                                }else if (state != 8){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Thermal Conductive Interface" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 9;
                              switchZoom = true;
                                }else if (state != 9){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Plastic Cell Holders" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 10;
                              switchZoom = true;
                                }else if (state != 10){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Battery Cell to Pack Structural Bonding" && hitEnd.collider.tag == hitTag)
                            {
                              if (state == 0){
                                    state = 11;
                              switchZoom = true;
                                }else if (state != 11){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Prismatic Cell Bonding" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 12;
                              switchZoom = true;
                                }else if (state != 12){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Cell to Cell Insulation" && hitEnd.collider.tag == hitTag)
                            {
                               if (state == 0){
                                    state = 13;
                              switchZoom = true;
                                }else if (state != 13){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }

                            if (hitTag == "Immersion Cooling" && hitEnd.collider.tag == hitTag )
                            {
                               if (state == 0){
                                    state = 14;
                              switchZoom = true;
                                }else if (state != 14){
                                    state = 0;
                                    switchZoom =true;
                                }
                            }
                             if (hitTag == "Cooling Lines" && hitEnd.collider.tag == hitTag )
                            {
                               if (state == 0){
                                    state = 15;
                              switchZoom = true;
                                }else if (state != 15){
                                    state = 0;
                                    switchZoom =true;
                                }
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
               // UpdateZoomMouse(offset);

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
         CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 50), 0, 0);
         //CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 0, 90), 0, 0); for full up
        else if (rot >180)
            CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 310,360), 0, 0);
            //CamParent.transform.eulerAngles = new Vector3(Mathf.Clamp(CamParent.transform.eulerAngles.x, 270,360), 0, 0); for full down
     

    }


}
