using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleStatus : MonoBehaviour
{
    public static bool GameStart;
    public static bool GameEnd;

    bool OKButton;
    public static string InputName;
    public GameObject NameButton;
    public Text InpName;
    public GameObject NameTextField;

    public static int TitleAmmo = 999;
    float Wait = 0;
    float Wait2 = 0;

    //ランキング削除用
    public static int RankingDelete = 0;

    // Start is called before the first frame update
    void Start()
    {
        InputName = "NONAME";
        OKButton = false;
        GameStart = false;
        Wait = 0;
        Wait2 = 0;
        FadeController.isFadeIn = true;

        RankingDelete = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RankingDelete == 0 && Input.GetKey(KeyCode.D))
        {
            RankingDelete = 1;
        }
        if (RankingDelete == 1 && Input.GetKey(KeyCode.E))
        {
            RankingDelete = 2;
        }
        if (RankingDelete == 2 && Input.GetKey(KeyCode.L))
        {
            RankingDelete = 3;
        }

        TitleAmmo = 999;
        if(GameStart)
        {
            Wait += Time.deltaTime;
            if (Wait >= 0.75f) FadeController.isFadeOut = true;
            if (Wait >= 3) SceneManager.LoadScene("destroyed_city 1");
        }
        if (GameEnd)
        {

            Wait2 += Time.deltaTime;
            if (Wait2 >= 0.75f) FadeController.isFadeOut = true;
            if (Wait2 >= 3) Application.Quit();//終了
        }


    }

    public void ClickOKButton()
    {
        OKButton = true;
        InputName = InpName.text;
        NameButton.SetActive(false);
        NameTextField.SetActive(false);

        Debug.Log(InputName);
    }


}


    


