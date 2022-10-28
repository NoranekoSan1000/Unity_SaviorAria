using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAngles : MonoBehaviour
{
    public bool pistol;
    public AudioClip SE_Reload;
    AudioSource audioSource;
    float Angles;
    float LAngles;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pistol)
        {
            Angles = this.gameObject.transform.localEulerAngles.x;
            if (((Angles > 55 && Angles < 90) || Input.GetKeyDown(KeyCode.R)) && !PlayerStatus.Reloading && PlayerStatus.Ammo < PlayerStatus.GunCapacity[PlayerStatus.GunMode])
            {
                audioSource.PlayOneShot(SE_Reload);
                if (PlayerStatus.Ammo < PlayerStatus.GunCapacity[PlayerStatus.GunMode]) PlayerStatus.ReloadTime = 1.25f;
                if (PlayerStatus.Ammo <= 0) PlayerStatus.ReloadTime = 1.5f;
                PlayerStatus.Reloading = true;
            }
        }
        else
        {
            LAngles = this.gameObject.transform.localEulerAngles.x;
            if (((LAngles > 55 && LAngles < 90) || Input.GetKeyDown(KeyCode.R)) && !PlayerStatus.LReloading && PlayerStatus.LAmmo < PlayerStatus.GunCapacity[0])
            {
                audioSource.PlayOneShot(SE_Reload);
                if (PlayerStatus.LAmmo < PlayerStatus.GunCapacity[0]) PlayerStatus.LReloadTime = 1.25f;
                if (PlayerStatus.LAmmo <= 0) PlayerStatus.LReloadTime = 1.5f;
                PlayerStatus.LReloading = true;
            }
        }

    }
}
