using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    bool HeadHit;
    bool BodyHit;

    public GameObject Zomb;

    void Start()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            if (this.gameObject.tag == "ZombieHead" && !HeadHit)
            {
                HeadHit = true;
                Zomb.GetComponent<Zombie>().HitShot(3);
                HeadHit = false;
            }
            if (this.gameObject.tag == "ZombieBody" && !BodyHit)
            {
                BodyHit = true;
                Zomb.GetComponent<Zombie>().HitShot(1);
                BodyHit = false;
            }
        }
    }
}
