using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBase : MonoBehaviour
{

    public bool isActive;
    /// <summary>
    /// Funzione che si occupa di attivare/disattivare il menu in base allo stato attuale
    /// </summary>
    /// <param name="_value"></param>
    public virtual void ToogleMenu(bool _value)
    {
        if (isActive == _value)
                 return;
        isActive = _value;
        gameObject.SetActive(_value);

    }
}
