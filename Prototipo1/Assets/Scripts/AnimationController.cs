using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	private Animator _anim;

	public void Init(MovementBase _movement, AbilityBase _ability, AttackBase _attack)
	{
		_anim = GetComponent<Animator>();

		if (_movement != null)
			_movement.OnMovement += HandleMovement;
		if (_ability != null)
			_ability.OnAbility += HandleAbility;
		if (_attack != null)
			_attack.OnAttack += HandleAttack;
	}


	private void HandleMovement() 
	{
		GoToMovement();
	}
	private void HandleAbility()
	{
		GoToAbility();
	}
	private void HandleAttack()
	{
		GoToAttack();
	}



	private void GoToMovement()
	{
		_anim.SetTrigger("GoToMovement");
	}
	private void GoToIdle()
	{
		_anim.SetTrigger("GoToIdle");
	}
	private void GoToAttack()
	{
		_anim.SetTrigger("GoToAttack");
	}
	private void GoToAbility()
	{
		_anim.SetTrigger("GoToAbility");
	}
	private void GoToDeath()
	{
		_anim.SetTrigger("GoToDeath");
	}
}
