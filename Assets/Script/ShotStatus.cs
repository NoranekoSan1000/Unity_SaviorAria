using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStatus : MonoBehaviour
{
    public GameObject CenterEyeAnchor;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localEulerAngles = CenterEyeAnchor.transform.localEulerAngles;

        if (this.gameObject.tag == "Shot")//origin‚É‚Í‰e‹¿‚ð—^‚¦‚È‚¢
        {
            Destroy(this.gameObject, 6.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
