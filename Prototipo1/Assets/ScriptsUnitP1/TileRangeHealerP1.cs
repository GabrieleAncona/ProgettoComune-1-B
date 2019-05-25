using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeHealerP1 : MonoBehaviour {
   
    public AttackBaseHealer att;
    public AbilityHealer ab;
    public GameObject prewiew;

    // Use this for initialization
    void Awake()
    {

        att = FindObjectOfType<AttackBaseHealer>();
        ab = FindObjectOfType<AbilityHealer>();
       
     
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
        if (att.isAttackHealer == true)
        {
            prewiew.SetActive(true);
        }

        else if (att.isAttackHealer == false)
        {
            prewiew.SetActive(false);
        }
    }
   
}
