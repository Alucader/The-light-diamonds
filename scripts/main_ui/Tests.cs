using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 改头像
/// </summary>
public class Tests : MonoBehaviour
{
    [Header ("Photo")]
    [Space]
    public Image pto1; 
   
    [Space]
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        pto1 = GameObject.Find("photo_one").GetComponent<Image>();
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(isOn => { if (isOn) {image .sprite =gameObject .GetComponent<Image>().sprite; }  });
    }

    public void Select()
    {
        pto1.sprite = image.sprite;
     
    }
}
