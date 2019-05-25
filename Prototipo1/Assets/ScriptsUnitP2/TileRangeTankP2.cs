using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TileRangeTankP2 : MonoBehaviour {
   
    public AttackBase2 att;
    public GameObject prewiew;


    // Use this for initialization
    void Awake()
    {

        att = FindObjectOfType<AttackBase2>();
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        prewiew.SetActive(true);
    }

    public void Start()
    {
        prewiew.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //prewiew.SetActive(false);
        SetTileRange();


    }

    public void SetTileRange()
    {
        if (att.isAttack == true)
        {

            //gameObject.GetComponent<MeshRenderer>().enabled = true;
            prewiew.SetActive(true);
        }
        else if (att.isAttack == false)
        {
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            prewiew.SetActive(false);
        }
    }

}
