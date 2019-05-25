using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeDealer : MonoBehaviour {
    public PositionDealer dealer;
    public AttackBaseDealer att;
    public GameObject prewiew;

    // Use this for initialization
    void Awake()
    {

        att = FindObjectOfType<AttackBaseDealer>();
     


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
