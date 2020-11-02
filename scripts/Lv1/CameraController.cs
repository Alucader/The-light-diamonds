using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookPos;  //看向的位置
    public Transform lerpPos;  //插值的位置
    public float dist;     //摄像机
    public float followSpeed = 10;  //跟随速度
    public float rotateSpeed = 10;  //旋转速度
    private float dis;
    public bool allowLock = true;
    public void Start()
    {
        dis = transform.position.y - lookPos.position.y;
    }
    void Update()
    {
        //锁定鼠标指针
     /*   if (Input.GetButtonDown("Fire1") && Cursor.lockState != CursorLockMode.Locked )
        {                  
            Cursor.lockState = CursorLockMode.Locked;
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;

        }*/

        float horMouse = Input.GetAxis("Mouse X");  //获取鼠标左右移动
     
        transform.RotateAround(lerpPos.position, lerpPos.up, horMouse * Time.deltaTime * rotateSpeed);//设置摄像机旋转
      
        Vector3 tempPosition = lerpPos.position + (transform.position - lerpPos.position).normalized * dist;//设置摄相机跟随

        tempPosition.y = lookPos.position.y + dis;
        transform.position = Vector3.Lerp(transform.position, tempPosition, Time.deltaTime * followSpeed);  
       
        transform.LookAt(lookPos);//看向指定的位置
    }
}
