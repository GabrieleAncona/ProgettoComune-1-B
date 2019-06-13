using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHitHealer : MonoBehaviour { 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UnitP1")
        {
            ///vfxHit.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
