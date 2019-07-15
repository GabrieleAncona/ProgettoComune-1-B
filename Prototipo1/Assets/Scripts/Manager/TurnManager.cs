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
    public bool isRed;
    public bool isBlue;
    public GameObject blueTurn;
    public GameObject redTurn;
    public bool isFightActive;
    public GameObject tipsP1;
    public GameObject tipsP2;

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(TurnController());
    }

    IEnumerator TurnController()
    {
        if (isTurn == false)
        {
            tipsP2.SetActive(true);
            tipsP1.SetActive(false);
            SendMessage("RotationCameraPlayer2");
            ///azzero variabile per scritta turno
            isBlue = false;
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

            ///attivo pannello 2 player e lo disattivo dopo 3 secondi
            if (isRed == false && GameManager.singleton.acm.isSelection == true)
            {
                isRed = true;
                redTurn.SetActive(true);
                yield return new WaitForSeconds(3f);
                redTurn.SetActive(false);
            }
           
        }
        if (isTurn == true)
        {
            tipsP1.SetActive(true);
            tipsP2.SetActive(false);
            SendMessage("RotationCameraPlayer1");
            ///azzero variabile per scritta turno
            isRed = false;
            ///resetto utizzabilità pedine player2
            GameManager.singleton.sc2.isTankUsable2 = true;
            GameManager.singleton.sc2.isHealerUsable2 = true;
            GameManager.singleton.sc2.isUtilityUsable2 = true;
            GameManager.singleton.sc2.isDealerUsable2 = true;

            ///resetto azione(azione/abilita) player 2 
            GameManager.singleton.acm.isActionTank2 = true;
            GameManager.singleton.acm.isActionHealer2 = true;
            GameManager.singleton.acm.isActionUtility2 = true;
            GameManager.singleton.acm.isActionDealer2 = true;

            ///attivo pannello 1 player e lo disattivo dopo 3 secondi
            if (isBlue == false && isFightActive == false && GameManager.singleton.acm.isSelection == true)
            {
                isBlue = true;
                blueTurn.SetActive(true);
                yield return new WaitForSeconds(3f);
                blueTurn.SetActive(false);
            }
        }
    }

}

