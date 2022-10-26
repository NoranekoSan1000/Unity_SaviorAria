using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStatus : MonoBehaviour
{
    public GameObject LeftHandAnchor;
    public GameObject RightHandAnchor;

    // Update is called once per frame
    void Update()
    {
        if(this .gameObject.name == "[Origin]ShotL(Clone)")this.gameObject.transform.localEulerAngles = LeftHandAnchor.transform.localEulerAngles;
        else this.gameObject.transform.localEulerAngles = RightHandAnchor.transform.localEulerAngles;

        if (this.gameObject.tag == "Shot")//origin‚É‚Í‰e‹¿‚ð—^‚¦‚È‚¢
        {
            Destroy(this.gameObject, 6.0f);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        Destroy(this.gameObject);
    }
}
