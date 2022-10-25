using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAngles : MonoBehaviour
{
    public AudioClip SE_Reload;
    AudioSource audioSource;
    float Angles;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Angles = this.gameObject.transform.localEulerAngles.x;
        if (((Angles > 55 && Angles < 90) || Input.GetKeyDown(KeyCode.R)) && !PlayerStatus.Reloading && PlayerStatus.Ammo < PlayerStatus.GunCapacity[PlayerStatus.GunMode])
        {
            audioSource.PlayOneShot(SE_Reload);
            if(PlayerStatus.Ammo < PlayerStatus.GunCapacity[PlayerStatus.GunMode]) PlayerStatus.ReloadTime = 1f;
            if(PlayerStatus.Ammo <= 0) PlayerStatus.ReloadTime = 1.25f;
            PlayerStatus.Reloading = true;
        }
    }
}
