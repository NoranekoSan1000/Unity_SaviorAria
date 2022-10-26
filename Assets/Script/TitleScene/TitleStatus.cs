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

    // Start is called before the first frame update
    void Start()
    {
        InputName = "-----";
        OKButton = false;
        GameStart = false;
        Wait = 0;
        Wait2 = 0;
        FadeController.isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Wait2 >= 3) Application.Quit();//�I��
        }
        
        if(OKButton)
        {
            InputName = InpName.text;
            NameButton.SetActive(false);
            NameTextField.SetActive(false);
        }

    }

    public void ClickOKButton()
    {
        OKButton = true;
    }


}


    


