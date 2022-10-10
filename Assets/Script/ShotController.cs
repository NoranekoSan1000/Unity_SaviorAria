using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Bullet;

    public AudioClip SE_Shot;
    public AudioClip SE_NoAmmo;
    AudioSource audioSource;

    public int bulletNUM;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.Ammo > 0)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading && bulletNUM == 0)
            {
                PlayerStatus.Ammo -= 1;
                audioSource.PlayOneShot(SE_Shot);
                GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
                Copy_Shot.tag = "Shot";
                Copy_Shot.transform.position = Bullet.transform.position;
                Vector3 force;
                force = Bullet.transform.forward * 1000;
                Copy_Shot.GetComponent<Rigidbody>().AddForce(force);

            }
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && !PlayerStatus.Reloading && bulletNUM == 1)
            {
                PlayerStatus.Ammo -= 1;
                audioSource.PlayOneShot(SE_Shot);
                GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
                Copy_Shot.tag = "Shot";
                Copy_Shot.transform.position = Bullet.transform.position;
                Vector3 force;
                force = Bullet.transform.forward * 1000;
                Copy_Shot.GetComponent<Rigidbody>().AddForce(force);

            }
        }
        else
        {
           if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && !PlayerStatus.Reloading)
                audioSource.PlayOneShot(SE_NoAmmo);
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && !PlayerStatus.Reloading)
                audioSource.PlayOneShot(SE_NoAmmo);
        }
        

        //keyboard—p
        if(Input.GetKey(KeyCode.T))
        {
            audioSource.PlayOneShot(SE_Shot);
            GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
            Copy_Shot.tag = "Shot";
            Copy_Shot.transform.position = Bullet.transform.position;
            Vector3 force;
            force = Bullet.transform.forward * 1;
            Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
