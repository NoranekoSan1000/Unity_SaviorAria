using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour
{
    public Text[] score_text = new Text[7]; // Textオブジェクト
    public static int[] Ranking = new int[7];//取得用
    public int[] SaveRanking = new int[7];//保存用

    public static bool FirstStart=false;//開始時はUpdateしない

    // 初期化時の処理
    void Start()
    {
        // スコアのロード
        for (int i = 0; i < 7; i++)
        {
            SaveRanking[i] = PlayerPrefs.GetInt("SCORE" + i, 0);
        }
        if (!FirstStart)
            for (int i = 0; i < 7; i++)
            {
                Ranking[i] = SaveRanking[i];
            }

    }
    // 削除時の処理
    void OnDestroy()
    {
        // スコアを保存
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, SaveRanking[i]);
        }
        PlayerPrefs.Save();
    }

    // 更新
    void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            SaveRanking[i] = Ranking[i];
        }

        score_text[0].text = "1st : " + SaveRanking[0] + "\n  " ;
        score_text[1].text = "2nd : " + SaveRanking[1] + "\n  " ;
        score_text[2].text = "3rd : " + SaveRanking[2] + "\n  " ;
        score_text[3].text = "4th : " + SaveRanking[3] + "\n  " ;
        score_text[4].text = "5th : " + SaveRanking[4] + "\n  " ;
        score_text[5].text = "6th : " + SaveRanking[5] + "\n  ";
        score_text[6].text = "7th : " + SaveRanking[6] + "\n  ";

    }
}