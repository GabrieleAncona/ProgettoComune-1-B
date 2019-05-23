using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int IdPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.singleton.turnMng.isTurn == true)
        {
            IdPlayer = 1;
        }

        else if (GameManager.singleton.turnMng.isTurn == false)
        {
            IdPlayer = 2;
        }
    }

    public void ContenentList()
    {

    }
}
