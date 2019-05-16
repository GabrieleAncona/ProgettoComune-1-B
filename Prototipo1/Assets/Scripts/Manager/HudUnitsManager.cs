using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class HudUnitsManager : MonoBehaviour
{
    SelectionUnits SU;
    public int CanvasID;
    public List<HudUnitController> SingleHudUnit = new List<HudUnitController>();
    public List<Transform> HudUnitPosition = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        SU = FindObjectOfType<SelectionUnits>();
    }

    public int firstIndex; 

    // Update is called once per frame
    void Update()
    {

        firstIndex = GameManager.singleton.sc.contSelectionP1;

        if (GameManager.singleton.PL.IdPlayer ==1)
        {
            if (Input.GetKeyDown(SU.ChangeSelectionButtonAdd) && CanvasID == 1)
            {              
                SetFirstController(firstIndex);
            }
            if (Input.GetKeyDown(SU.ChangeSelectionButtonRemove) && CanvasID == 1)
            {
                SetFirstController(firstIndex);
            }
        }
        if (GameManager.singleton.PL.IdPlayer == 2)
        {
            if (Input.GetKeyDown(SU.ChangeSelectionButtonAdd) && CanvasID == 2)
            {
                SetFirstController(firstIndex);
            }
            if (Input.GetKeyDown(SU.ChangeSelectionButtonRemove) && CanvasID == 2)
            {
                SetFirstController(firstIndex);
            }
        }
    }

    public void MoveUnits(List<HudUnitController> OrderedList)
    {
        for (int i = 0; i < OrderedList.Count; i++)
        {
            OrderedList[i].transform.DOMove(HudUnitPosition[i].transform.position, 0.9f);
        }
    }

    public void SetFirstController(int firstUnit)
    {
        List<HudUnitController> newList = new List<HudUnitController>();
        newList.Add(SingleHudUnit[firstUnit - 1]);

        foreach (var item in SingleHudUnit)
        {
            if (item != SingleHudUnit[firstUnit - 1])
                newList.Add(item);
        }
        MoveUnits(newList);
    }
}
