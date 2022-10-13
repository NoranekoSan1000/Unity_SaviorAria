using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStatus : MonoBehaviour
{
    float DestroyTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Shot")//origin�ɂ͉e����^���Ȃ�
        {
            DestroyTimer += Time.deltaTime;
        }
        //5�b�����
        if (DestroyTimer > 6) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
