using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GridSystem;

public class SelectorUI : MonoBehaviour {
    public Image imageTankP1;
    public Image imageHealerP1;
    public Image imageTankP2;
    public Image imageHealerP2;
    public SelectionController selection;
    public SelectControllerP2 selectionP2;
    public TurnManager turn;

    // Use this for initialization
    void Start () {

        selection = FindObjectOfType<SelectionController>();
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
    }
	
	// Update is called once per frame
	void Update () {

        ImageUIPlayer1();
        ImageUIPlayer2();
    }

    public void ImageUIPlayer1()
    {
        if (turn.isTurn == true)
        {
            if (selection.contSelectionP1 == 1)
            {
                imageTankP1.GetComponent<Image>().enabled = true;

            }
            else if (selection.contSelectionP1 != 1)
            {
                imageTankP1.GetComponent<Image>().enabled = false;
            }

            if (selection.contSelectionP1 == 2)
            {
                imageHealerP1.GetComponent<Image>().enabled = true;

            }
            else if (selection.contSelectionP1 != 2)
            {
                imageHealerP1.GetComponent<Image>().enabled = false;
            }
        }
        else if (turn.isTurn == false)
        {
            imageTankP1.GetComponent<Image>().enabled = false;
            imageHealerP1.GetComponent<Image>().enabled = false;
        }
    }

    public void ImageUIPlayer2()
    {
        if (turn.isTurn == false)
        {
            if (selectionP2.contSelectionP2 == 1)
            {
                imageTankP2.GetComponent<Image>().enabled = true;

            }
            else if (selectionP2.contSelectionP2 != 1)
            {
                imageTankP2.GetComponent<Image>().enabled = false;
            }

            if (selectionP2.contSelectionP2 == 2)
            {
                imageHealerP2.GetComponent<Image>().enabled = true;

            }
            else if (selectionP2.contSelectionP2 != 2)
            {
                imageHealerP2.GetComponent<Image>().enabled = false;
            }
        }
        else if (turn.isTurn == true)
        {
            imageTankP2.GetComponent<Image>().enabled = false;
            imageHealerP2.GetComponent<Image>().enabled = false;
        }
    }
}
