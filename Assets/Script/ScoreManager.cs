using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour
{
    public Text[] score_text = new Text[9]; // Textオブジェクト
    public static int[] Ranking = new int[9];//取得用
    public int[] SaveRanking = new int[9];//保存用

    public static string[] Name = new string[9];//取得用
    public string[] SaveName = new string[9];//保存用

    public Text PlayCountText;
    public static int PlayCount;
    public int SavePlayCount;

    public static bool FirstStart=false;//開始時はUpdateしない

    // 初期化時の処理
    void Start()
    {
        // スコアのロード
        for (int i = 0; i < 9; i++)
        {
            SaveRanking[i] = PlayerPrefs.GetInt("SCORE" + i, 0);
            SaveName[i] = PlayerPrefs.GetString("NAME" + i, "-----");
        }
        SavePlayCount = PlayerPrefs.GetInt("PlayCount", 0);

        if (!FirstStart)
        {
            for (int i = 0; i < 9; i++)
            {
                Ranking[i] = SaveRanking[i];
                Name[i] = SaveName[i];
            }
            PlayCount = SavePlayCount;
        }
            

    }
    // 削除時の処理
    void OnDestroy()
    {
        // スコアを保存
        for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, SaveRanking[i]);
            PlayerPrefs.SetString("NAME" + i, SaveName[i]);
        }
        PlayerPrefs.SetInt("PlayCount", SavePlayCount);
        PlayerPrefs.Save();
    }

    // 更新
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            SaveRanking[i] = Ranking[i];
            SaveName[i] = Name[i];
        }
        SavePlayCount = PlayCount;

        PlayCountText.text = "Gameplayed : " + SavePlayCount;
        score_text[0].text = "1st : " + SaveName[0] + " " + SaveRanking[0] + "\n  " ;
        score_text[1].text = "2nd : " + SaveName[1] + " " + SaveRanking[1] + "\n  " ;
        score_text[2].text = "3rd : " + SaveName[2] + " " + SaveRanking[2] + "\n  " ;
        score_text[3].text = "4th : " + SaveName[3] + " " + SaveRanking[3] + "\n  " ;
        score_text[4].text = "5th : " + SaveName[4] + " " + SaveRanking[4] + "\n  " ;
        score_text[5].text = "6th : " + SaveName[5] + " " + SaveRanking[5] + "\n  ";
        score_text[6].text = "7th : " + SaveName[6] + " " + SaveRanking[6] + "\n  ";
        score_text[7].text = "8th : " + SaveName[7] + " " + SaveRanking[7] + "\n  ";
        score_text[8].text = "9th : " + SaveName[8] + " " + SaveRanking[8] + "\n  ";

    }
}