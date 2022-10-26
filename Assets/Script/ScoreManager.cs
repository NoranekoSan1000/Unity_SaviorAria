using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ����܂��傤

public class ScoreManager : MonoBehaviour
{
    public Text[] score_text = new Text[9]; // Text�I�u�W�F�N�g
    public static int[] Ranking = new int[9];//�擾�p
    public int[] SaveRanking = new int[9];//�ۑ��p

    public static string[] Name = new string[9];//�擾�p
    public string[] SaveName = new string[9];//�ۑ��p

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
    // �폜���̏���
    void OnDestroy()
    {
        // �X�R�A��ۑ�
        for (int i = 0; i < 9; i++)
        {
            PlayerPrefs.SetInt("SCORE" + i, SaveRanking[i]);
            PlayerPrefs.SetString("NAME" + i, SaveName[i]);
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
            SaveName[i] = Name[i];
        }
        SavePlayCount = PlayCount;

        PlayCountText.text = "Gameplayed : " + SavePlayCount;
        score_text[0].text = "1st: " + SaveName[0] + "�y" + SaveRanking[0] + "�z" ;
        score_text[1].text = "2nd: " + SaveName[1] + "�y" + SaveRanking[1] + "�z" ;
        score_text[2].text = "3rd: " + SaveName[2] + "�y" + SaveRanking[2] + "�z" ;
        score_text[3].text = "4th: " + SaveName[3] + "�y" + SaveRanking[3] + "�z" ;
        score_text[4].text = "5th: " + SaveName[4] + "�y" + SaveRanking[4] + "�z" ;
        score_text[5].text = "6th: " + SaveName[5] + "�y" + SaveRanking[5] + "�z" ;
        score_text[6].text = "7th: " + SaveName[6] + "�y" + SaveRanking[6] + "�z" ;
        score_text[7].text = "8th: " + SaveName[7] + "�y" + SaveRanking[7] + "�z" ;
        score_text[8].text = "9th: " + SaveName[8] + "�y" + SaveRanking[8] + "�z" ;

    }
}