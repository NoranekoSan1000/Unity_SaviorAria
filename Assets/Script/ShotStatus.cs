using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStatus : MonoBehaviour
{
    float DestroyTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Shot")//origin‚É‚Í‰e‹¿‚ð—^‚¦‚È‚¢
        {
            DestroyTimer += Time.deltaTime;               
        }
        //5•bŒãÁ–Å
        if (DestroyTimer > 5) Destroy(this.gameObject);
    }
}
