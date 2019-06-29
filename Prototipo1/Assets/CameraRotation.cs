using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRotation : MonoBehaviour {

    public Transform cam;
    public PathType pathsystem = PathType.CatmullRom;

    public Vector3[] pathval = new Vector3[3];
	// Use this for initialization
	void Start () {
       
        cam.transform.DOLookAt(new Vector3(5.5f, 0, 5.5f), 1);
        cam.transform.DOPath(pathval, 3, pathsystem);
    }
	
	// Update is called once per frame
	void Update () {
        //cam.transform.DOLookAt(new Vector3(5.5f,0, 5.5f) , 1);
        cam.transform.DOPath(pathval, 3, pathsystem);
    }
}
