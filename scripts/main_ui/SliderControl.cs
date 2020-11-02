using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 滑动代码
/// </summary>
public class SliderControl : MonoBehaviour
{

    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;
    private float mTargetValue;

    private bool mNeedMove = false;

    private const float SMOOTH_TIME = 0.4F;

    private float mMoveSpeed = 0f;  

    public void OnPointerUp()
    {
        // 判断当前位于哪个区间，设置自动滑动至的位置
        if (m_Scrollbar.value <= 0.125f)    //第一张未过半
        {
            mTargetValue = 0;
        }
        else if (m_Scrollbar.value <= 0.375f)    //第二张未过半
        {
            mTargetValue = 0.25f;
        }
        else if (m_Scrollbar.value <= 0.625f)
        {
            mTargetValue = 0.5f;
        }
        else if (m_Scrollbar.value <= 0.875f)
        {
            mTargetValue = 0.75f;
        }
        else
        {
            mTargetValue = 1f;
        }

        mNeedMove = true;
        mMoveSpeed = 0;
    }



    void Update()
    {
        if (mNeedMove)
        {
            if (Mathf.Abs(m_Scrollbar.value - mTargetValue) < 0.002f)   //取绝对值
            {
                m_Scrollbar.value = mTargetValue;       
                mNeedMove = false;      
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);   //平滑缓冲，mMoveSpeed当前速度，SMOOTH_TIME缓冲时间
            //return;
        }
     
        
    }

}