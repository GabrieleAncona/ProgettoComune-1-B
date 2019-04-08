using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;


public class PositioneTile : MonoBehaviour {
    public int x, y;
    public BaseGrid grid;
    public AttackBase1 positionAtt;
    public Color blue;
    public Material material;

	// Use this for initialization
	void Start () {

        transform.position = grid.GetWorldPosition(x, y);
        positionAtt = FindObjectOfType<AttackBase1>();
    }
	
	// Update is called once per frame
	void Update () {
       transform.position = grid.GetWorldPosition(x, y);
      
    }

   


}
