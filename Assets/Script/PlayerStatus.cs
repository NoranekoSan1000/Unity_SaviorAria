using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static int GunMode = 0;
    public static int Ammo = 20;
    public static int[] GunAmmo = new int[3] {20,68,1};
    public static bool Reloading = false;
    public static float ReloadTime = 0;
    public Text LeftAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftAmmoText.text = "Ammo : " + Ammo;
        if(ReloadTime > 0 && Reloading)
        {
            ReloadTime -= Time.deltaTime;
        }
        if(ReloadTime < 0 && Reloading)
        {
            Ammo = GunAmmo[GunMode];
            Reloading = false;
        }

        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Ammo = 0;
            if (GunMode < 2) GunMode++;
            else GunMode = 0;
        }
    }
}
