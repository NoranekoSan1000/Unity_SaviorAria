using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.FirstStart = true;
        //ƒ‰ƒ“ƒLƒ“ƒO
        for (int i = 0; i < 7; i++)
        {
            if (ScoreManager.Ranking[i] <= PlayerStatus.Score)
            {
                for (int j = 5; j >= i; j--)
                {
                    ScoreManager.Ranking[j + 1] = ScoreManager.Ranking[j];
                }
                ScoreManager.Ranking[i] = PlayerStatus.Score;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) SceneManager.LoadScene(0);
    }
}
