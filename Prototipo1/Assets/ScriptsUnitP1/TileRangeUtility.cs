using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeUtility : MonoBehaviour {
   
    public AttackBaseUtility att;
    public AbilityUtility ab;
    public GameObject prewiew;

    // Use this for initialization
    void Awake()
    {

        att = FindObjectOfType<AttackBaseUtility>();
        //ab = FindObjectOfType<AbilityHealer>();


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
