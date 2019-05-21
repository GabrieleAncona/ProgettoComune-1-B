using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;
using UnityEngine.UI;

//controlla turno gestisce camera
public class TurnManager : MonoBehaviour
{
    public bool isTurn = true;
    public int ContRound;
    

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        if (isTurn == false)
        {
            SendMessage("RotationCameraPlayer2");
            GameManager.singleton.sc.isTankUsable = true;
            GameManager.singleton.sc.isHealerUsable = true;
            GameManager.singleton.sc.isUtilityUsable = true;
            GameManager.singleton.sc.isDealerUsable = true;

        }
        if (isTurn == true)
        {
            SendMessage("RotationCameraPlayer1");
            GameManager.singleton.sc2.isTankUsable2 = true;
            GameManager.singleton.sc2.isHealerUsable2 = true;
            GameManager.singleton.sc2.isUtilityUsable2 = true;
            GameManager.singleton.sc2.isDealerUsable2 = true;
        }


    }

}

