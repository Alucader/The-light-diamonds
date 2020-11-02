using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiDataManger : MonoBehaviour
{
    public Text id;
    public Text lv;
    public Text gold;
    public Text dim;
    MainUIData data;
    // Start is called before the first frame update
    void Start()
    {
        data = MainUIData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        id.text = data.id;
        lv.text = data.level.ToString();
        gold.text =data.gold.ToString();
        dim.text = data.dim.ToString();
    }
}
