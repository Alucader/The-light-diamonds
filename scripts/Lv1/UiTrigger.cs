using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrigger : MonoBehaviour
{

    public GameObject UIPrefab;
    public Canvas canvas;

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
            GameObject ui = Instantiate(UIPrefab) as GameObject;
            ui.SetActive(true);
            ui.transform.SetParent(canvas.transform, false);
            Destroy(gameObject, 0.5f);

        }
    }
}
