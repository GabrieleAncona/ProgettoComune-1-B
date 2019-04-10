using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeDealer2 : MonoBehaviour {
    public PositionDealer2 dealerP2;
    public AttackBaseDealer2 att;
    public AbilityDealer2 ab;

    // Use this for initialization
    void Start()
    {

        dealerP2 = FindObjectOfType<PositionDealer2>();
        att = FindObjectOfType<AttackBaseDealer2>();
        ab = FindObjectOfType<AbilityDealer2>();
    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeDealerP2();


    }

    public void SetTileRangeDealerP2()
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
