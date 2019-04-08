using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class CastingManager : MonoBehaviour {
   /* public Camera camera;
    public AttackBase1 att;
    public PositionTester tankP1;

	// Use this for initialization
	void Start () {

        tankP1 = FindObjectOfType<PositionTester>();
        att = FindObjectOfType<AttackBase1>();

	}
	
	// Update is called once per frame
	void Update () {
		if(att.isAttack == true)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(tankP1.transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 200);
            if(Physics.Raycast(ray , out hit) && hit.collider.tag == "Obstacle")
            {
                Debug.Log("funziona" + hit);
               
            }
        }

	}*/
}
