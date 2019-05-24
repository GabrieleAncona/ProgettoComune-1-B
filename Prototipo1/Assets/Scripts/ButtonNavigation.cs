using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class ButtonNavigation : MonoBehaviour
{
    public int index = 0;
    public int totButton = 4;
    public float offset = 1f;
    public Image movement;
    public Image attack;
    public Image ability;
    public Image back;

    // Use this for initialization
    void Start () {

        movement = GetComponent<Image>();
        attack = GetComponent<Image>();
        ability = GetComponent<Image>();
        back = GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        ChangeButtonNavigation();
        ConfirmButtonSelection();
        ChangeImageButton();

	}

    public void ChangeButtonNavigation()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index <= totButton)
            {
                index++;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index > 0)
            {
                index--;
            }
        }
    }

    public void ChangeImageButton()
    {
        if (index == 0)
        {
            ///illumino icona movimento
        }

        if (index == 1)
        {
            ///illumino icona attacco base
        }

        if (index == 2)
        {
            ///illumino icona abilita
        }

        if (index == 3)
        {
            ///illumino icona back
        }
    }

    public void ConfirmButtonSelection()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                ///attivo movimento
                ///disattivo altri bottoni
            }

            if (index == 1)
            {
                ///attivo attaco
                ///disattivo altri bottoni
            }

            if (index == 2)
            {
                ///attivo abilita
                ///disattivo altri bottoni
            }

            if (index == 3)
            {
                ///attivo back
                ///disattivo altri bottoni
            }
        }
    }
}
