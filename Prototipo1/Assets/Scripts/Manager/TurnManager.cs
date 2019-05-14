using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;
using UnityEngine.UI;

//controlla turno gestisce camera
public class TurnManager : MonoBehaviour
{
    /// <summary>
    /// se  isTurn == true è il turno del player 1
    /// se  isTurn == false è il turno del player 2
    /// </summary>

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

        }
        if (isTurn == true)
        {
            SendMessage("RotationCameraPlayer1");
            
        }


    }

}

