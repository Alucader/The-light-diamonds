using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject obj;
   
    public GameObject obj2;
    public GameObject plane;
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
            Debug.Log("111");
            StartCoroutine(Move());
            plane.SetActive(true);
            Destroy(plane, 0.9f);


        }
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds (0.5f);
        obj.GetComponent<CharacterController>().enabled = false;
        obj.transform.position = obj2.transform.position;
        obj.transform.rotation = obj2.transform.rotation;
        obj.GetComponent<CharacterController>().enabled = true;
        obj.GetComponent<PlayController>().isAtk = false;


    }

}
