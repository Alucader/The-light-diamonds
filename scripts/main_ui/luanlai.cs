using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luanlai : MonoBehaviour
{
    public Text wwwww;
    public Text text;
    public Image image;   
    public Image obj;
    public MainUIData mainUIData;
    void Start()
    {
       mainUIData = MainUIData.Instance;
        // image = this.GetComponent<Image>();      
    } 
      public void onclicks()
    {
        PlayerPrefs.SetInt("ex", mainUIData.ex+25);
    }

}
