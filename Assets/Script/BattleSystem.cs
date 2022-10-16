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

    public bool GameChanger;
    int PhaseBGM=0;

    Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        //BGM
        audios = GetComponent<AudioSource>();
        audios.clip = BGM[PlayerStatus.GunMode];
        audios.Play();

        Phase1();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameChanger)
        {
            PlayerStatus.GamePhase += 1;
            PlayerStatus.textTime = 0;
            if (PlayerStatus.GamePhase == 4 || PlayerStatus.GamePhase == 8 || PlayerStatus.GamePhase == 12)
            {
                PhaseBGM += 1;
                audios.clip = BGM[PhaseBGM];
                audios.Play();
            }
            GameChanger = false;
        }
    }

    void Phase1()
    {
        if (SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3)
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
