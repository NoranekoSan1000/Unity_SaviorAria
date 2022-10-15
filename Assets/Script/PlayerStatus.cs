using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static bool GameStart;
    public static float GameTime;

    public static int GunMode = 0;
    public static int GamePhase = 13;
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
    string score_6digits;

    public Text PlayerHPText;

    public Text PhaseText;
    float textTime = -2;

    // Start is called before the first frame update
    void Start()
    {
        FadeController.isFadeIn = true;
        GameStart = false;
        GameTime = 30;
        Score = 0;
        PlayerHP = 20;

        PhaseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        string st = GameTime.ToString("0.0");
        LeftTimeText.text = st;

        score_6digits = Score.ToString("D6");
        ScoreText.text = score_6digits + "";

        PlayerHPText.text = PlayerHP + "";

        textTime += Time.deltaTime;
        if (textTime > 0.08f) PhaseText.text = "-";
        if (textTime > 0.16f) PhaseText.text = "- ";
        if (textTime > 0.24f) PhaseText.text = "- P";
        if (textTime > 0.32f) PhaseText.text = "- Ph";
        if (textTime > 0.40f) PhaseText.text = "- Pha";
        if (textTime > 0.48f) PhaseText.text = "- Phas";
        if (textTime > 0.56f) PhaseText.text = "- Phase";
        if (textTime > 0.64f) PhaseText.text = "- Phase ";
        if (GamePhase < 10)
        {
            if (textTime > 0.72f) PhaseText.text = "- Phase " + GamePhase;
            if (textTime > 0.80f) PhaseText.text = "- Phase " + GamePhase + " ";
            if (textTime > 0.88f) PhaseText.text = "- Phase " + GamePhase + " -";
        }
        else
        {
            if (textTime > 0.72f) PhaseText.text = "- Phase " + GamePhase / 10;
            if (textTime > 0.80f) PhaseText.text = "- Phase " + GamePhase;
            if (textTime > 0.88f) PhaseText.text = "- Phase " + GamePhase + " ";
            if (textTime > 0.96f) PhaseText.text = "- Phase " + GamePhase + " -";

            if (textTime > 3f) PhaseText.text = "";
        }
        
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

    }
}


    


