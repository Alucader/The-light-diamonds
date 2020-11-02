using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 购买钻石
/// </summary>
public class Payment : MonoBehaviour
{

    public Text dorlls;
    public InputField Input;
    // Start is called before the first frame update

    void Start()
    {
       
        
    }

    public void OnClick(int num)
    {
        dorlls.text = (num / 10).ToString();
        Input.text = "";
    }
    public void ChageValue()
    {
        //Debug.Log(Input.text);
        dorlls.text = (float.Parse(Input.text) / 10).ToString();
    }

}
