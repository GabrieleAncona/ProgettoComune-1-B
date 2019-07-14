using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GridSystem; 



public class CameraController : MonoBehaviour {

   
    [SerializeField] public GameObject CameraPlayer1;
    public Rigidbody rb;
    public Transform transform;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    public void RotationCameraPlayer2()
    {
        transform.DOMove(new Vector3(13f, 13f, 13f), 3.0f);
       transform.DOLocalRotate(new Vector3(46f, -135f, 0f), 3.0f);
        
    }

    public void RotationCameraPlayer1()
    {

        transform.DOMove(new Vector3(-3f, 13f, -3f), 3.0f);
        transform.DOLocalRotate(new Vector3(46f, 45f, 0f), 3.0f);



        //transform.DOMove(new Vector3(-0.45f, 5f, -0.45f), 3.0f);
        //transform.DOPath()


    }

}
