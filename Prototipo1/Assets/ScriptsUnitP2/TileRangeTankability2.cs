using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRangeTankability2 : MonoBehaviour {
    public AbilityTank2 ab;


    // Use this for initialization
    void Start()
    {

        ab = FindObjectOfType<AbilityTank2>();

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
