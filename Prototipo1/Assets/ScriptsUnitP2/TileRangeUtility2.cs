using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeUtility2 : MonoBehaviour {
    public AttackBaseUtility2 att;
    public AbilityUtility2 ab;

    // Use this for initialization
    void Start()
    {

        att = FindObjectOfType<AttackBaseUtility2>();
        ab = FindObjectOfType<AbilityUtility2>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeUtilityP2();
    }

    public void SetTileRangeUtilityP2()
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
