using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int Hp;
    public int ATK;
    public int EnemScore;
    public float MoveSpeed;

    private Rigidbody rb;
    private Animator anim;  //Animatorをanimという変数で定義する

    private ZombieHit HitScript;
    private ZombieHit HitScript2;
    public GameObject lookTarget;
    public GameObject Head;
    public GameObject Body;

    float PlayerDamageCT=3;
    bool thisDie = false;

    float CenterCoolTime = 2;

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

        //ジャンプ
        if(this.gameObject.name == "[Origin]Ghoul(Clone)") Jump();

        //攻撃プログラム
        EnemAttack();

        //死亡時
        die();

    }


    public void LookCenter()
    {
        var direction = lookTarget.transform.position - transform.position;
        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 5);     
    }

    public void walkEnemy()
    {
        Vector3 MyPos = this.gameObject.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);
        if (dis > 3.7f)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }

    public void Jump()
    {
        Debug.Log("Jump");
        rb.AddForce(new Vector3(0, 10f, 0)); //上に向かって力を加える
    }

    public void EnemAttack()
    {
        Vector3 MyPos = this.gameObject.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);
        if (dis <= 4.0f)
        {
            PlayerDamageCT -= Time.deltaTime;            
            if(PlayerDamageCT <= 0)
            {
                PlayerStatus.PlayerHP -= ATK;
                anim.SetBool("Attack", true);
                PlayerDamageCT = 3;
            }
        }
    }

    public void die()
    {
        
        if(Hp <= 0 && !thisDie)
        {
            PlayerStatus.Score += EnemScore;
            BattleSystem.EnemyAmount -= 1;
            thisDie = true;
        }
        if (thisDie)
        {
            anim.SetBool("IsFalling", true);
            Destroy(this.gameObject, 1f);
        }
    }

    public int HitShot(int Damage)
    {
        Hp -= Damage * PlayerStatus.GunDamage[PlayerStatus.GunMode];
        return Hp;
    }

}