using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class HudUnitsManager : MonoBehaviour
{
    SelectionUnits SU;
    SelectUnitsP2 SU2;
    public int CanvasID;
    public List<HudUnitController> SingleHudUnit = new List<HudUnitController>();
    public List<Transform> HudUnitPosition = new List<Transform>();
    public bool OnMove;

    // Use this for initialization
    void Start()
    {
        SU = FindObjectOfType<SelectionUnits>();
        SU2 = FindObjectOfType<SelectUnitsP2>();
    }

    public int firstIndex; 

    // Update is called once per frame
    void Update()
    {

        if (GameManager.singleton._player.IdPlayer == 1 && OnMove == false)
        {
            firstIndex = GameManager.singleton.sc.contSelectionP1;

            if (Input.GetKeyDown(SU.ChangeSelectionButtonAdd) && CanvasID == 1)
            {
                SetFirstController(firstIndex,false);
                OnMove = true;
            }
            if (Input.GetKeyDown(SU.ChangeSelectionButtonRemove) && CanvasID == 1)
            {
                SetFirstController(firstIndex,true);
                OnMove = true;
            }
        }
        if (GameManager.singleton._player.IdPlayer == 2 && OnMove == false)
        {
            firstIndex = GameManager.singleton.sc2.contSelectionP2;

            if (Input.GetKeyDown(SU2.ChangeSelectionButtonAdd) && CanvasID == 2)
            {
                SetFirstController(firstIndex,false);
                OnMove = true;
            }
            if (Input.GetKeyDown(SU2.ChangeSelectionButtonRemove) && CanvasID == 2)
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

    public void WaitoMove()
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
