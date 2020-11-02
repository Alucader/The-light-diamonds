using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriWin : MonoBehaviour
{
    public int starNum;
    public GameManager game;
    MainUIData data;
    public float UseTime;//游戏用时
    // Start is called before the first frame update
    void Start()
    {
        data = MainUIData.Instance;
        UseTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        starNum = game.starNum;
        UseTime += Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            data.star = starNum;
            data.nowlevel = game.nowlevel;
            string DataName = "Level" + game.nowlevel + "Time";//保存的数据名称
            if(PlayerPrefs.GetInt(DataName) == 0)
            {
                PlayerPrefs.SetInt(DataName, (int)UseTime);//保存关卡用时为整数
            }
            if(PlayerPrefs.GetInt(DataName)!=0 && UseTime < PlayerPrefs.GetInt(DataName))
            {
                PlayerPrefs.SetInt(DataName, (int)UseTime);//保存关卡用时为整数
            }
           
            LoadWinScene();
           
        }
    }
    void LoadWinScene()
    {
        SceneManager.LoadScene("win");
    }
}
