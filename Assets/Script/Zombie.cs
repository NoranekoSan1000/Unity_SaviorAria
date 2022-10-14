using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private int Hp = 10;

    private Rigidbody rb;
    private Animator anim;  //Animatorをanimという変数で定義する

    private ZombieHit HitScript;
    private ZombieHit HitScript2;
    public GameObject lookTarget;
    public GameObject Head;
    public GameObject Body;


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
        walkEnemy();

        if (Hp <= 0)
        {
            anim.SetBool("IsFalling", true);      
            Destroy(this.gameObject,2.0f);

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
        Vector3 MyPos = this.gameObject.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);
        if (dis > 2.2f)
        {
            transform.position += transform.forward * 2.5f * Time.deltaTime;
            anim.SetBool("IsWalking", true);
        }
        else anim.SetBool("IsWalking", false);

    }

    public int HitShot(int Damage)
    {
        Hp -= Damage * PlayerStatus.GunDamage[PlayerStatus.GunMode];
        return Hp;
    }

}