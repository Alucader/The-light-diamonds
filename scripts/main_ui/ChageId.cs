using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// 改ID
/// </summary>
public class ChageId : MonoBehaviour
{
   
    public Text Id2;
    public InputField idInput;
    [SerializeField] private string id;
    [SerializeField] private Text inputText;
    private void Awake()
    {           
        //gameObject.SetActive(false);
    }
     private void Start()
    {
       
        inputText = idInput.transform.Find("Text").gameObject.GetComponent<Text>();
       
    }
    
    public void chageID()
    {
        
        id = inputText.text.Trim();
        if (id!="")
        {
            PlayerPrefs.SetString("id", id);
          
        }
        Close();

    }
   
    public void Close()
    {
        idInput.text = "";
       // Debug.Log("111111");
    }
    
}
