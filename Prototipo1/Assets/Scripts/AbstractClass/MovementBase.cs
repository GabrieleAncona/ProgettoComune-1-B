using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : DeathBase
{
	public delegate void MovementEvent();
	public MovementEvent OnMovement;
}
