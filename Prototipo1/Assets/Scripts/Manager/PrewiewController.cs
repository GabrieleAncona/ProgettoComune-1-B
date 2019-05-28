using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrewiewController : MonoBehaviour {
    public RaycastHit hit;
    public GameObject prew;
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       ///RaycastingPrewiewTest();

	}

    /*public void RaycastingPrewiewTest()
    {
         Ray rayRight = new Ray(transform.position, transform.forward);
         

        if(Physics.Raycast(rayRight, out hit, 5))
        {
           
            Instantiate(prew , transform.forward , Quaternion.LookRotation(rayRight.direction));
        }
            
    }*/
}
