using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTitle : MonoBehaviour
{
    public int Num = 0;

    public AudioClip SE_HitTarget;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
             
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(SE_HitTarget);
        if (Num == 0 && !TitleStatus.GameStart && !TitleStatus.GameEnd) TitleStatus.GameStart = true;
        if (Num == 1 && !TitleStatus.GameStart && !TitleStatus.GameEnd) TitleStatus.GameEnd = true;
    }
}
