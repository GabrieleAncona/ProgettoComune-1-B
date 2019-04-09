using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeUtility : MonoBehaviour {
   
    public AttackBaseUtility att;
    public AbilityUtility ab;

    // Use this for initialization
    void Start()
    {

        att = FindObjectOfType<AttackBaseUtility>();
        ab = FindObjectOfType<AbilityUtility>();
  
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeUtility();
    }

    public void SetTileRangeUtility()
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
