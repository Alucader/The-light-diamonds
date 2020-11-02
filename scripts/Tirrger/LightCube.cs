using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour
{
    public Color color;
    public GameObject Object;
    public float mul;
    public MeshRenderer renderer1;
    public GameManager manager;
    void Start()
    {
        manager = (GameManager)FindObjectOfType(typeof(GameManager)) as GameManager;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            print("ss");
            renderer1.material.SetVector("_EmissionColor", color * mul);
            Object.SetActive(true);
            manager.LightCubeNum();
            Destroy(gameObject, 0.3f);
        }
    }
}
