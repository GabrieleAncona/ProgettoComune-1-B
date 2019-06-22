﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;

public class HudUnitsManager : MonoBehaviour
{
    public bool isActive;
    SelectionUnits SU;
    SelectUnitsP2 SU2;
    public int CanvasID;
    public List<HudUnitController> SingleHudUnit = new List<HudUnitController>();
    public List<Transform> HudUnitPosition = new List<Transform>();

    public List<Image> Poison = new List<Image>();
    public List<Image> Freeze = new List<Image>();

    public bool OnMove
    {
        get { return _onMove; }
        private set {
            _onMove = value;
        }
    }
    private bool _onMove;

    // Use this for initialization
    void Start()
    {
        SU = FindObjectOfType<SelectionUnits>();
        SU2 = FindObjectOfType<SelectUnitsP2>();
        isActive = true;
    }

    public int firstIndex; 

    // Update is called once per frame
    void Update()
    {

        if (GameManager.singleton._player.IdPlayer == 1 && OnMove == false)
        {
            firstIndex = GameManager.singleton.sc.contSelectionP1;

            if (Input.GetKeyDown(SU.ChangeSelectionButtonAdd) && CanvasID == 1 && isActive == true)
            {
                Debug.Log(OnMove);
                SetFirstController(firstIndex,false);
                OnMove = true;
                
            }
            if (Input.GetKeyDown(SU.ChangeSelectionButtonRemove) && CanvasID == 1 && isActive == true)
            {
                SetFirstController(firstIndex,true);
                OnMove = true;
                
            }
        }
        if (GameManager.singleton._player.IdPlayer == 2 && OnMove == false)
        {
            firstIndex = GameManager.singleton.sc2.contSelectionP2;

            if (Input.GetKeyDown(SU2.ChangeSelectionButtonAdd) && CanvasID == 2 && isActive == true)
            {
                SetFirstController(firstIndex,false);
                OnMove = true;
            }
            if (Input.GetKeyDown(SU2.ChangeSelectionButtonRemove) && CanvasID == 2 && isActive == true)
            {
                SetFirstController(firstIndex,true);
                OnMove = true;
            }
        }
        
    }

    public void MoveUnits(List<HudUnitController> OrderedList)
    {
        for (int i = 0; i < OrderedList.Count; i++)
        {
            OrderedList[i].transform.DOMove(HudUnitPosition[i].transform.position, 0.9f).OnComplete(WaitoMove);
            
        }
        
    }

    private void WaitoMove()
    {
        OnMove = false;
    }

    List<HudUnitController> newList = new List<HudUnitController>();

    public void SetFirstController(int firstUnit, bool Giù)
    {
        if (newList.Count == 0)
        {
            newList.Add(SingleHudUnit[firstUnit - 1]);

            foreach (var item in SingleHudUnit)
            {
                if (item != SingleHudUnit[firstUnit - 1])
                    newList.Add(item);
            }
        }
        else
        {
            if (Giù == false)
            {
                HudUnitController HUC = newList[0];
                newList.Remove(HUC);
                newList.Add(HUC);
            }
            else if (Giù == true)
            {
                HudUnitController HUC2 = newList[newList.Count - 1];
                newList.Remove(HUC2);
                newList.Insert(0, HUC2);
            }
        }
        MoveUnits(newList);
    }

}
