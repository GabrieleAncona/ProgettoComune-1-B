using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeHealerP2 : MonoBehaviour {
  
    public AttackBaseHealer2 att;
    public AbilityHealer2 ab;

    // Use this for initialization
    void Start()
    {

        att = FindObjectOfType<AttackBaseHealer2>();
        ab = FindObjectOfType<AbilityHealer2>();
     
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeHealer();
    }

    public void SetTileRangeHealer()
    {
        if (att.isAttack == true || ab.isAbility == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (att.isAttack == false || ab.isAbility == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
