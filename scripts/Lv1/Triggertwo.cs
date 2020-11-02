using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertwo : MonoBehaviour
{
    public GameObject mark;
    public GameObject UIPrefab;
    public Canvas canvas;
    public PlayController play;
    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            // print(other.tag);
            GameObject wuqutip = Instantiate(UIPrefab) as GameObject;
            wuqutip.SetActive(true);
            wuqutip.transform.SetParent(canvas.transform, false);
            play.isAtk = true;
            slider.SetActive(true);
            Destroy(mark);
        }
    }
}
