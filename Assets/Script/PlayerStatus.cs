using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static int GunMode = 0;
    public static int GamePhase = 1;
    public static int Ammo = 20;
    public static int Score;
    public static int PlayerHP;
    public static int[] GunCapacity = new int[4] { 16, 45, 22, 7 };
    public static int[] GunDamage = new int[4] { 3, 2, 4, 15 };

    public static bool Reloading = false;
    public static float ReloadTime = 0;
    
    public Text CapacityText;
    public Text CapacityText3;
    //public Text LeftTimeText;

    public Text ScoreText;
    string score_6digits;

    public Text PlayerHPText;

    public Text PhaseText;
    public static float textTime = -2;

    // Start is called before the first frame update
    void Start()
    {
        FadeController.isFadeIn = true;
        GunMode = 0;
        GamePhase = 1;
        Score = 0;
        Ammo = 20;
        PlayerHP = 20;
        Reloading = false;

        PhaseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
       // string st = GameTime.ToString("0.0");
        //LeftTimeText.text = st;

        score_6digits = Score.ToString("D6");
        ScoreText.text = score_6digits + "";

        PlayerHPText.text = PlayerHP + "";

        //Phase表示
        DispPhaseText();

        CapacityText.text =": "+ Ammo;

        CapacityText3.text = "";
        for(int i=0;i< Ammo;i++) CapacityText3.text += 'l';

        //リロード：GunAngles.csによって管理
        if (ReloadTime > 0 && Reloading)
        {
            ReloadTime -= Time.deltaTime;
        }
        if (ReloadTime < 0 && Reloading)
        {
            Ammo = GunCapacity[GunMode];
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

    char[] phaseChar = new char[7] {' ', 'P', 'h', 'a', 's', 'e', ' ' };
    char[] phaseChar2 = new char[14] { ' ', 'F', 'i', 'n', 'a', 'l', ' ', 'P', 'h', 'a', 's', 'e', ' ', '-' };

    void DispPhaseText()
    {
        if (textTime < 5f) textTime += Time.deltaTime;

        if(GamePhase != 16)
        {
            
            if (textTime > 0.08f) PhaseText.text = "-";
            for (int i = 0; i < 7; i++) if (textTime > 0.08f * (i + 2)) PhaseText.text += phaseChar[i];

            if (GamePhase < 10)
            {
                if (textTime > 0.72f) PhaseText.text = "- Phase " + GamePhase;
                if (textTime > 0.80f) PhaseText.text = "- Phase " + GamePhase + " ";
                if (textTime > 0.88f) PhaseText.text = "- Phase " + GamePhase + " -";
                if (textTime > 3f) PhaseText.text = "";
            }
            else
            {
                if (textTime > 0.72f) PhaseText.text = "- Phase " + GamePhase / 10;
                if (textTime > 0.80f) PhaseText.text = "- Phase " + GamePhase;
                if (textTime > 0.88f) PhaseText.text = "- Phase " + GamePhase + " ";
                if (textTime > 0.96f) PhaseText.text = "- Phase " + GamePhase + " -";
                if (textTime > 3f) PhaseText.text = "";
            }
        }
        else
        {
            if (textTime > 0.08f) PhaseText.text = "-";
            for (int i = 0; i < 14; i++) if (textTime > 0.08f * (i + 2)) PhaseText.text += phaseChar2[i];
            if (textTime > 3f) PhaseText.text = "";
        }

    }
}


    


