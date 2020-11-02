using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lv1Death : MonoBehaviour
{
    public GameObject obj;
    public Slider slider;
    public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0)
        {
            obj2.SetActive(true);
            Destroy(obj);
        }
    }
}
