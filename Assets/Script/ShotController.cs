using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Bullet;
    public Camera ScopeCamera;

    public GameObject PM_40;
    public GameObject P90;
    public GameObject M4A1;
    public GameObject AWP;

    public AudioClip SE_Shot;
    public AudioClip SE_SniperShot;
    public AudioClip SE_BoltAction;
    public AudioClip SE_NoAmmo;
    AudioSource audioSource;

    float CoolTime=0;

    float[] Focus = new float[5] { 60.5f, 20.5f, 5.5f, 1.5f, 0.7f };
    int scopemode = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //武器スキン切り替え
        if (PlayerStatus.GunMode == 0) SkinActive(true,false,false,false);
        if (PlayerStatus.GunMode == 1) SkinActive(false,true,false,false);
        if (PlayerStatus.GunMode == 2) SkinActive(false,false,true,false);
        if (PlayerStatus.GunMode == 3) SkinActive(false,false,false,true);

        if (CoolTime > 0) CoolTime -= Time.deltaTime;

        if (PlayerStatus.Ammo > 0 && !PlayerStatus.Reloading)
        {
            if (CoolTime <= 0) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);//振動ストップ

            //ハンドガン
            if (PlayerStatus.GunMode == 0 && (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetMouseButtonDown(0)))
            {
                audioSource.PlayOneShot(SE_Shot);
                OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);//振動
                SelectShot(1500, 0);
            }

            //サブマシンガン
            if (PlayerStatus.GunMode == 1 && CoolTime <= 0 && (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || Input.GetMouseButton(0)))
            {
                audioSource.PlayOneShot(SE_Shot);
                OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);//振動
                SelectShot(1000, 0.075f);
            }

            //アサルトライフル
            if ( PlayerStatus.GunMode == 2 && CoolTime <= 0 && (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || Input.GetMouseButton(0)))
            {
                audioSource.PlayOneShot(SE_Shot);
                OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);//振動
                SelectShot(1800, 0.12f);
            }

            //スナイパー
            if (PlayerStatus.GunMode == 3 && CoolTime <= 0 && (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetMouseButtonDown(0)))
            {
                audioSource.PlayOneShot(SE_SniperShot);
                OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);//振動
                if(PlayerStatus.Ammo > 1) SelectShot(3000, 5f);
                else SelectShot(3000, 2f);
            }

            //コッキング効果音
            if (CoolTime <= 4.8f && CoolTime > 3.5f)
            {
                audioSource.PlayOneShot(SE_BoltAction);
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);//振動ストップ
                CoolTime = 1.0f;
            }

            //スコープ拡大
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || Input.GetKeyDown(KeyCode.Z))
            {
                if (scopemode < 4) scopemode++;
                else scopemode = 0;
            }

            ScopeCamera.fieldOfView = Focus[scopemode];
        }
        //弾切れ
        if(PlayerStatus.Ammo <= 0 && (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)|| Input.GetMouseButtonDown(0)) && !PlayerStatus.Reloading)
            audioSource.PlayOneShot(SE_NoAmmo);
        
    }

    public void SkinActive(bool a,bool b,bool c,bool d)
    {
        PM_40.SetActive(a);
        P90.SetActive(b);
        M4A1.SetActive(c);
        AWP.SetActive(d);
    }

    public void SelectShot(int Speed,float CT)
    {
        Vector3 force;
        PlayerStatus.Ammo -= 1;
        GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
        Copy_Shot.tag = "Shot";
        Copy_Shot.transform.position = Bullet.transform.position;    
        force = Bullet.transform.forward * Speed;
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        CoolTime = CT;
    }

}
