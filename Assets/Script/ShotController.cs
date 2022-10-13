using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Bullet;
    public Camera ScopeCamera;

    public GameObject P90;
    public GameObject AWP;

    public AudioClip SE_Shot;
    public AudioClip SE_SniperShot;
    public AudioClip SE_NoAmmo;
    AudioSource audioSource;

    public int bulletNUM;
    float CoolTime=0;
    float scopemode = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatus.GunMode == 0)
        {
            P90.SetActive(false);
            AWP.SetActive(false);
        }
        if (PlayerStatus.GunMode == 1)
        {
            P90.SetActive(true);
            AWP.SetActive(false);
        }
        if (PlayerStatus.GunMode == 2)
        {
            P90.SetActive(false);
            AWP.SetActive(true);
        }


        if (PlayerStatus.Ammo > 0)
        {
            //ハンドガン
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading && PlayerStatus.GunMode == 0)
            {
                PlayerStatus.Ammo -= 1;
                audioSource.PlayOneShot(SE_Shot);
                GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
                Copy_Shot.tag = "Shot";
                Copy_Shot.transform.position = Bullet.transform.position;
                Vector3 force;
                force = Bullet.transform.forward * 2500;
                Copy_Shot.GetComponent<Rigidbody>().AddForce(force);

            }

            //サブマシンガン
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading && PlayerStatus.GunMode == 1 && CoolTime <= 0)
            {
                PlayerStatus.Ammo -= 1;
                audioSource.PlayOneShot(SE_Shot);
                GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
                Copy_Shot.tag = "Shot";
                Copy_Shot.transform.position = Bullet.transform.position;
                Vector3 force;
                force = Bullet.transform.forward * 2000;
                Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
                CoolTime = 0.05f;
            }
            if(CoolTime > 0)CoolTime -= Time.deltaTime;

            //スナイパー
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading && PlayerStatus.GunMode == 2 && CoolTime <= 0)
            {
                PlayerStatus.Ammo -= 1;
                audioSource.PlayOneShot(SE_SniperShot);
                GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
                Copy_Shot.tag = "Shot";
                Copy_Shot.transform.position = Bullet.transform.position;
                Vector3 force;
                force = Bullet.transform.forward * 5000;
                Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
                CoolTime = 1.5f;

            }
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                if (scopemode < 4) scopemode++;
                else scopemode = 0;
            }
            if(scopemode == 0) ScopeCamera.fieldOfView = 60.5f;
            if(scopemode == 1) ScopeCamera.fieldOfView = 20.5f;
            if (scopemode == 2) ScopeCamera.fieldOfView = 5.5f;
            if (scopemode == 3) ScopeCamera.fieldOfView = 1.5f;
            if (scopemode == 4) ScopeCamera.fieldOfView = 0.7f;
        }
        else
        {
           if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading)
                audioSource.PlayOneShot(SE_NoAmmo);
        }
        
    }
}
