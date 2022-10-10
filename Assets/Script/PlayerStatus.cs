using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static int Ammo = 40;
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
            Ammo = 40;
            Reloading = false;
        }
    }
}
