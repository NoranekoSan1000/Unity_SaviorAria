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
        Debug.Log(spawnCount);
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
            PlayerStatus.Score += PlayerStatus.GamePhase * 100;
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
            //zombie x4
            if (spawnCount == 0 && SpawnCoolTime <= 0)
            {
                EnemSpawn(2, 1);
                spawnCount += 1;
                SpawnCoolTime = 3;
            }
            if (spawnCount == 1 && SpawnCoolTime <= 0)
            {
                EnemSpawn(1, 4);
                spawnCount += 1;
                SpawnCoolTime = 3;
            }
            if (spawnCount == 2 && SpawnCoolTime <= 0)
            {
                EnemSpawn(0, 7);
                spawnCount += 1;
                SpawnCoolTime = 3;
            }
            if (spawnCount == 3 && SpawnCoolTime <= 0)
            {
                EnemSpawn(0, 10);
                spawnCount += 1;
                SpawnCoolTime = 3;
            }

        //ëSÇƒÇÃìGéÄñSå„
        if(spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase2()
    {
        //zombie x8
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 7);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 1; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }

        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 5 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase3()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 2 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase4()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            EnemSpawn(0, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            EnemSpawn(0, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase5()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 3; i < 6; i++)EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            for (int i = 9; i < 12; i++) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 4; i < 11; i+=6) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }

        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 5 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase6()
    {
        //zombie x12
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 0);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 6);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 7);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 6 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 3);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 7 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 8 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 9 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 9);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 10 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 11 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 12 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 13 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 5);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 14 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 8);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        if (spawnCount == 15 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }

        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 16 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase7()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 0);
            EnemSpawn(1, 2);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 6);
            EnemSpawn(1, 8);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 3);
            EnemSpawn(1, 5);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 9);
            EnemSpawn(1, 11);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 6 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase8()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            EnemSpawn(2, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            EnemSpawn(2, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            EnemSpawn(2, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            EnemSpawn(2, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase9()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            EnemSpawn(0, 3);
            EnemSpawn(1, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            EnemSpawn(0, 9);
            EnemSpawn(1, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase10()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase11()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase12()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase13()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase14()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase15()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void FinalPhase()
    {
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            EnemSpawn(1, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 4);
            EnemSpawn(2, 3);
            EnemSpawn(2, 5);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 7);
            EnemSpawn(1, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 10);
            EnemSpawn(2, 9);
            EnemSpawn(2, 11);
            spawnCount += 1;
            SpawnCoolTime = 4;
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
