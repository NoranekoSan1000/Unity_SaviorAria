using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    public static bool HeadHit;
    public static bool BodyHit;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            if (this.gameObject.tag == "ZombieHead" && !HeadHit)
            {
                HeadHit = true;
            }
            if (this.gameObject.tag == "ZombieBody" && !BodyHit)
            {
                BodyHit = true;
            }
        }
    }
}
