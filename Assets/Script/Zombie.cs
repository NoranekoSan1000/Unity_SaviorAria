using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;  //Animatorをanimという変数で定義する
    public GameObject lookTarget;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

        lookTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        lookTarget.transform.position = new Vector3(0, 2f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //中央を向くプログラム
        LookCenter();

        //歩いてくるプログラム
        Vector3 MyPos = this.gameObject.transform.position;
        Vector3 CenterPos = lookTarget.transform.position;
        float dis = Vector3.Distance(MyPos, CenterPos);
        if(dis > 3.5f) walkEnemy();
    }
    
    
    public void LookCenter()
    {
        if (lookTarget)
        {
            var direction = lookTarget.transform.position - transform.position;
            direction.y = 0;

            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        }
    }

    public void walkEnemy()
    {
        anim.SetBool("IsWalking", true);
        
        transform.position += transform.forward * 1.0f * Time.deltaTime;

    }
}
