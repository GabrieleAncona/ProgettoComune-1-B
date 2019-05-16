using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int IdPlayer;
    public List<Player> player = new List<Player>();


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameManager.singleton.tm.isTurn == true)
        {
            IdPlayer = 1;
        }

        else if (GameManager.singleton.tm.isTurn == false)
        {
            IdPlayer = 2;
        }
    }

    public void ContenentList()
    {
        
    }
}
