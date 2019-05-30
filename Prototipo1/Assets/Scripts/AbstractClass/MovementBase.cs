using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour 
{
	public delegate void MovementEvent();
	public MovementEvent OnMovement;
}
