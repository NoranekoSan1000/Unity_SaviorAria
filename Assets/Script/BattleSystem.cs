using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audios;

    public GameObject Zombie;
    public GameObject Ghoul;
    public GameObject Giant;
    public GameObject[] Spawner = new GameObject[7];
    float SpawnCoolTime = 3;

    public bool GameChanger;//phase�؂�ւ��̃^�C�~���O
    int spawnCount = 0;//�G�o���^�C�~���O
    int PhaseBGM=0;
    public static int EnemyAmount = 0;

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
        if (PlayerStatus.GamePhase == 2) Phase2();
        if (PlayerStatus.GamePhase == 3) Phase3();
        if (PlayerStatus.GamePhase == 4) Phase4();

        if (GameChanger)
        {
            PlayerStatus.GamePhase += 1;
            if (PlayerStatus.GamePhase == 5 || PlayerStatus.GamePhase == 9 || PlayerStatus.GamePhase == 13)
            {
                PhaseBGM += 1;
                audios.clip = BGM[PhaseBGM];
                audios.Play();
            }
            PlayerStatus.textTime = -1;
            spawnCount = 0;
            SpawnCoolTime = 5;
            GameChanger = false;
        }
    }

    void Phase1()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //�S�Ă̓G���S��
        if(spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0)
        {
            GameChanger = true;
        }
    }
    void Phase2()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //�S�Ă̓G���S��
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0)
        {
            GameChanger = true;
        }
    }
    void Phase3()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //�S�Ă̓G���S��
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0)
        {
            GameChanger = true;
        }
    }
    void Phase4()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //�S�Ă̓G���S��
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0)
        {
            GameChanger = true;
        }
    }

    public void EnemSpawn(int id, int i)
    {
        if (id == 0)//�]���r����
        {
            GameObject Copy_Zombie = Instantiate(Zombie) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 1)//�O�[������
        {
            GameObject Copy_Zombie = Instantiate(Ghoul) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 2)//�W���C�A���g����
        {
            GameObject Copy_Zombie = Instantiate(Giant) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
    }

}
