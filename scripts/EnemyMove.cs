using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    
    Animator ani;//动画控制组件
    NavMeshAgent NMA;//导航控制组件
    public GameObject player;//玩家对象
    public float distance;//玩家和敌人之间的距离
    public int nowstate;//当前敌人所处的状态
    public bool isRandom;//能否随机一个坐标点
    public float stoptime;//从移动改变为停止的状态改变的时刻
    public bool isChangestate;//控制能否改变状态
    float smothtime ;
    [Header("待机时间")]
    [Range(1.0f, 10.0f)]
    public int waitTime=2;
    [Header("随机数范围")]
    public int x1,x2,y1, y2;
    [Header("随机到的两个数")]                   
    public float x;
    public float z;
    [Header("攻击距离")]
    [Range(1.0f, 3.0f)]
    public float attackdistance=1.5f;
    [Header("移动时间")]
    public float movetime;
    public SkinnedMeshRenderer render1;
    public Color color1;
    public Color color2;
    float attacktime = 0;//定义攻击时间
    public Vector3 vector;
    AudioSource _audio;
    bool isplay;
    void Start()
    {
       _audio=GetComponent<AudioSource>();
        NMA = gameObject.GetComponent<NavMeshAgent>();//获取导航组件
        render1= gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        //敌人当前所处状态为0（发呆动画、停止不动）
        nowstate = 0;
        //可以随机一个数
        isRandom = true;
        //停留时间记为0
        stoptime = 0;
        //可以改变状态
        isChangestate = true;
        //获取动画组件
        ani = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(player.tag=="Player")
        {
            vector = player.transform.position;
        }
        //玩家和敌人之间的距离，实时更新
        distance = Vector3.Distance(transform.position, vector);
        //调用距离改变函数

        DistanceChange();
        //调用状态改变函数
        statechange();
    }
    /// <summary>
        /// 距离改变函数
        /// </summary>
    void DistanceChange()
    {
        if (distance <= 10)//如果玩家和敌人之间距离小于10
        {
            render1.material.SetVector("_EmissionColor", color1*7.0f);
           
            isChangestate = true;//可以改变状态
            nowstate = 2;//敌人状态为追赶、攻击玩家
        }
        else if (distance > 10)//如果距离大于10
        {
            if (isChangestate == true)//如果可以改变状态
            {
                ani.SetBool("run", false);
                ani.SetBool("attack1", false);
                ani.SetBool("attack2", false);
                render1.material.SetVector("_EmissionColor", color2 * 7.0f);
                nowstate = 0;//状态改变为自动巡逻的发呆状态（播放发呆动画）
                stoptime = 0;//记下状态改变的时刻
                isChangestate = false;//状态不可以改变了
            }
        }

    }
    /// <summary>
    /// 状态改变函数
    /// </summary>
    void statechange()
    {
        if (nowstate == 0)//如果状态为0
        {

            ani.SetBool("idel",true);//播放发呆动画
            ani.SetBool("walk", false);
            if (isplay)
            {
                _audio.Stop();
                isplay = false;
            };
            NMA.isStopped=true;//导航停止
            stoptime += Time.deltaTime;//停留时间自增
            isRandom = true;//可以随机数
            if (stoptime >= waitTime)//如果停留了2秒
            {
                nowstate = 1;//状态变为1
            }
        }
         if (nowstate == 1)//如果状态为1
        {
            NMA.isStopped=false;//导航恢复
            if (isRandom == true)//如果可以随机数
            {
                //随机两个点（地形范围内）
                x = Random.Range(x1, x2);
                z = Random.Range(y1, y2);

                isRandom = false;//只允许随机两个点
            }
            //下一个坐标点为随机到的点
            Vector3 nextpos = new Vector3(x, transform.position.y, z);
            NMA.destination = nextpos; //导航到下一个点
            ani.SetBool("walk",true);//播放走路动画
            if (!isplay)
            {
                _audio.Play();
                isplay = true;
            }
                
            print("_audio");
            ani.SetBool("idel", false);
            Debug.DrawLine(transform.position, nextpos, Color.red);//从当前位置到下一个点之间画一条红线
                                                                   // Debug.Log(nowstate);  
            smothtime += Time.deltaTime;
            if (smothtime>=0.5f)
            {
                if (NMA.remainingDistance <= 0.1f)//敌人和下一个点之间的距离小于0.1
                {
                    Debug.Log("移动结束");
                    nowstate = 0;//状态变为0
                    stoptime = 0;//停留时间置为0
                    smothtime = 0;
                }
            }
            
        }
        else if (nowstate == 2)//如果状态为2
        {
            if (!isplay)
            {
                _audio.Play();
                isplay = true;
            }
            print("_audio");
            NMA.destination = player.transform.position;//导航到玩家位置
            if (distance > attackdistance)//如果和玩家距离大于2
            {
                NMA.isStopped = false;
                ani.SetBool("attack1", false);
                ani.SetBool("attack2", false);
                ani.SetBool("walk", false);
                ani.SetBool("run",true);//播放跑动画
            }
            else
                ani.SetBool("run", false);

            if (distance <= attackdistance)//如果和玩家之间距离小于2
            {
                ani.SetBool("walk", false);
                NMA.isStopped = true;//导航停止
                transform.LookAt(player.transform);//敌人看向玩家
                if (isplay)
                {
                    _audio.Stop();
                    isplay = false;
                }
                attacktime += Time.deltaTime;//攻击时间自增
                if (attacktime < 10)//攻击时间小于10的时候
                {
                    ani.SetBool("attack1",true);//播放攻击1动画
                }

               else
                {
                    ani.SetBool("attack1", false);
                   
                }
                    
                if (attacktime >= 10 && attacktime <= 20)//攻击时间大于10小于20
                {
                    ani.SetBool("attack2",true);//播放攻击2动画
                   
                }
                else
                {
                    ani.SetBool("attack2", false);
                   
                }
                   
                if (attacktime > 20)//攻击超过20秒
                {
                    attacktime = 0;//攻击时间归零
                }
            }
            //Debug.DrawLine(transform.position,player.transform.position,Color.red);//敌人和玩家之间画一条红线
        }
    }
}

