 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : HitBase
{
    public int IdPlayer;
	MovementBase movementBase;
	AttackBase attackbase;
	AbilityBase abilitybase;
    DeathBase deathbase;
	AnimationController animCtrl;
    public int idUnitsGeneral;
    public int idunit;

	// Use this for initialization
	void Start ()
    {
		movementBase = GetComponent<MovementBase>();
		abilitybase = GetComponent<AbilityBase>();
		attackbase = GetComponent<AttackBase>();
        deathbase = GetComponent<DeathBase>();
        //hitbase = FindObjectOfType<HitBase>();
		animCtrl = GetComponent<AnimationController>();
		if (animCtrl != null)
			animCtrl.Init(movementBase, abilitybase, attackbase, deathbase, this);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameManager.singleton.tm.isTurn == true)
        {
            IdPlayer = 1;
        }

        else if (GameManager.singleton.tm.isTurn == false)
        {
            IdPlayer = 2;
        }
    }

    public void HitAnim()
    {
        if (OnHit != null)
        {
            OnHit();
        }
    }
}