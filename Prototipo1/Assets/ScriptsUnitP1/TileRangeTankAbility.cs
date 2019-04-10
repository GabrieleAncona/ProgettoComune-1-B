using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRangeTankAbility : MonoBehaviour {
    public AbilityTank ab;


    // Use this for initialization
    void Start()
    {

        ab = FindObjectOfType<AbilityTank>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRange();
    }

    public void SetTileRange()
    {
        if (ab.isAbility == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (ab.isAbility == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
