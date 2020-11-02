using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject player;
    public int id;
    MainUIData data;
    // Start is called before the first frame update
    void Start()
    {
        data = MainUIData.Instance;
        id = data.playid;
        player =transform.GetChild(id).gameObject;
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
