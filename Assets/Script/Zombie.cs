using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public static int Hp = 15;

    private Rigidbody rb;
    private Animator anim;  //Animatorをanimという変数で定義する
    public GameObject lookTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //中央を向くプログラム
        LookCenter();

        //歩いてくるプログラム
        Vector3 MyPos = this.gameObject.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);
        if (dis > 0.5f)
        {
            walkEnemy();
            anim.SetBool("IsWalking", true);
        }
        else anim.SetBool("IsWalking", false);

        //Hp減少
        HitShot();
        Debug.Log(Hp);
        
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void LookCenter()
    {
        if (lookTarget)
        {
            var direction = lookTarget.transform.position - transform.position;
            direction.y = 0;

            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1);
        }
    }

    public void walkEnemy()
    {
        transform.position += transform.forward * 1.0f * Time.deltaTime;
    }

    public void HitShot()
    {
        if (ZombieHit.HeadHit)
        {
            Hp -= 2;
            ZombieHit.HeadHit = false;
        }
        if (ZombieHit.BodyHit)
        {
            Hp -= 1;
            ZombieHit.BodyHit = false;
        }
    }

}