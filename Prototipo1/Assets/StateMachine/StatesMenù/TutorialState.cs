using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialState : StateBehaviourBase
{
    public int contSlide;
    public override void OnEnter()
    {
        GameManager.singleton.mc.panelGeneralTutorial.SetActive(true);
    }

    public override void OnUpdate()
    {
        IncreasedCont();
        ChangeSlide();
        if (Input.GetKeyDown(GameManager.singleton.mc.helpButton) && GameManager.singleton.mc.isActiveTutorial == true)
        {
            GameManager.singleton.stateMachine.SMController.SetTrigger(StateBehaviourBase.previousStateTrigger);
        }
    }

    public override void OnExit()
    {
        GameManager.singleton.mc.isActiveTutorial = false;
        GameManager.singleton.mc.panelGeneralTutorial.SetActive(false);
        contSlide = 1;
    }

    /// <summary>
    /// funzione per incrementare e decrementare contatore
    /// </summary>
    public void IncreasedCont()
    {
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && contSlide < 3)
        {
            contSlide += 1;
        }
        else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && contSlide > 1)
        {
            contSlide -= 1;
        }
    }

    /// <summary>
    /// funzione per cambiare slide in base al contatore
    /// </summary>
    public void ChangeSlide()
    {
        if (contSlide == 1)
        {
            GameManager.singleton.mc.panelTutorialButtons.SetActive(true);
            GameManager.singleton.mc.panelTutorialStat.SetActive(false);
            GameManager.singleton.mc.panelTutorialUnits.SetActive(false);
        }
        if (contSlide == 2)
        {
            GameManager.singleton.mc.panelTutorialStat.SetActive(true);
            GameManager.singleton.mc.panelTutorialButtons.SetActive(false);
            GameManager.singleton.mc.panelTutorialUnits.SetActive(false);
        }
        if (contSlide == 3)
        {
            GameManager.singleton.mc.panelTutorialUnits.SetActive(true);
            GameManager.singleton.mc.panelTutorialButtons.SetActive(false);
            GameManager.singleton.mc.panelTutorialStat.SetActive(false);
        }
    }

}

