using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAtBottom : MonoBehaviour
{
    public RectTransform bottomMarker;

    public GameObject basess;
    public RectTransform Adhesivebonding;
    public RectTransform coverSeal;
    public RectTransform connectorHV;
    public RectTransform connectorLV;
    public RectTransform fluidConnectors;
    public RectTransform structuralBonding;
    public RectTransform modukeEndPlates;
    public RectTransform InnovativeDesignforHybridCoolingPlate;
    public RectTransform ThermaConductiveInterfaceBetweenCoolingPlateandBatteryModules;
    public RectTransform PlasticCellHolders;
    public RectTransform BatteryCelltoPackStructuralBonding;
    public RectTransform PrismaticCellBonding;     
    public RectTransform celltocell;          
    public RectTransform ImmersionCooling;
    public RectTransform CoolingLines;
     private void Awake()
    {
        basess.SetActive(false);
        Adhesivebonding.anchoredPosition = bottomMarker.position;

        coverSeal.anchoredPosition = bottomMarker.position;

        connectorHV.anchoredPosition = bottomMarker.position;

        connectorLV.anchoredPosition = bottomMarker.position;

        fluidConnectors.anchoredPosition = bottomMarker.position;

        structuralBonding.anchoredPosition = bottomMarker.position;

        modukeEndPlates.anchoredPosition = bottomMarker.position;

        InnovativeDesignforHybridCoolingPlate.anchoredPosition = bottomMarker.position;

        ThermaConductiveInterfaceBetweenCoolingPlateandBatteryModules.anchoredPosition = bottomMarker.position;

        PlasticCellHolders.anchoredPosition = bottomMarker.position;

        BatteryCelltoPackStructuralBonding.anchoredPosition = bottomMarker.position;

        PrismaticCellBonding.anchoredPosition = bottomMarker.position;

        celltocell.anchoredPosition = bottomMarker.position;

        ImmersionCooling.anchoredPosition = bottomMarker.position;

        CoolingLines.anchoredPosition = bottomMarker.position;

    }
    
    void Update()
    {
        
    }

}
