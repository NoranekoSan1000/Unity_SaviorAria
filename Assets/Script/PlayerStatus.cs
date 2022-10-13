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
    public static int[] GunAmmo = new int[3] {20,68,7};
    public static bool Reloading = false;
    public static float ReloadTime = 0;
    public static int Score;

    public Text LeftAmmoText;
    public Text LeftTimeText;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameStart = false;
        GameTime = 30;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //開始前
        if (!GameStart) Score = 0;
        //ゲーム開始
        if (GameStart && GameTime > 0) GameTime -= Time.deltaTime;
        //ゲーム終了
        if (GameTime <= 0) GameTime = 0;



        string st = GameTime.ToString("0.0");
        LeftTimeText.text = st;
        ScoreText.text = Score + "";

        LeftAmmoText.text = "Ammo : " + Ammo;
        if(ReloadTime > 0 && Reloading)
        {
            ReloadTime -= Time.deltaTime;
        }
        if(ReloadTime < 0 && Reloading)
        {
            Ammo = GunAmmo[GunMode];
            Reloading = false;
        }

        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) || Input.GetMouseButtonDown(1))
        {
            Ammo = 0;
            if (GunMode < 2) GunMode++;
            else GunMode = 0;
        }
    }
}
