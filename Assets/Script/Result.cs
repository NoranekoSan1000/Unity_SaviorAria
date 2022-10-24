using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public Text ResultScoreText;
    public static float ScoretextTime = -2;
    char[] phaseChar = new char[7] { ' ', 'S', 'c', 'o', 'r', 'e', ' ' };

    int[] ScoreD = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        ResultScoreText.text = "";
        ScoretextTime = -2;

        ScoreManager.FirstStart = true;
        //ƒ‰ƒ“ƒLƒ“ƒO
        for (int i = 0; i < 9; i++)
        {
            if (ScoreManager.Ranking[i] <= PlayerStatus.Score)
            {
                for (int j = 7; j >= i; j--)
                {
                    ScoreManager.Ranking[j + 1] = ScoreManager.Ranking[j];
                }
                ScoreManager.Ranking[i] = PlayerStatus.Score;
                break;
            }
        }
        ScoreManager.PlayCount += 1;

        ScoreD[0] = PlayerStatus.Score / 100000;
        for (int i = 1; i < 6; i++)
        {
            PlayerStatus.Score -= ScoreD[i - 1] * (int)System.Math.Pow(10, (6 - i));
            ScoreD[i] = PlayerStatus.Score / (int)System.Math.Pow(10, (5 - i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoretextTime < 7f) ScoretextTime += Time.deltaTime;

        if (ScoretextTime > 0.12f) ResultScoreText.text = " ";
        for (int i = 0; i < 7; i++) if (ScoretextTime > 0.12f * (i + 2)) ResultScoreText.text += phaseChar[i];
        if (ScoretextTime > 0.96f) ResultScoreText.text = "  Score  " + ScoreD[0];
        if (ScoretextTime > 1.08f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1];
        if (ScoretextTime > 1.20f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2];
        if (ScoretextTime > 1.32f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3];
        if (ScoretextTime > 1.44f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3] + "" + ScoreD[4];
        if (ScoretextTime > 1.56f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3] + "" + ScoreD[4] + "" + ScoreD[5];

        if (Input.GetKeyDown(KeyCode.A)) SceneManager.LoadScene(0);
    }
}
