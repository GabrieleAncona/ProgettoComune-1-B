using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour 
{
	public delegate void AbilityEvent();
	public AbilityEvent OnAbility;

}
