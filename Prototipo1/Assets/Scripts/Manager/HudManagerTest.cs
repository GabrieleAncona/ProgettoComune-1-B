using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using TMPro;

public class HudManagerTest : MonoBehaviour
{
    //public Text tankMp;
    public TMP_Text lifeTP1;
    //public Text AbChargeTP1;
    public TMP_Text lifeHP1;
    //public Text healerMp;
    //public Text AbChargeHP1;
    //public Text utilityMp;
    public TMP_Text lifeUP1;
    //public Text AbChargeUP1;
    //public Text dealerMp;
    public TMP_Text lifeDP1;
    //public Text AbChargeDP1;

    //public Text tankMpP2;
    public TMP_Text lifeTP2;
    //public Text AbChargeTP2;
    //public Text healerMpP2;
    public TMP_Text lifeHP2;
    //public Text AbChargeHP2;
    //public Text utilityMp2;
    public TMP_Text lifeUP2;
    //public Text AbChargeUP2;
    //public Text dealerMp2;
    public TMP_Text lifeDP2;
    //public Text AbChargeDP2;
    
    //public TurnManager turn;
    public LifeManager lm;
    public TurnManager turn;
    public Color newColor1;
    public Color newColor2;
    public Text turnText;
    /*public PositionTester tankP1;
    public PositionHealer healerP1;
    public PositionUtility utilityP1;
    public PositionDealer dealerP1;
    public PositionHealer2 healerP2;
    public PositionTester2 tankP2;
    public PositionUtility2 utilityP2;
    public PositionDealer2 dealerP2;
    public AbilityTank abTankP1;
    public AbilityHealer abHealerP1;
    public AbilityUtility abUtilityP1;
    public AbilityDealer abDealerP1;
    public AbilityTank2 abTankP2;
    public AbilityHealer2 abHealerP2;
    public AbilityUtility2 abUtilityP2;
    public AbilityDealer2 abDealerP2;*/

    public Slider healthTankP1;
    public Slider healthTankP2;
    //public Slider MpTankP1;
    //public Slider MpTankP2;
    //public Slider abChargeTP1;
    //public Slider abChargeTP2;
    public Slider healthHealerP1;
    public Slider healthHealerP2;
    //public Slider MpHealerP1;
    //public Slider MpHealerP2;
    //public Slider abChargeHP1;
    //public Slider abChargeHP2;
    public Slider healthUtilityP1;
    public Slider healthUtilityP2;
    //public Slider MpUtilityP1;
    //public Slider MpUtilityP2;
    //public Slider abChargeUP1;
    //public Slider abChargeUP2;
    public Slider healthDealerP1;
    public Slider healthDealerP2;
    //public Slider MpDealerP1;
    //public Slider MpDealerP2;
    //public Slider abChargeDP1;
    //public Slider abChargeDP2;
    //public Slider passTurnP1;
    //public Slider passTurnP2;

    /*public SelectionController selection;
    public SelectControllerP2 selectionP2;
    public InputController InputPassTurn;
    public Text turnText;
    public Color newColor1;
    public Color newColor2;
    public float sec = 3f;*/

    // Use this for initialization
    void Start ()
    {
        /*healerP1 = FindObjectOfType<PositionHealer>();
        tankP1 = FindObjectOfType<PositionTester>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        tankP2 = FindObjectOfType<PositionTester2>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
        abTankP1 = FindObjectOfType<AbilityTank>();
        abHealerP1 = FindObjectOfType<AbilityHealer>();
        abUtilityP1 = FindObjectOfType<AbilityUtility>();
        abDealerP1 = FindObjectOfType<AbilityDealer>();
        abTankP2 = FindObjectOfType<AbilityTank2>();
        abHealerP2 = FindObjectOfType<AbilityHealer2>();
        abUtilityP2 = FindObjectOfType<AbilityUtility2>();
        abDealerP2 = FindObjectOfType<AbilityDealer2>();
        turn = FindObjectOfType<TurnManager>();
        selection = FindObjectOfType<SelectionController>();
        selectionP2 = FindObjectOfType<SelectControllerP2>();
        InputPassTurn = FindObjectOfType<InputController>();*/
        lm = FindObjectOfType<LifeManager>();
        turn = FindObjectOfType<TurnManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetSliderTankP1();
        SetSliderHealerP1();
        SetSliderUtilityP1();
        SetSliderDealerP1();
        SetSliderTankP2();
        SetSliderHealerP2();
        SetSliderUtilityP2();
        SetSliderDealerP2();
        //SetSliderTurnP1();
        //SetSliderTurnP2();
        //SetTextTurn();

    }

