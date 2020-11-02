using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtt : MonoBehaviour
{
    public CharactHp charactHp;
    public float intervaTime=4.0f;
    private float stoptime;
    // Start is called before the first frame update
    void Start()
    {
        charactHp = GameObject.Find("CharactManager/Character").GetComponent<CharactHp>();
        GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        stoptime += Time.deltaTime;//停留时间自增
        if (stoptime >= intervaTime)//如果停留了intervaTime秒
        {
            GetComponent<ParticleSystem>().Stop();
            StartCoroutine(FirePlay());
        }
    }


    void OnParticleCollision(GameObject other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            charactHp.nowHp -= 1;
        }
    }
    IEnumerator FirePlay()
    {
        float waittime = Random.Range(2.0f, 3.0f);
        yield return new WaitForSeconds(waittime);
        stoptime = 0;
        GetComponent<ParticleSystem>().Play();
    }
}
