using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("levelsNum", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public   void LevelLoad()
    {
        int num =  PlayerPrefs.GetInt("levelsNum");
        print(num);
        LevelManger level = new LevelManger();
        level.OpenLevel(3);
    }
}
