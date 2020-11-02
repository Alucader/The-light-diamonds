using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota : MonoBehaviour
{


    //水平速度
    public float HorizontalSpeed = 2.0F;
    //垂直速度
    public float VerticalSpeed = 2.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //水平方向
        float h = HorizontalSpeed * Input.GetAxis("Mouse X");
        //垂直方向
        float v = VerticalSpeed * Input.GetAxis("Mouse Y");
        //旋转
        transform.Rotate(v, h, 0);
    }
}
