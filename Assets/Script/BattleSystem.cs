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
    public GameObject UltZombie;
    public GameObject UltGhoul;
    public GameObject UltGiant;
    public Transform ZombieBox;
    public GameObject[] Spawner = new GameObject[7];
    float SpawnCoolTime = 3;

    public GameObject[] AreaSmoke = new GameObject[4];

    public bool GameChanger;//phaseêÿÇËë÷ÇÌÇËÇÃÉ^ÉCÉ~ÉìÉO
    int spawnCount = 0;//ìGèoåªÉ^ÉCÉ~ÉìÉO
    int PhaseBGM=0;
    public static int EnemyAmount = 0;

    float deathCT=0;

    Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        GameChanger = false;
        SpawnCoolTime = 3;
        spawnCount = 0;
        PhaseBGM = 0;     
        EnemyAmount = 0;
        deathCT = 0;

        //BGM
        audios = GetComponent<AudioSource>();
        audios.clip = BGM[PhaseBGM];
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

        if (PlayerStatus.PlayerHP <= 0) deathCT += Time.deltaTime;
        if ((PlayerStatus.GamePhase == 17 && SpawnCoolTime <= 0) || deathCT > 4) SceneManager.LoadScene("Result");
    }

    void Phase1()
    {
        SetSmoke(false, true, true, true);
        //zombie x4
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if(spawnCount == 3 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase2()
    {
        SetSmoke(false, false, true, true);
        //zombie x8
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            EnemSpawn(0, 4);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 3 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase3()
    {
        SetSmoke(true, false, true, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            EnemSpawn(0, 9);
            EnemSpawn(0,11);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 3 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase4()
    {
        SetSmoke(true, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 4);
            EnemSpawn(0, 10);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            EnemSpawn(0, 9);
            EnemSpawn(0, 11);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            spawnCount += 1;
            SpawnCoolTime = 1;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase5()
    {
        SetSmoke(false, false, false, true);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            EnemSpawn(1, 7);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 3);
            EnemSpawn(0, 5);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 0);
            EnemSpawn(0, 6);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase6()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 1);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 0);
            EnemSpawn(0, 2);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 6);
            EnemSpawn(0, 8);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 6 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase7()
    {
        SetSmoke(false, false, true, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(0, 1);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 0);
            EnemSpawn(1, 2);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 5);
            EnemSpawn(1, 9);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 3);
            EnemSpawn(2, 11);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase8()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 1);
            EnemSpawn(2, 0);
            EnemSpawn(3, 2);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 4);
            EnemSpawn(3, 3);
            EnemSpawn(3, 5);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 7);
            EnemSpawn(2, 6);
            EnemSpawn(3, 8);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            EnemSpawn(3, 9);
            EnemSpawn(3, 11);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase9()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 7);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 0);
            EnemSpawn(3, 2);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 10);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 3);
            EnemSpawn(3, 5);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 6);
            EnemSpawn(3, 8);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 6 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 9);
            EnemSpawn(2, 4);
            EnemSpawn(3, 11);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 7 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase10()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(1, 2);
            EnemSpawn(1, 8);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 0);
            EnemSpawn(2, 6);
            spawnCount += 1;
            SpawnCoolTime = 7;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 1);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 1; i < 12; i += 3) EnemSpawn(3, i);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 5 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;

    }
    void Phase11()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(1, i);
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(1, i);
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase12()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(1, i);
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(3, i);
            spawnCount += 1;
            SpawnCoolTime = 9;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 6) EnemSpawn(4, i);
            EnemSpawn(2, 1);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 4 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase13()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 1);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 4);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 10);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            EnemSpawn(2, 0);
            EnemSpawn(2, 6);
            
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            EnemSpawn(5, 3);
            EnemSpawn(5, 9);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }

        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 6 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase14()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 1);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 4);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 7);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            EnemSpawn(3, 10);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(3, i);
            EnemSpawn(4, 1);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 3) EnemSpawn(3, i);
            EnemSpawn(4, 4);
            spawnCount += 1;
            SpawnCoolTime = 5;
        }
        if (spawnCount == 6 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 7);
            spawnCount += 1;
            SpawnCoolTime = 3;
        }
        if (spawnCount == 7 && SpawnCoolTime <= 0)
        {
            EnemSpawn(4, 10);
            spawnCount += 1;
            SpawnCoolTime = 2;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 8 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void Phase15()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 1; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 4; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 1; i < 12; i += 6) EnemSpawn(2, i);
            spawnCount += 1;
            SpawnCoolTime = 8;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            for (int i = 4; i < 12; i += 6) EnemSpawn(5, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 6 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
    void FinalPhase()
    {
        SetSmoke(false, false, false, false);
        if (spawnCount == 0 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 3) EnemSpawn(0, i);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        if (spawnCount == 1 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 3) EnemSpawn(3, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 2 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 6) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 3 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
        if (spawnCount == 4 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 6) EnemSpawn(2, i);
            for (int i = 4; i < 12; i += 6) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
        if (spawnCount == 5 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 6) EnemSpawn(5, i);
            for (int i = 1; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 6 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 6) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 6;
        }
        if (spawnCount == 7 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
        if (spawnCount == 8 && SpawnCoolTime <= 0)
        {
            for (int i = 0; i < 12; i += 6) EnemSpawn(2, i);
            for (int i = 4; i < 12; i += 6) EnemSpawn(1, i);
            spawnCount += 1;
            SpawnCoolTime = 10;
        }
        if (spawnCount == 9 && SpawnCoolTime <= 0)
        {
            for (int i = 2; i < 12; i += 6) EnemSpawn(5, i);
            for (int i = 1; i < 12; i += 6) EnemSpawn(4, i);
            spawnCount += 1;
            SpawnCoolTime = 4;
        }
        //ëSÇƒÇÃìGéÄñSå„
        if (spawnCount == 10 && SpawnCoolTime <= 0 && EnemyAmount == 0) GameChanger = true;
    }
   
    public void SetSmoke(bool a,bool b,bool c,bool d)
    {
        AreaSmoke[0].SetActive(a);
        AreaSmoke[1].SetActive(b);
        AreaSmoke[2].SetActive(c);
        AreaSmoke[3].SetActive(d);
    }

    public void EnemSpawn(int id, int i)
    {
        if (id == 0)//É]ÉìÉrè¢ä´
        {
            GameObject Copy_Zombie = Instantiate(Zombie, ZombieBox) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 1)//ÉOÅ[Éãè¢ä´
        {
            GameObject Copy_Zombie = Instantiate(Ghoul, ZombieBox) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 2)//ÉWÉÉÉCÉAÉìÉgè¢ä´
        {
            GameObject Copy_Zombie = Instantiate(Giant, ZombieBox) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 3)//É]ÉìÉrè¢ä´
        {
            GameObject Copy_UltZombie = Instantiate(UltZombie, ZombieBox) as GameObject;
            Copy_UltZombie.tag = "Untagged";
            Copy_UltZombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_UltZombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 4)//ÉOÅ[Éãè¢ä´
        {
            GameObject Copy_UltZombie = Instantiate(UltGhoul, ZombieBox) as GameObject;
            Copy_UltZombie.tag = "Untagged";
            Copy_UltZombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_UltZombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }
        if (id == 5)//ÉWÉÉÉCÉAÉìÉgè¢ä´
        {
            GameObject Copy_UltZombie = Instantiate(UltGiant, ZombieBox) as GameObject;
            Copy_UltZombie.tag = "Untagged";
            Copy_UltZombie.transform.position = Spawner[i].transform.position;
            force = Spawner[i].transform.forward * 0;
            Copy_UltZombie.GetComponent<Rigidbody>().AddForce(force);
            EnemyAmount++;
        }

    }

}
