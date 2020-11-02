using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locking : MonoBehaviour
{
    public bool isLock = true;
    public  int starNum;
    public GameObject notlockimg;
    public GameObject lockimg;
    public Image leftstar;
    public Image midtstar;
    public Image rightstar;
    private Color _isStart = new Color(254.0f / 255.0f, 207.0f / 255.0f, 88.0f / 255.0f, 1);
  
    void Start()
    {
        leftstar= transform.GetChild(0).GetChild(0).GetComponent<Image>();
        midtstar = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        rightstar = transform.GetChild(0).GetChild(2).GetComponent<Image>();
       // StarNum(starNum);
    } 
    void Update()
    {
        if (isLock)
        {
            gameObject.GetComponent<Button>().enabled = false;
            notlockimg.SetActive(false );
            lockimg.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = true;
            notlockimg.SetActive(true );
            lockimg.SetActive(false);
            StarNum(starNum);
        }
        
    }
    void StarNum(int n)
    {
        switch (n)
        {
            case 0:
             
                break;
            case 1:
                leftstar.color = _isStart;
                break;
            case 2:
                leftstar.color = _isStart;
                midtstar.color = _isStart;
                break;
            default:
                leftstar.color = _isStart;
                midtstar.color = _isStart;
                rightstar.color = _isStart;
                break;
        }
    }


}

