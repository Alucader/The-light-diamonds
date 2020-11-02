using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpener : MonoBehaviour
{
    public GameObject UIPrefab;

    private Canvas m_canvas;
    // Start is called before the first frame update
    void Start()
    {
        m_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }


    public void Popup()
    {
        GameObject popup = Instantiate(UIPrefab) ;
        popup.SetActive(true); 
        popup.transform.SetParent(m_canvas.transform, false);
        popup.transform.localScale = Vector3.zero;
        popup.GetComponent<Open>().OpenBg();
    }
    
}
