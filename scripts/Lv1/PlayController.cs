using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public List<Transform> handList = new List<Transform>();
    public ParticleSystem particle;
    // GameObject[] hands;
    CharactHp charactHp;
    public Transform lefthand;
    [Header("地形掉落重置")]
    public float deadPosition=-10f;  //掉落死亡位置
    public Vector3 startTranform;
    public float dis;
    public bool isjumpup;
    public bool islock;
    public Animator anim;    //动画状态机
    private float moveSpeed=6.0f;     //移动速度
    public float _moveSpeed = 6.0f;     //移动速度
    public float rotateSpeed=1.0f;   //旋转速度

    public AudioSource aS;          //AudioSourse组件 用来播放 脚步声
    public Transform myCamera;   //摄像机组件
    private CharacterController controller;
    public bool isAtk;
    public GameObject sword;
    //9-16地形重置
    public bool level;
   
     public Vector3 revector;
    // public GameObject _particle;
    private  void Start()
    {
        
        aS.Stop();
        particle.Stop();
       // _particle.SetActive(true);
        charactHp = GetComponent<CharactHp>();
        controller = GetComponent<CharacterController>();
        startTranform = this.transform.position;
        
    }


    private void Update()
    {
       
            Movement();
            RePosition();
            if (isAtk)
            {
                sword.SetActive(true);
                moveSpeed = _moveSpeed - 2;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetBool("Attcak", true);
                }
                else anim.SetBool("Attcak", false);
            }
            else
            {
                sword.SetActive(false);
                moveSpeed = _moveSpeed;
            }
        
        
            
        // else sword.SetActive(false);
        if (handList.Count > 0)
            lefthand = handList[FindHand()];
       
    }

    /// <summary>
    /// 移动
    /// </summary>
    private void Movement()
    {
        float ver = Input.GetAxis("Vertical");          //获取轴
        float hor = Input.GetAxis("Horizontal");
         if (hor != 0 || ver != 0)  //如果 条件成立 则表明 按键被按下了已经
            {

                if (!anim.GetBool("Run"))         //播放动画 和 声音
                {
                    anim.SetBool("Run", true);
                    anim.SetBool("hit", false);
                    aS.Play();
                }
              
                if (anim.GetBool("Run"))
                {
                //获取旋转的方向
                Vector3 tempV = Vector3.ProjectOnPlane(myCamera.right * hor + myCamera.forward * ver, Vector3.up);

                Quaternion dir = Quaternion.LookRotation(tempV);
                transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime * rotateSpeed); //旋转插值   
              
                  controller.Move(transform.forward * Time.deltaTime * moveSpeed*Mathf .Max (Mathf.Abs(ver), Mathf.Abs(hor)));     //移动代码
                  
                } 
                    

            }
            else
            {
                if (anim.GetBool("Run")) //停止播放 动画和 脚步声
                {
                    anim.SetBool("Run", false);
                    aS.Stop();
                }
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
             anim.SetBool("Jump", true);
             
        }
           else anim.SetBool("Jump", false);
     

        
    }

    private void OnAnimatorIK(int layerIndex)
    {
       // print(Vector2.Distance(new Vector2(lefthand.position.x, lefthand.position.z), new Vector2(transform.position.x, transform.position.z)));
        if (anim)
        {

           // 
            if (isjumpup&&Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("isjumpup", true);
              
            }
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
           // print(stateInfo.IsName("JumpUp"));
            if (stateInfo.IsName("JumpUp"))
            {
                anim.SetBool("isjumpup", false);
                isjumpup = false;
                anim.MatchTarget(lefthand.position, lefthand.rotation,
                    AvatarTarget.LeftHand,
                    new MatchTargetWeightMask(new Vector3(1, 1, 1), 0),
                    anim.GetFloat("StartTime"),
                    anim.GetFloat("EndTime"));
              
            }
        }
    }
     private int FindHand()
    {
        //print(handList.Count);
        float[] distances = new float[handList.Count];
        for (int i = 0; i < handList.Count; i++)
        {
            distances[i] = Vector2.Distance(new Vector2(handList[i].position.x, handList[i].position.z), new Vector2(transform.position.x, transform.position.z));
        }

        float minDistance = Mathf.Min(distances);
        int index = 0;

        for (int i = 0; i < distances.Length; i++)
        {
            if (minDistance == distances[i])
                index = i;
        }

        return index;
    }

    private void RePosition()
    {
           
        if (level==false&& transform .position .y <= deadPosition)
        {
            controller.enabled = false;
            transform.position = startTranform;
            controller.enabled = true ;
        }
        if (level == true  && transform.position.y <= deadPosition)
        {
            controller.enabled = false;
            transform.position = revector;
            controller.enabled = true;
        }

    }

    public void TakeBeating()
    {
        if(!charactHp.isDeath)
        {
           // _particle.SetActive(true);
            anim.SetBool("hit", true);
            particle.Play();
        }
       
        //print("HP-1");
      
    }
    public void TakeBeatingEnd()
    {
        anim.SetBool("hit", false);
        
    }

}
