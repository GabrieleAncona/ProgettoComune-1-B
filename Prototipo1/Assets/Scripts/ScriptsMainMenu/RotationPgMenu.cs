using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPgMenu : MonoBehaviour {
    public List<RectTransform> currentPosition = new List<RectTransform>();
    public List<RectTransform> nextPosition = new List<RectTransform>();
    public List<RectTransform> size = new List<RectTransform>();
    public float timerRotate = 5;
    public int indexNumber;

    // Use this for initialization
    void Start ()
    {
        ///indexNumber = 0;
        ///transform.SetSiblingIndex(indexNumber);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timerRotate -= Time.deltaTime;
		if(timerRotate <= 5)
        {
            //NextPosition();
            //riazzero contatore
            timerRotate = 0;
            //aumento index
        }
	}

    public void NextPosition(RectTransform _currentPosition)
    {

    }

    public void CheckSize(RectTransform _currentSize)
    {

    }
}
