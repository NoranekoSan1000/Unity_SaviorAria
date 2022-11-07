using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要

public class RedFade : MonoBehaviour
{

    float fadeSpeed = 0.005f;        //透明度が変わるスピードを管理
    float alfa;   //パネルの色、不透明度を管理

    public static bool isRedFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public static bool isRedFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        if (isRedFadeIn)
        {
            StartFadeIn();
        }

        if (isRedFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa <= 0)
        {                    //c)完全に透明になったら処理を抜ける
            isRedFadeIn = false;
            fadeImage.enabled = false;    //d)パネルの表示をオフにする
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alfa >= 1)
        {             // d)完全に不透明になったら処理を抜ける
            isRedFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(255, 0, 0, alfa);
    }
}