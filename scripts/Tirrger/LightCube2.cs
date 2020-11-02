using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube2 : MonoBehaviour
{
    public Color color;
    public bool isLight;
    public float mul;
    public MeshRenderer renderer1;
    public GameManager manager;
    PlayController play;

    void Start()
    {

         manager = (GameManager)FindObjectOfType(typeof(GameManager)) as GameManager;
        play = (PlayController)FindObjectOfType(typeof(PlayController)) as PlayController;
    }
    void OnTriggerEnter(Collider other)
    {
        play.revector = transform.position;
        if (!isLight)
        {
            if (other.tag == ("Player") || other.tag == ("Player1"))
            {
                isLight = true;

                renderer1.material.SetVector("_EmissionColor", color * mul);
                manager.LightCubeNum();
            }
        }
        else
        {
            isLight = false;
            renderer1.material.SetVector("_EmissionColor", new Color(0,0,0,0) );
            manager.DeleCubeNum();
        }
       
    }
}
