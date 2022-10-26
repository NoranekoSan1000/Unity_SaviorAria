using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShot : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Gun;

    public GameObject PM_40;

    public AudioClip SE_Shot;
    AudioSource audioSource;

    float CoolTime=0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PM_40.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (CoolTime > 0) CoolTime -= Time.deltaTime;

        if (TitleStatus.TitleAmmo > 0)
        {
            if (CoolTime <= 0) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);//U“®ƒXƒgƒbƒv
            //ƒnƒ“ƒhƒKƒ“
            if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetMouseButtonDown(2)))
            {
                audioSource.PlayOneShot(SE_Shot);
                OVRInput.SetControllerVibration(1f, 0.3f, OVRInput.Controller.RTouch);//U“®
                SelectShot(1500, 0);
            }
        }
    }

    public void SelectShot(int Speed,float CT)
    {
        Vector3 force;
        PlayerStatus.Ammo -= 1;
        GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
        Copy_Shot.tag = "Shot";
        Copy_Shot.transform.position = Gun.transform.position;
        force = Gun.transform.forward * Speed;
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        CoolTime = CT;
    }

}
