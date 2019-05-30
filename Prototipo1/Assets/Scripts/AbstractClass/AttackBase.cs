using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour 
{
	public delegate void AttackEvent();
	public AttackEvent OnAttack;
}
