using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject Origin_Shot;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            Debug.Log("Shot Success");
            GameObject Copy_Shot = Instantiate(Origin_Shot) as GameObject;
            Copy_Shot.tag = "Shot";
            Copy_Shot.transform.position = Bullet.transform.position;
            Vector3 force;
            force = Bullet.transform.forward * 1;
            Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
