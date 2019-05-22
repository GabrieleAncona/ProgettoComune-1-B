using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUnitController : MonoBehaviour
{
    public Image _image;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Zoom();
	}

    public void Zoom()
    {
        if (GameManager.singleton.sc.isActiveTank == true);
        {
            _image.rectTransform.sizeDelta = new Vector2(201.5f, 109.74f);
        }
    }
}
