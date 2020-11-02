using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tes2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        int num = PlayerPrefs.GetInt("Tes");
        print(num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
