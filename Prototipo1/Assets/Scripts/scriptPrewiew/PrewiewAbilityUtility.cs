﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrewiewAbilityUtility : MonoBehaviour {

    
    public AbilityUtility ab;
    public GameObject prewiew;

    // Use this for initialization
    void Awake()
    {

        ab = FindObjectOfType<AbilityUtility>();



        prewiew.SetActive(true);
    }

    public void Start()
    {
        prewiew.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        SetTileRangeHealer();
    }

    public void SetTileRangeHealer()
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
