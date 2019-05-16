using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class HudUnitsManager : MonoBehaviour
{
    TurnManager tm;
    public List<HudUnitController> SingleHudUnit = new List<HudUnitController>();
    public List<Transform> HudUnitPosition = new List<Transform>();

    // Use this for initialization
    void Start()
    {

    }

    public int firstIndex = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetFirstController(firstIndex++);
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
