using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class HudManagerTest : MonoBehaviour {
    public Text tankMp;
    //public Text Turn;
    public Text lifeTP1;
    public Text lifeHP1;
    public Text healerMp;
    public Text healerMpP2;
    public Text tankMpP2;
    public Text lifeTP2;
    public Text lifeHP2;
    public TurnManager turn;
    public LifeManager lm;
    public PositionTester tankP1;
    public PositionHealer healerP1;
    public PositionHealer2 healerP2;
    public PositionTester2 tankP2;
    public Slider healthTankP1;
    public Slider healthTankP2;
    public Slider MpTankP1;
    public Slider MpTankP2;
    public Slider healthHealerP1;
    public Slider healthHealerP2;
    public Slider MpHealerP1;
    public Slider MpHealerP2;
    public SelectionController selection;
    public SelectControllerP2 selectionP2;
    public Text turnText;
    public Color newColor1;
    public Color newColor2;
    public float sec = 3f;

    // Use this for initialization
    void Start () {

        healerP1 = FindObjectOfType<PositionHealer>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        tankP2 = FindObjectOfType<PositionTester2>();
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
        selection = FindObjectOfType<SelectionController>();
        selectionP2 = FindObjectOfType<SelectControllerP2>();

	}
	
	// Update is called once per frame
	void Update () {

        SetSliderTankP1();
        SetSliderHealerP1();
        SetSliderTankP2();
        SetSliderHealerP2();
        SetTextTurn();
    }

    public void SetSliderTankP1()
    {
        tankMp.text = tankP1.contMp.ToString();
        lifeTP1.text = lm.lifeTank.ToString();
        if (selection.isActiveTank == true)
        {
            MpTankP1.value = tankP1.contMp;
        }
        healthTankP1.value = lm.lifeTank;

    }

    public void SetSliderHealerP1()
    {
        if (selection.isActiveHealer == true)
        {
            MpHealerP1.value = healerP1.contMp;
        }
        healthHealerP1.value = lm.lifeHealer;
        healerMp.text = healerP1.contMp.ToString();
        lifeHP1.text = lm.lifeHealer.ToString();
    }

    public void SetSliderTankP2()
    {
        tankMpP2.text = tankP2.contMp.ToString();
        lifeTP2.text = lm.lifeTankPlayer2.ToString();
        if (selectionP2.isActiveTankP2 == true)
        {
            MpTankP2.value = tankP2.contMp;
        }
        healthTankP2.value = lm.lifeTankPlayer2;

    }

    public void SetSliderHealerP2()
    {
        if (selectionP2.isActiveHealerP2 == true)
        {
            MpHealerP2.value = healerP2.contMp;
        }
        healthHealerP2.value = lm.lifeHealerPlayer2;
        healerMpP2.text = healerP2.contMp.ToString();
        lifeHP2.text = lm.lifeHealerPlayer2.ToString();
    }


    public void SetTextTurn()
    {
        if (turn.isTurn == true) {

            turnText.text = "Turno Player 1";
            turnText.color = newColor1;
         }
        else if(turn.isTurn == false)
        {
           
            turnText.text = "Turno Player 2";
            turnText.color = newColor2;
        }
    }
}
