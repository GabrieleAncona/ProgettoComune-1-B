using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class DestroyVfx : MonoBehaviour { 

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "UnitP1" || other.gameObject.tag == "UnitP2")
        {
            ///vfxHit.SetActive(true);
            Destroy(gameObject);
            
        }
    }
}
