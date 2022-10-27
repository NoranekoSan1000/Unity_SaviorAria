using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audios;

    public GameObject RedPanel;
    public Text GameOverorClear;
    public Text ResultScoreText;
    public Text NextText;
    public Text EndText;
    public static float ScoretextTime = -2;
    float EndTime = 0;
    bool end;
    char[] phaseChar = new char[7] { ' ', 'S', 'c', 'o', 'r', 'e', ' ' };

    int[] ScoreD = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        FadeController.isFadeIn = true;
        //BGM
        audios = GetComponent<AudioSource>();      
        if (PlayerStatus.GamePhase >= 17) audios.clip = BGM[1];//clear
        else audios.clip = BGM[0];//gameover
        audios.Play();

        ResultScoreText.text = "";
        ScoretextTime = -2;
        EndTime = 0;
        end = false;
        NextText.text = "";
        EndText.text = "";
        if (PlayerStatus.PlayerHP > 0) PlayerStatus.Score += 1000 * PlayerStatus.PlayerHP;

        ScoreManager.FirstStart = true;
        //ランキング
        for (int i = 0; i < 9; i++)
        {
            if (ScoreManager.Ranking[i] <= PlayerStatus.Score)
            {
                for (int j = 7; j >= i; j--)
                {
                    ScoreManager.Ranking[j + 1] = ScoreManager.Ranking[j];
                    ScoreManager.Name[j + 1] = ScoreManager.Name[j];
                }
                ScoreManager.Name[i] = TitleStatus.InputName; 
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
        if (PlayerStatus.GamePhase >= 17)
        {
            GameOverorClear.text = "GameClear";//clear
            RedPanel.SetActive(false);
        }
        else
        {
            GameOverorClear.text = "GameOver";//gameover
            RedPanel.SetActive(true);
        }
        if (ScoretextTime < 7f) ScoretextTime += Time.deltaTime;

        if (ScoretextTime > 0.12f) ResultScoreText.text = " ";
        for (int i = 0; i < 7; i++) if (ScoretextTime > 0.12f * (i + 2)) ResultScoreText.text += phaseChar[i];
        if (ScoretextTime > 0.96f) ResultScoreText.text = "  Score  " + ScoreD[0];
        if (ScoretextTime > 1.08f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1];
        if (ScoretextTime > 1.20f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2];
        if (ScoretextTime > 1.32f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3];
        if (ScoretextTime > 1.44f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3] + "" + ScoreD[4];
        if (ScoretextTime > 1.56f) ResultScoreText.text = "  Score  " + ScoreD[0] + "" + ScoreD[1] + "" + ScoreD[2] + "" + ScoreD[3] + "" + ScoreD[4] + "" + ScoreD[5];

        if (ScoretextTime > 4f) NextText.text = "-　トリガーを引いて終了　-";
        if (ScoretextTime > 4.2f && (Input.GetKeyDown(KeyCode.A) || (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))))
        {
            FadeController.isFadeOut = true;
            end = true;
        }

        if(end) EndGame();
    }
    public void EndGame()
    {
        EndTime += Time.deltaTime;
        if (EndTime > 3) EndText.text = "BGM\n\nM-ART";
        if (EndTime > 6) EndText.text = "制作\n\nNoranekoFelician";
        if (EndTime > 9) EndText.text = "";
        if (EndTime > 10) SceneManager.LoadScene(0);
    }
}
