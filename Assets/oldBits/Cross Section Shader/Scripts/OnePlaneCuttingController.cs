using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingController : MonoBehaviour {

    public GameObject plane;
    Material mat;
    public Vector3 normal;
    public Vector3 position;
    //public Renderer rend;
    //public List<MeshRenderer> meshs = new List<MeshRenderer>();
    public MeshRenderer[] meshs = new MeshRenderer[0];

    // Use this for initialization
    void Start () {
       // rend = GetComponent<Renderer>();
        normal = plane.transform.TransformVector(new Vector3(0,0,-1));
        position = plane.transform.position;
        UpdateShaderProperties();
        
        meshs = this.GetComponentsInChildren<MeshRenderer>() ;
    }
    void Update ()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {

        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;
        foreach (MeshRenderer m in meshs)
        {
            for (int i = 0; i < m.materials.Length; i++)
            {
                if (m.materials[i].shader.name == "Custom/FadableSplitShader")
                {
                    m.materials[i].SetVector("_PlaneNormal", normal);
                    m.materials[i].SetVector("_PlanePosition", position);
                }
            }
        }
        
    }
}
