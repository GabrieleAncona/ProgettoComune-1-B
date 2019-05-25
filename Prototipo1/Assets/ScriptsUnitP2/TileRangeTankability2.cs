using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRangeTankability2 : MonoBehaviour {
    public AbilityTank2 ab;
    public GameObject prewiew;

    // Use this for initialization

    private void Awake()
    {
        prewiew.SetActive(true);
    }

    void Start()
    {

        ab = FindObjectOfType<AbilityTank2>();


        prewiew.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        SetTileRange();
    }

    public void SetTileRange()
    {
        if (ab.isAbility == true)
        {
            prewiew.SetActive(true);
        }
        else if (ab.isAbility == false)
        {
            prewiew.SetActive(false);
        }
    }
}
