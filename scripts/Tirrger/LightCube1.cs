using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube1 : MonoBehaviour
{
    public Color color;
    public bool isLight;
    public float mul;
    public MeshRenderer renderer1;
    public GameManager manager;

    void Start()
    {
         manager = (GameManager)FindObjectOfType(typeof(GameManager)) as GameManager;

    }
    void OnTriggerEnter(Collider other)
    {
        if (!isLight)
        {
            if (other.tag == ("Player") || other.tag == ("Player1"))
            {
                isLight = true;

                renderer1.material.SetVector("_EmissionColor", color * mul);
                manager.LightCubeNum();
            }
        }
       
    }
}
