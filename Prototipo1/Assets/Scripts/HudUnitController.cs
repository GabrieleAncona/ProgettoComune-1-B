﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HudUnitController : MonoBehaviour
{
    public HudUnitsManager HUM;
    public Transform SlideTransform;
    public int UnitIndex;
    public GameObject InfoUnit;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        ConfirmedUnitSlide();
        if (HUM.isActive == true)
        {
            InfoUnit.SetActive(false);
        }
	}

    public void ConfirmedUnitSlide()
    {
        if (GameManager.singleton.sc.isActiveTank == true && GameManager.singleton.sc.contSelectionP1 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveHealer == true && GameManager.singleton.sc.contSelectionP1 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveUtility == true && GameManager.singleton.sc.contSelectionP1 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc.isActiveDealer == true && GameManager.singleton.sc.contSelectionP1 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == true && HUM.CanvasID == 1)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }

        /*if (GameManager.singleton.sc2.isActiveTankP2 == true && GameManager.singleton.sc2.contSelectionP2 == 1 && UnitIndex == 1 && GameManager.singleton.tm.isTurn == false)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveHealerP2 == true && GameManager.singleton.sc2.contSelectionP2 == 2 && UnitIndex == 2 && GameManager.singleton.tm.isTurn == false)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveUtilityP2 == true && GameManager.singleton.sc2.contSelectionP2 == 3 && UnitIndex == 3 && GameManager.singleton.tm.isTurn == false)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }
        if (GameManager.singleton.sc2.isActiveDealerP2 == true && GameManager.singleton.sc2.contSelectionP2 == 4 && UnitIndex == 4 && GameManager.singleton.tm.isTurn == false)
        {
            transform.DOMove(SlideTransform.transform.position, 0.9f).OnComplete(HUM.WaitoMove);
            InfoUnit.SetActive(true);
        }*/
    }
}
