using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class ComandButton : MonoBehaviour {
    public Image imageComand;

     void Start()
    {

        imageComand.GetComponent<Image>().enabled = false;
    }

	public void OpenComand()
    {
        imageComand.GetComponent<Image>().enabled = true;
       
    }

    public void ExitComand()
    {
        imageComand.GetComponent<Image>().enabled = false;
    }
}
