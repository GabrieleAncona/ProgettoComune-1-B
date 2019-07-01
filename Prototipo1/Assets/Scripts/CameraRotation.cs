using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRotation : MonoBehaviour {

    public Transform cam;
    public PathType pathsystem = PathType.CatmullRom;

    public Vector3[] pathval1 = new Vector3[3];
    public Vector3[] pathval2 = new Vector3[3];

    public bool FirstVisual;

    // Use this for initialization
    void Start () {
       
       //cam.transform.DOLookAt(new Vector3(5.5f, 0, 5.5f), 1);
    }
	
	// Update is called once per frame
	void Update () {
        cam.transform.DOLookAt(new Vector3(5.5f,0, 5.5f) , 1);
        //cam.transform.DOPath(pathval, 3, pathsystem);
        Camera();
    }

    public void Camera()
    {
        if (Input.GetKeyDown(KeyCode.Tab) )
        {
            cam.transform.DOPath(pathval1, 3, pathsystem);
            //FirstVisual = false;
        }
        /*else if (Input.GetKeyDown(KeyCode.T) && GameManager.singleton._player.IdPlayer == 1 && FirstVisual == true)
        {
            cam.transform.DOPath(pathval2, 3, pathsystem);
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && GameManager.singleton._player.IdPlayer == 2)
        {
            cam.transform.DOPath(pathval2, 3, pathsystem);
        }

    }*/


    /*
    [SerializeField] private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector3 camPosition;
    [SerializeField] private float speedModifier;
    private bool coroutineAllowed;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

    }

    private void Update()
    {
        cam.transform.DOLookAt(new Vector3(5.5f, 0, 5.5f), 1);
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;
            camPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = camPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;*/
    }
}
