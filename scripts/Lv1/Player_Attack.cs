using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Attack : MonoBehaviour
{
    public GameObject obj;
    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
       // print(Vector3.Distance(gameObject.transform.position, obj.transform.position));
        if(Vector3 .Distance(gameObject.transform.position, obj.transform.position) <= 4.5f)
        {
            if (slider.value >= 0.2f)
                slider.value -= 0.2f;
            else
                slider.value = 0;

        }
    }
}
