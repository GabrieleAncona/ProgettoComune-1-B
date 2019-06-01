using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeathBase : MonoBehaviour
{
    public delegate void DeathEvent();
    public DeathEvent OnDeath;
}
