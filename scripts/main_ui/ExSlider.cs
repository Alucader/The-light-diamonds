using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExSlider : MonoBehaviour
{

    Image image;
    public Text text;
    public Text HPtext;
    public Text Lvtext;
    float hp;
   public MainUIData data;
    void Start()
    {
        
        image = GetComponent<Image>();
        data = MainUIData.Instance;
      
      
    }
    
    
    void Update()
    {
        
        hp = 100*(1+ data.level * 0.2f);
        float ex = data.ex;             
        image.fillAmount =ex/100.0f;    
        text.text = "EX  "+ex + "/100";
        HPtext.text = "HP  " + hp + "/"+hp;
    }
}
