using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeUtility2 : MonoBehaviour {
    public AttackBaseUtility2 att;
    public AbilityUtility2 ab;
    public GameObject prewiew;

    // Use this for initialization
    void Awake()
    {

        att = FindObjectOfType<AttackBaseUtility2>();



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
        if (att.isAttack == true)
        {
            prewiew.SetActive(true);
        }
        else if (att.isAttack == false)
        {
            prewiew.SetActive(false);
        }
    }
}
