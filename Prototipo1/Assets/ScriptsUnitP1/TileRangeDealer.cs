using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeDealer : MonoBehaviour {
    public PositionDealer dealer;
    public AttackBaseDealer att;
    public AbilityDealer ab;

	// Use this for initialization
	void Start () {

        dealer = FindObjectOfType<PositionDealer>();
        att = FindObjectOfType<AttackBaseDealer>();
        ab = FindObjectOfType<AbilityDealer>();

	}
	
	// Update is called once per frame
	void Update () {

        SetTileRangeDealer();


    }

    public void SetTileRangeDealer()
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
