using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HudUnitController : MonoBehaviour
{
    public HudUnitsManager HUM;
    public Transform SlideTransform;
    public Transform SlideBackTransform;
    public int UnitIndex;
    public GameObject InfoUnit;
    public Slider LifeSlider;
    public GameObject text;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        ConfirmedUnitSlide();
        BackSlide();
	}

    public void ConfirmedUnitSlide()
    {
        if (GameManager.singleton.sc.isActiveTank == true && GameManager.singleton.sc.contSelectionP1 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveHealer == true && GameManager.singleton.sc.contSelectionP1 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveUtility == true && GameManager.singleton.sc.contSelectionP1 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveDealer == true && GameManager.singleton.sc.contSelectionP1 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }

        if (GameManager.singleton.sc2.isActiveTankP2 == true && GameManager.singleton.sc2.contSelectionP2 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveHealerP2 == true && GameManager.singleton.sc2.contSelectionP2 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveUtilityP2 == true && GameManager.singleton.sc2.contSelectionP2 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveDealerP2 == true && GameManager.singleton.sc2.contSelectionP2 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(1.20f, 1, 1), 0.9f);
            text.SetActive(true);
            InfoUnit.SetActive(true);
        }
    }

    public void BackSlide()
    {
        if (GameManager.singleton.sc.isActiveTank == false && GameManager.singleton.sc.contSelectionP1 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc.isActiveHealer == false && GameManager.singleton.sc.contSelectionP1 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc.isActiveUtility == false && GameManager.singleton.sc.contSelectionP1 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc.isActiveDealer == false && GameManager.singleton.sc.contSelectionP1 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }

        if (GameManager.singleton.sc2.isActiveTankP2 == false && GameManager.singleton.sc2.contSelectionP2 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc2.isActiveHealerP2 == false && GameManager.singleton.sc2.contSelectionP2 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc2.isActiveUtilityP2 == false && GameManager.singleton.sc2.contSelectionP2 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
        if (GameManager.singleton.sc2.isActiveDealerP2 == false && GameManager.singleton.sc2.contSelectionP2 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == false && HUM.CanvasID == 2)
        {
            transform.DOMove(SlideBackTransform.transform.position, 0.9f);
            LifeSlider.transform.DOScale(new Vector3(0.6f, 0.6f, 1), 0.9f);
            text.SetActive(false);
            InfoUnit.SetActive(false);
        }
    }
}