    public void SetSliderTankP1()
    {
        //tankMp.text = tankP1.contMp.ToString();
        lifeTP1.text = lm.lifeTank.ToString();
        /*miniBarTankP1.value = lm.lifeTank;
        AbChargeTP1.text = abTankP1.Counter.ToString();
        if (selection.isActiveTank == true)
        {
            MpTankP1.value = tankP1.contMp;
            abChargeTP1.value = abTankP1.Counter;
        }*/
        healthTankP1.value = lm.lifeTank;
    }
    public void SetSliderHealerP1()
    {
        //miniBarHealerP1.value = lm.lifeHealer;
        //healerMp.text = healerP1.contMp.ToString();
        lifeHP1.text = lm.lifeHealer.ToString();
        /*AbChargeHP1.text = abHealerP1.Counter.ToString();
        if (selection.isActiveHealer == true)
        {
            MpHealerP1.value = healerP1.contMp;
            abChargeHP1.value = abHealerP1.Counter;
        }*/
        healthHealerP1.value = lm.lifeHealer;
    }
    public void SetSliderUtilityP1()
    {
        /*if (selection.isActiveUtility == true)
        {
            MpUtilityP1.value = utilityP1.contMp;
            abChargeUP1.value = abUtilityP1.Counter;
        }
        miniBarUtilityP1.value = lm.lifeUtility;
        utilityMp.text = utilityP1.contMp.ToString();*/
        lifeUP1.text = lm.lifeUtility.ToString();
        healthUtilityP1.value = lm.lifeUtility;
    }
    public void SetSliderDealerP1()
    {
        /*if (selection.isActiveDealer == true)
        {
            MpDealerP1.value = dealerP1.contMp;
            abChargeDP1.value = abDealerP1.CounterA;
        }
        miniBarDealerP1.value = lm.lifeDealer;
        dealerMp.text = dealerP1.contMp.ToString();*/
        lifeDP1.text = lm.lifeDealer.ToString();
        healthDealerP1.value = lm.lifeDealer;
    }

    public void SetSliderTankP2()
    {
        //tankMpP2.text = tankP2.contMp.ToString();
        lifeTP2.text = lm.lifeTankPlayer2.ToString();
        /*miniBarTankP2.value = lm.lifeTankPlayer2;
        AbChargeTP2.text = abTankP2.Counter.ToString();
        if (selectionP2.isActiveTankP2 == true)
        {
            MpTankP2.value = tankP2.contMp;
            abChargeTP2.value = abTankP2.Counter;
        }*/
        healthTankP2.value = lm.lifeTankPlayer2;
    }
    public void SetSliderHealerP2()
    {
        /*if (selectionP2.isActiveHealerP2 == true)
        {
            MpHealerP2.value = healerP2.contMp;
            abChargeHP2.value = abHealerP2.Counter;
        }
        miniBarHealerP2.value = lm.lifeHealerPlayer2;
        healerMpP2.text = healerP2.contMp.ToString();*/
        lifeHP2.text = lm.lifeHealerPlayer2.ToString();
        healthHealerP2.value = lm.lifeHealerPlayer2;
    }
    public void SetSliderUtilityP2()
    {
        /*if (selectionP2.isActiveUtilityP2 == true)
        {
            MpUtilityP2.value = utilityP2.contMp;
            abChargeUP2.value = abUtilityP2.Counter;
        }
        miniBarUtilityP2.value = lm.lifeUtilityPlayer2;
        utilityMp2.text = utilityP2.contMp.ToString();*/
        lifeUP2.text = lm.lifeUtilityPlayer2.ToString();
        healthUtilityP2.value = lm.lifeUtilityPlayer2;
    }
    public void SetSliderDealerP2()
    {
        /*if (selectionP2.isActiveDealerP2 == true)
        {
            MpDealerP2.value = dealerP2.contMp;
            abChargeDP2.value = abDealerP2.CounterA;
        }
        miniBarDealerP2.value = lm.lifeDealerPlayer2;
        dealerMp2.text = dealerP2.contMp.ToString();*/
        lifeDP2.text = lm.lifeDealerPlayer2.ToString();
        healthDealerP2.value = lm.lifeDealerPlayer2;
    }

    /*public void SetSliderTurnP1()
    {
        passTurnP1.value = InputPassTurn.timer;
    }
    public void SetSliderTurnP2()
    {
        passTurnP2.value = InputPassTurn.timer;
    }*/

    /*public void SetTextTurn()
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
    }*/
}
