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
    public GameObject Blood;

    float PlayerDamageCT=3;
    float EffectTime = 0;
    bool thisDie = false;

    float CenterCoolTime = 2;
    float JumpCT=0;

    public GameObject SController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MyPos = this.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);

        if(Hp > 0)
        {
            //中央を向くプログラム
            LookCenter();
            //歩いてくるプログラム
            walkEnemy(dis);
            //ジャンプ
            if (this.gameObject.name == "[Origin]Ghoul(Clone)" || this.gameObject.name == "[Origin]UltGhoul(Clone)") Jump(dis);
            //横歩き
            if (this.gameObject.name == "[Origin]Giant(Clone)" || this.gameObject.name == "[Origin]UltGiant(Clone)") LeftWalk(dis);
            //攻撃プログラム
            EnemAttack(dis);
        }
        //死亡時
        die();
    }


    public void LookCenter()
    {
        var direction = lookTarget.transform.position - transform.position;
        direction.y = 0;
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 100);   
    }

    public void walkEnemy(float dis)
    {
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

    public void Jump(float dis)
    {
        if(JumpCT <= 10) JumpCT += Time.deltaTime;
        if (dis > 10.0f && JumpCT > 5) rb.AddForce(new Vector3(0, 100f, 0)); //上に向かって力を加える
        if (JumpCT >5.25f) JumpCT = 0;
    }

    public void LeftWalk(float dis)
    {
        if (JumpCT <= 10) JumpCT += Time.deltaTime;
        if (dis > 8.0f && JumpCT < 3) rb.AddForce(new Vector3(3, 0, 3)); //横に向かって力を加える
        if (dis > 8.0f && JumpCT >= 3 && JumpCT < 6) rb.AddForce(new Vector3(-3, 0, -3)); //横に向かって力を加える
        if (JumpCT >= 6) JumpCT = 0;
    }

    public void EnemAttack(float dis)
    {
        if (dis <= 4.0f)
        {
            PlayerDamageCT -= Time.deltaTime;

            if(EffectTime > 0)
            {
                EffectTime -= Time.deltaTime;
                Blood.SetActive(true);
            }
            else Blood.SetActive(false);


            if (PlayerDamageCT <= 0)
            {
                EffectTime = 1;
                SController.GetComponent<ShotController>().Damage();
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

    public int HitShot(float Damage)
    {
        Hp -= (int)(Damage * PlayerStatus.GunDamage[PlayerStatus.GunMode]);
        return Hp;
    }

}