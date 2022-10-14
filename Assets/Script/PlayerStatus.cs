using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static bool GameStart;
    public static float GameTime;

    public static int GunMode = 0;
    public static int Ammo = 20;
    public static int Score;
    public static int PlayerHP;
    public static int[] GunAmmo = new int[4] { 12, 64, 21, 8 };
    public static int[] GunDamage = new int[4] { 2, 1, 3, 8 };

    public static bool Reloading = false;
    public static float ReloadTime = 0;
    

    public Text LeftAmmoText;
    public Text LeftTimeText;
    public Text ScoreText;
    public Text PlayerHPText;

    public GameObject Zombie;
    public GameObject Spawner;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Spawner6;
    public GameObject Spawner7;

    float SpawnCoolTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        FadeController.isFadeIn = true;
        GameStart = false;
        GameTime = 30;
        Score = 0;
        PlayerHP = 20;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //開始前
        if (!GameStart) Score = 0;
        //ゲーム開始
        if (GameStart && GameTime > 0) GameTime -= Time.deltaTime;
        //ゲーム終了
        if (GameTime <= 0) GameTime = 0;
        */


        string st = GameTime.ToString("0.0");
        LeftTimeText.text = st;
        ScoreText.text = Score + "";
        PlayerHPText.text = PlayerHP + "";

        LeftAmmoText.text = "Ammo : " + Ammo;
        if (ReloadTime > 0 && Reloading)
        {
            ReloadTime -= Time.deltaTime;
        }
        if (ReloadTime < 0 && Reloading)
        {
            Ammo = GunAmmo[GunMode];
            Reloading = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) || Input.GetMouseButtonDown(1))
        {
            Ammo = 0;
            if (GunMode < 3) GunMode++;
            else GunMode = 0;
        }

        if(PlayerHP <= 0)
        {
            FadeController.isFadeOut = true;
            PlayerHPText.text = "Game Over";
        }
        if(Input.GetKeyDown(KeyCode.M) || SpawnCoolTime <= 0)
        {
            GameObject Copy_Zombie = Instantiate(Zombie) as GameObject;
            Copy_Zombie.tag = "Untagged";
            Copy_Zombie.transform.position = Spawner.transform.position;
            Vector3 force;
            force = Spawner.transform.forward * 1;
            Copy_Zombie.GetComponent<Rigidbody>().AddForce(force);

            GameObject Copy_Zombie2 = Instantiate(Zombie) as GameObject;
            Copy_Zombie2.tag = "Untagged";
            Copy_Zombie2.transform.position = Spawner2.transform.position;
            force = Spawner2.transform.forward * 1;
            Copy_Zombie2.GetComponent<Rigidbody>().AddForce(force);

            GameObject Copy_Zombie3 = Instantiate(Zombie) as GameObject;
            Copy_Zombie3.tag = "Untagged";
            Copy_Zombie3.transform.position = Spawner3.transform.position;
            force = Spawner3.transform.forward * 1;
            Copy_Zombie3.GetComponent<Rigidbody>().AddForce(force);

            GameObject Copy_Zombie4 = Instantiate(Zombie) as GameObject;
            Copy_Zombie4.tag = "Untagged";
            Copy_Zombie4.transform.position = Spawner4.transform.position;
            force = Spawner4.transform.forward * 1;
            Copy_Zombie4.GetComponent<Rigidbody>().AddForce(force);


            SpawnCoolTime = 18;
        }

        SpawnCoolTime -= Time.deltaTime;

    }
}


    


