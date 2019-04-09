using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GridSystem;

public class SelectorUI : MonoBehaviour
{
    public Image imageTankP1;
    public GameObject previewTankP1;
    public Image imageHealerP1;
    public GameObject previewHealerP1;
    public Image imageUtilityP1;
    public GameObject previewUtilityP1;
    public Image imageDealerP1;
    public GameObject previewDealerP1;
    public Image imageTankP2;
    public GameObject previewTankP2;
    public Image imageHealerP2;
    public GameObject previewHealerP2;
    public Image imageUtilityP2;
    public GameObject previewUtilityP2;
    public Image imageDealerP2;
    public GameObject previewDealerP2;
    public SelectionController selection;
    public SelectControllerP2 selectionP2;
    public TurnManager turn;

    // Use this for initialization
    void Start ()
    {
        selection = FindObjectOfType<SelectionController>();
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        turn = FindObjectOfType<TurnManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
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
                previewTankP1.SetActive(true);
            }
            else if (selection.contSelectionP1 != 1)
            {
                imageTankP1.GetComponent<Image>().enabled = false;
                previewTankP1.SetActive(false);
            }
            if (selection.contSelectionP1 == 2)
            {
                imageHealerP1.GetComponent<Image>().enabled = true;
                previewHealerP1.SetActive(true);
            }
            else if (selection.contSelectionP1 != 2)
            {
                imageHealerP1.GetComponent<Image>().enabled = false;
                previewHealerP1.SetActive(false);
            }
            if (selection.contSelectionP1 == 3)
            {
                imageUtilityP1.GetComponent<Image>().enabled = true;
                previewUtilityP1.SetActive(true);
            }
            else if (selection.contSelectionP1 != 3)
            {
                imageUtilityP1.GetComponent<Image>().enabled = false;
                previewUtilityP1.SetActive(false);
            }
            if (selection.contSelectionP1 == 4)
            {
                imageDealerP1.GetComponent<Image>().enabled = true;
                previewDealerP1.SetActive(true);
            }
            else if (selection.contSelectionP1 != 4)
            {
                imageDealerP1.GetComponent<Image>().enabled = false;
                previewDealerP1.SetActive(false);
            }

        }
        else if (turn.isTurn == false)
        {
            imageTankP1.GetComponent<Image>().enabled = false;
            imageHealerP1.GetComponent<Image>().enabled = false;
            imageUtilityP1.GetComponent<Image>().enabled = false;
            imageDealerP1.GetComponent<Image>().enabled = false;
            previewTankP1.SetActive(false);
            previewHealerP1.SetActive(false);
            previewUtilityP1.SetActive(false);
            previewDealerP1.SetActive(false);
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
            if (selectionP2.contSelectionP2 == 3)
            {
                imageUtilityP2.GetComponent<Image>().enabled = true;
            }
            else if (selectionP2.contSelectionP2 != 3)
            {
                imageUtilityP2.GetComponent<Image>().enabled = false;
            }
            if (selectionP2.contSelectionP2 == 4)
            {
                imageDealerP2.GetComponent<Image>().enabled = true;
            }
            else if (selectionP2.contSelectionP2 != 4)
            {
                imageDealerP2.GetComponent<Image>().enabled = false;
            }
        }
        else if (turn.isTurn == true)
        {
            imageTankP2.GetComponent<Image>().enabled = false;
            imageHealerP2.GetComponent<Image>().enabled = false;
            imageUtilityP2.GetComponent<Image>().enabled = false;
            imageDealerP2.GetComponent<Image>().enabled = false;
        }
    }
}
