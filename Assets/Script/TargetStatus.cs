using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStatus : MonoBehaviour
{
    int Pos = 0;
    public float Height;

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
        Pos = Random.Range(0, 12);
        for (int i = 0; i < 12; i++)
        {
            if (Pos == i) this.gameObject.transform.position = new Vector3(-6+i, Height, -8);
        }
    }
}
