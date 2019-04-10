using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeTankP2 : MonoBehaviour {
   
    public AttackBase2 att;
   

    // Use this for initialization
    void Start()
    {

        att = FindObjectOfType<AttackBase2>();
      
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRange();
    }

    public void SetTileRange()
    {
        if (att.isAttack == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (att.isAttack == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
