using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeTankP1 : MonoBehaviour {
    public PositionTester tankP1;
    public AttackBase1 att;
    public AbilityTank ab;
    


    // Use this for initialization
    void Start () {

        att = FindObjectOfType<AttackBase1>();
      
       
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
    
        SetTileRange();
    }

    public void SetTileRange()
    {
       if(GameManager.singleton.acm.isAttack == true) 
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
         else if(GameManager.singleton.acm.isAttack == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    
}
