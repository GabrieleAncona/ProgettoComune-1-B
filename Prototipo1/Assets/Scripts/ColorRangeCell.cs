using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class ColorRangeCell : MonoBehaviour {
    private Transform floor;
    public AttackBase1 attTankP1;
    public List<Transform> Tiles = new List<Transform>();

	// Use this for initialization
	void Start () {


        attTankP1 = FindObjectOfType<AttackBase1>();

	}
	
	// Update is called once per frame
	void Update () {

        SetColor();

	}

    public void SetColor()
    {
        if(attTankP1.isAttack == true)
        {
            foreach(Transform tiles in Tiles)
            {
                if(tiles.position.x == attTankP1.RangeHzHealer)
                {
                    Debug.Log("cazzo si");
                }
            }
    
       
        }
    }

}
