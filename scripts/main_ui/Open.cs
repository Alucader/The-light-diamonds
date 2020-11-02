using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public Color backgroundColor = new Color(10.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f, 0.6f);   //RGBA（10，10，10，153）黑色半透明
    private GameObject m_background;
    private Image image;
    Animator animator;

 
    public void OpenBg()

    {
        animator = GetComponent<Animator>();
        AddBackground(); //第一步应该先加载一个半透明ui来遮挡前面的ui,防止能继续点前面的按钮
  
    }

    private void AddBackground() //遮挡ui
    {
       //生成遮挡层ui，设置image，color属性
        m_background = new GameObject("PopupBackground");

      //  Debug.Log("111111111");

        RectTransform rect = m_background.gameObject.GetComponent<RectTransform>();

       // Debug.Log("22222222222");

     

       // Debug.Log("3333333");

        image = m_background.AddComponent<Image>();                          //添加Image组件      
        image.color = backgroundColor;                                      //颜色
        //设置缩放，大小，父子关系，层级
        var canvas = GameObject.Find("Canvas");
        m_background.transform.localScale = new Vector3(1, 1, 1);
        m_background.GetComponent<RectTransform>().sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;    //设置长款与canvas一致
        m_background.transform.SetParent(canvas.transform, false);                                               //设置canvas为父物体
        m_background.transform.SetSiblingIndex(transform.GetSiblingIndex());                                    //SetSiblingIndex（int）设置层级  

        // Debug.Log("4444444");
        rect = m_background.gameObject.GetComponent<RectTransform>();            
        rect.anchorMin = new Vector2(0, 0);                                         //设置anchor preset 为 stretch，以确保遮罩层在来回伸缩时不会漏出需要遮挡的ui
        rect.anchorMax = new Vector2(1, 1);
   
    }

    /// <summary>
    /// 关闭函数
    /// </summary>
    public void Close()   
    {
              
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("play"))         //如果当前动画片段是play,切换为关闭动画
         animator.Play("close");
        Destroy(m_background);                                              //销毁遮罩层
        StartCoroutine(PrefabDestroy());                                    //携程延迟销毁Prefab
    }
    private IEnumerator PrefabDestroy()                //销毁携程
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
        print("销毁携程");
    }
}
