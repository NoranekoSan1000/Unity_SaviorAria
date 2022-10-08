using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Bullet;

    public AudioClip SE_Shot;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            audioSource.PlayOneShot(SE_Shot);
            GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
            Copy_Shot.tag = "Shot";
            Copy_Shot.transform.position = Bullet.transform.position;
            Vector3 force;
            force = Bullet.transform.forward * 1000;
            Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
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
