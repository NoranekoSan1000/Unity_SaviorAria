using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSetting : MonoBehaviour
{
    public GameObject CenterEyeAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = CenterEyeAnchor.transform.position;
    }
}
