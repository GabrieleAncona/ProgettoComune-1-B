using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitBase : MonoBehaviour 
{
	public delegate void HitEvent();
	public HitEvent OnHit;
}
