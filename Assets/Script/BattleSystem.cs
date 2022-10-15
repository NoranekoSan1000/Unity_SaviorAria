using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audios;

    public GameObject Zombie;
    public GameObject Ghoul;
    public GameObject[] Spawner = new GameObject[7];
    float SpawnCoolTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        //BGM
        audios = GetComponent<AudioSource>();
        audios.clip = BGM[PlayerStatus.GunMode];
        audios.Play();
    }

    // Update is called once per frame
    void Update()
    {

        /*audios.clip = BGM[PlayerStatus.GunMode];
        audios.Play();*/

        if (SpawnCoolTime <= 0)
        {
            Vector3 force;
            for (int i = 0; i < 12; i+=3)
            {
                GameObject Copy_Zombie = Instantiate(Zombie) as GameObject;
                Copy_Zombie.tag = "Untagged";
                Copy_Zombie.transform.position = Spawner[i].transform.position;
                force = Spawner[i].transform.forward * 1;
                Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            }
            SpawnCoolTime = 18;
        }
        SpawnCoolTime -= Time.deltaTime;

    }
}
