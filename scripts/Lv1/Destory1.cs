using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destory()
    {
        Destroy(this.gameObject, 2.0f);
    }
}
