using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPlayerSelect : MonoBehaviour
{
    public int n;
    MainUIData data;
    // Start is called before the first frame update
    void Start()
    {
        data = MainUIData.Instance;
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(isOn => { if (isOn) { data.playid = n; } });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
