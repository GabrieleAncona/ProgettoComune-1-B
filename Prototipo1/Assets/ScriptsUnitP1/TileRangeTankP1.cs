using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeTankP1 : MonoBehaviour {
    public PositionTester tankP1;
    public AttackBase1 att;
    public AbilityTank ab;
    public bool isRangeActive;


    // Use this for initialization
    void Start () {

        att = FindObjectOfType<AttackBase1>();
        ab = FindObjectOfType<AbilityTank>();
        tankP1 = FindObjectOfType<PositionTester>();
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
    
        SetTileRange();
    }

    public void SetTileRange()
    {
       if((att.isAttack == true || ab.isAbility == true) )
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
         else if(att.isAttack == false || ab.isAbility == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    
   /* public void OnTriggerStay(Collider grid)
    {
        if(grid.gameObject.tag == "Griglia")
        {
            isRangeActive = true;
        }
    }

    public void onTriggerExit(Collider grid)
    {
        if (grid.gameObject.tag == "Griglia")
        {
            isRangeActive = false;
            
        }
    }*/
    
}
