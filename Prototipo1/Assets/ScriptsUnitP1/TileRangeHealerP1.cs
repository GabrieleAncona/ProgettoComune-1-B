using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeHealerP1 : MonoBehaviour {
    public PositionTester tankP1;
    public AttackBaseHealer att;
    public AbilityHealer ab;

    // Use this for initialization
    void Start()
    {

        att = FindObjectOfType<AttackBaseHealer>();
        ab = FindObjectOfType<AbilityHealer>();
        tankP1 = FindObjectOfType<PositionTester>();
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeHealer();
    }

    public void SetTileRangeHealer()
    {
        if (att.isAttackHealer == true || ab.isAbility == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (att.isAttackHealer == false || ab.isAbility == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
   
}
