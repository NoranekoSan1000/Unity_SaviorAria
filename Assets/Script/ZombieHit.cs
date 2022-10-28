using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    bool HeadHit;
    bool BodyHit;
    public AudioClip SE_HeadShot;
    public AudioClip SE_BodyShot;
    AudioSource audioSource;

    public GameObject Zomb;
    private int ThisHp=10;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ThisHp <= 0)
        {
            Destroy(this.gameObject, 0.5f);       
        }
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Shot")
        {
            if (this.gameObject.tag == "ZombieHead" && !HeadHit)
            {
                HeadHit = true;
                audioSource.PlayOneShot(SE_HeadShot);
                ThisHp = Zomb.GetComponent<Zombie>().HitShot(1.75f);
                HeadHit = false;
            }
            if (this.gameObject.tag == "ZombieBody" && !BodyHit)
            {
                BodyHit = true;
                audioSource.PlayOneShot(SE_BodyShot);
                ThisHp =Zomb.GetComponent<Zombie>().HitShot(1);
                BodyHit = false;
            }
        }
    }
}
