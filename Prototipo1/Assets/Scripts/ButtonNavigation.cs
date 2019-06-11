﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class ButtonNavigation : MonoBehaviour
{
    public int index = 0;
    public int totButton = 3;
    public float offset = 1f;
    public List<Sprite> MovementSprite = new List<Sprite>();
    public List<Sprite> AttackSprite = new List<Sprite>();
    public List<Sprite> AbilitySprite = new List<Sprite>();
    public List<Sprite> BackSprite = new List<Sprite>();
    public List<GameObject> text = new List<GameObject>();
    public ActionMenuController AMC;
    public Image movement;
    public Image attack;
    public Image ability;
    public Image back;

    // Use this for initialization
    void Start ()
    {
        AMC = FindObjectOfType<ActionMenuController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangeButtonNavigation();
        ConfirmButtonSelection();
        //ChangeImageButton();
	}

    public void ChangeButtonNavigation()
    {
        if (GameManager.singleton.acm.isActionMenu == true)
        {
            if (GameManager.singleton._player.IdPlayer == 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (index < totButton)
                    {
                        index++;
                    }
                    else if (index == totButton)
                    {
                        index = 0;
                    }
                    ChangeImageButton();
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else if (index == 0)
                    {
                        index = totButton;
                    }
                    ChangeImageButton();
                }  
            }

            if (GameManager.singleton._player.IdPlayer == 2)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (index < totButton)
                    {
                        index++;
                    }
                    else if (index == totButton)
                    {
                        index = 0;
                    }
                    ChangeImageButton();
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else if (index == 0)
                    {
                        index = totButton;
                    }
                    ChangeImageButton();
                }
            }
        }
    }

    public void ChangeImageButton()
    {
        if (index == 0)
        {
            ///illumino icona movimento
            back.sprite = BackSprite[1];
            movement.sprite = MovementSprite[0];
            attack.sprite = AttackSprite[1];
            text[index].SetActive(true);
            text[3].SetActive(false);
            text[index+1].SetActive(false);
        }

        if (index == 1)
        {
            ///illumino icona attacco base
            movement.sprite = MovementSprite[1];
            attack.sprite = AttackSprite[0];
            ability.sprite = AbilitySprite[1];
            text[index].SetActive(true);
            text[index - 1].SetActive(false);
            text[index + 1].SetActive(false);
        }

        if (index == 2)
        {
            ///illumino icona abilita
            attack.sprite = AttackSprite[1];
            ability.sprite = AbilitySprite[0];
            back.sprite = BackSprite[1];
            text[index].SetActive(true);
            text[index - 1].SetActive(false);
            text[index + 1].SetActive(false);
        }

        if (index == 3)
        {
            ///illumino icona back
            ability.sprite = AbilitySprite[1];
            back.sprite = BackSprite[0];
            movement.sprite = MovementSprite[1];
            text[index].SetActive(true);
            text[index - 1].SetActive(false);
            text[0].SetActive(false);
        }
    }

    public void ConfirmButtonSelection()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 0)
            {
                ///attivo movimento
                AMC.Movement();
                ///disattivo tutti gli altri 
                attack.sprite = AttackSprite[2];
                ability.sprite = AbilitySprite[2];
                back.sprite = BackSprite[2];
            }

            if (index == 1)
            {
                ///attivo attaco
                AMC.Attack();
                ///disattivo tutti gli altri 
                movement.sprite = MovementSprite[2];
                ability.sprite = AbilitySprite[2];
                back.sprite = BackSprite[2];
            }

            if (index == 2)
            {
                ///attivo abilita
                AMC.Ability();
                ///disattivo tutti gli altri 
                movement.sprite = MovementSprite[2];
                attack.sprite = AttackSprite[2];
                back.sprite = BackSprite[2];
            }

            if (index == 3)
            {
                ///attivo back
                if (GameManager.singleton._player.IdPlayer == 1)
                {
                    AMC.BackSelectionPlayer1();
                }
                if (GameManager.singleton._player.IdPlayer == 2)
                {
                    AMC.BackSelectionPlayer2();
                }
            }
        }
    }

    public void ResetImageButton()
    {

        movement.sprite = MovementSprite[0];
        attack.sprite = AttackSprite[0];
        ability.sprite = AbilitySprite[0];
        back.sprite = BackSprite[0];

    }
}
