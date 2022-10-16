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

    public bool GameChanger;//phase切り替わりのタイミング
    int spawnCount = 0;//敵出現タイミング
    int PhaseBGM=0;

    Vector3 force;

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

        SpawnCoolTime -= Time.deltaTime;

        if (PlayerStatus.GamePhase == 1) Phase1();



        if (GameChanger)
        {
            PlayerStatus.GamePhase += 1;
            PlayerStatus.textTime = 0;
            if (PlayerStatus.GamePhase == 5 || PlayerStatus.GamePhase == 9 || PlayerStatus.GamePhase == 13)
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
        Debug.Log(spawnCount);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
    }

    public void EnemSpawn(int id, int i)
    {
        if (id == 0)//ゾンビ召喚
        {
            GameObject Copy_Zombie = Instantiate(Zombie) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
        }
        if (id == 1)//グール召喚
        {
            GameObject Copy_Zombie = Instantiate(Ghoul) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
        }
    }

}
