using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData : MonoBehaviour
{
    // Start is called before the first frame update
    public string _name;
    public int _lv;
    public int _ex;
    public int _gold;
    public int _dim;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Information(string name)
    {
        PlayerPrefs.SetString("_name", name);
    }
}
