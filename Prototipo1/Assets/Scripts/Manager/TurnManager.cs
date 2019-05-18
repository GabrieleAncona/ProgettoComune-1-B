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
           

        }
        if (isTurn == true)
        {
            SendMessage("RotationCameraPlayer1");
            
        }


    }

}

