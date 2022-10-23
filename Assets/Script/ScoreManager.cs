using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ����܂��傤

public class ScoreManager : MonoBehaviour
{
    public Text[] score_text = new Text[9]; // Text�I�u�W�F�N�g
    public static int[] Ranking = new int[9];//�擾�p
    public int[] SaveRanking = new int[9];//�ۑ��p

    public Text PlayCountText;
    public static int PlayCount;
    public int SavePlayCount;

    public static bool FirstStart=false;//�J�n����Update���Ȃ�

    // ���������̏���
    void Start()
    {
        // �X�R�A�̃��[�h
        for (int i = 0; i < 9; i++)
        {
            SaveRanking[i] = PlayerPrefs.GetInt("SCORE" + i, 0);
        }
        SavePlayCount = PlayerPrefs.GetInt("PlayCount", 0);

        if (!FirstStart)
        {
            for (int i = 0; i < 9; i++)
            {
                Ranking[i] = SaveRanking[i];
            }
            PlayCount = SavePlayCount;
        }
            

    }
    // �폜���̏���
    void OnDestroy()
    {
        // �X�R�A��ۑ�
        for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, SaveRanking[i]);
        }
        PlayerPrefs.SetInt("PlayCount", SavePlayCount);
        PlayerPrefs.Save();
    }

    // �X�V
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            SaveRanking[i] = Ranking[i];
        }
        SavePlayCount = PlayCount;

        PlayCountText.text = "Gameplayed : " + SavePlayCount;
        score_text[0].text = "1st : " + SaveRanking[0] + "\n  " ;
        score_text[1].text = "2nd : " + SaveRanking[1] + "\n  " ;
        score_text[2].text = "3rd : " + SaveRanking[2] + "\n  " ;
        score_text[3].text = "4th : " + SaveRanking[3] + "\n  " ;
        score_text[4].text = "5th : " + SaveRanking[4] + "\n  " ;
        score_text[5].text = "6th : " + SaveRanking[5] + "\n  ";
        score_text[6].text = "7th : " + SaveRanking[6] + "\n  ";
        score_text[7].text = "8th : " + SaveRanking[7] + "\n  ";
        score_text[8].text = "9th : " + SaveRanking[8] + "\n  ";

    }
}