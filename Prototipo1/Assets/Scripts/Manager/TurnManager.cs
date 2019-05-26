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
            ///resetto utizzabilità pedine player1
            GameManager.singleton.sc.isTankUsable = true;
            GameManager.singleton.sc.isHealerUsable = true;
            GameManager.singleton.sc.isUtilityUsable = true;
            GameManager.singleton.sc.isDealerUsable = true;

            ///resetto azione(azione/abilita) player 1
            GameManager.singleton.acm.isActionTank = true;
            GameManager.singleton.acm.isActionHealer = true;
            GameManager.singleton.acm.isActionUtility = true;
            GameManager.singleton.acm.isActionDealer = true;
        }
        if (isTurn == true)
        {
            ///resetto utizzabilità pedine player2
            SendMessage("RotationCameraPlayer1");
            GameManager.singleton.sc2.isTankUsable2 = true;
            GameManager.singleton.sc2.isHealerUsable2 = true;
            GameManager.singleton.sc2.isUtilityUsable2 = true;
            GameManager.singleton.sc2.isDealerUsable2 = true;

            ///resetto azione(azione/abilita) player 2 
            GameManager.singleton.acm.isActionTank2 = true;
            GameManager.singleton.acm.isActionHealer2 = true;
            GameManager.singleton.acm.isActionUtility2 = true;
            GameManager.singleton.acm.isActionDealer2 = true;
        }


    }

}

