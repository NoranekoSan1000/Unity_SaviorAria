using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�p�l���̃C���[�W�𑀍삷��̂ɕK�v

public class RedFade : MonoBehaviour
{

    float fadeSpeed = 0.005f;        //�����x���ς��X�s�[�h���Ǘ�
    float alfa;   //�p�l���̐F�A�s�����x���Ǘ�

    public static bool isRedFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    public static bool isRedFadeIn = false;   //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O

    Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

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
        alfa -= fadeSpeed;                //a)�s�����x�����X�ɉ�����
        SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
        if (alfa <= 0)
        {                    //c)���S�ɓ����ɂȂ����珈���𔲂���
            isRedFadeIn = false;
            fadeImage.enabled = false;    //d)�p�l���̕\�����I�t�ɂ���
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
        if (alfa >= 1)
        {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
            isRedFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(255, 0, 0, alfa);
    }
}