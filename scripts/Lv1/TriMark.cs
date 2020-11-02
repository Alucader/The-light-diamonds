using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriMark : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mark;
    public GameObject nest;
    public bool isTr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other .tag == ("Player"))
        {
            // print(other.tag);
            nest.SetActive(true);
            Destroy(mark, 0.5f);
        }
    }

}
