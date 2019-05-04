using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GridSystem;


public class CameraController : MonoBehaviour {
    

    public void RotationCameraPlayer2()
    {
        transform.DOMove(new Vector3(13.54f, 10.04f, 15.02f), 3.0f);
        transform.DOLocalRotate(new Vector3(33.2f, -137f, 0f), 3.0f);
    }

    public void RotationCameraPlayer1()
    {
        transform.DOMove(new Vector3(-0.45f, 5f, -0.45f), 3.0f);
        transform.DOLocalRotate(new Vector3(30f, 45f, 0f), 3.0f);
    }
}
