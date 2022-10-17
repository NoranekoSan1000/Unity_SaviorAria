using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audios;

    public GameObject Zombie;
    public GameObject Ghoul;
    public GameObject Giant;
    public GameObject[] Spawner = new GameObject[7];
    float SpawnCoolTime = 3;

    public bool GameChanger;//phaseêÿÇËë÷ÇÌÇËÇÃÉ^ÉCÉ~ÉìÉO
    int spawnCount = 0;//ìGèoåªÉ^ÉCÉ~ÉìÉO
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
        if (PlayerStatus.GamePhase == 5) Phase5();
        if (PlayerStatus.GamePhase == 6) Phase6();
        if (PlayerStatus.GamePhase == 7) Phase7();
        if (PlayerStatus.GamePhase == 8) Phase8();
        if (PlayerStatus.GamePhase == 9) Phase9();
        if (PlayerStatus.GamePhase == 10) Phase10();
        if (PlayerStatus.GamePhase == 11) Phase11();
        if (PlayerStatus.GamePhase == 12) Phase12();
        if (PlayerStatus.GamePhase == 13) Phase13();
        if (PlayerStatus.GamePhase == 14) Phase14();
        if (PlayerStatus.GamePhase == 15) Phase15();
        if (PlayerStatus.GamePhase == 16) FinalPhase();

        if (GameChanger)
        {
            PlayerStatus.GamePhase += 1;
            if (PlayerStatus.GamePhase == 17)
            {
                FadeController.isFadeOut=true;
                SpawnCoolTime = 4;
                GameChanger = false;
            }
            else
            {               
                if (PlayerStatus.GamePhase == 5 || PlayerStatus.GamePhase == 9 || PlayerStatus.GamePhase == 13)
                {
                    //BGMêÿÇËë÷ÇÌÇËÉ^ÉCÉ~ÉìÉO
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

        if (PlayerStatus.GamePhase == 17 && SpawnCoolTime <= 0) SceneManager.LoadScene("Result");
    }

    void Phase1()
    {
        if(spawnCount != 4 && SpawnCoolTime <= 0)
        {
            if (spawnCount == 0)
            {
                EnemSpawn(0, 1);
                SpawnCoolTime = 3;
            }
            if (spawnCount == 1)
            {
                EnemSpawn(0, 4);
                SpawnCoolTime = 3;
            }
            if (spawnCount == 2)
            {
                EnemSpawn(0, 7);
                SpawnCoolTime = 3;
            }
            if (spawnCount == 3)
            {
                EnemSpawn(0, 10);
                SpawnCoolTime = 3;
            }
            spawnCount += 1;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if(spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase5()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase6()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase7()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase8()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase9()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase10()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase11()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase12()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase13()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase14()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase15()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void FinalPhase()
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
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }


    public void EnemSpawn(int id, int i)
    {
        if (id == 0)//É]ÉìÉrè¢ä´
        {
            GameObject Copy_Zombie = Instantiate(Zombie) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 1)//ÉOÅ[Éãè¢ä´
        {
            GameObject Copy_Zombie = Instantiate(Ghoul) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 2)//ÉWÉÉÉCÉAÉìÉgè¢ä´
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
