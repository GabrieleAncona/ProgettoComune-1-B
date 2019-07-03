using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackBaseState : StateBehaviourBase
{
    private string m_MyTrigger = "GoToAttack";

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        //ctx.previousState = "AttackBaseState";
        previousStateTrigger = m_MyTrigger;

        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank = true;
            GameManager.singleton.acm.isAttackHealer = true;
            GameManager.singleton.acm.isAttackUtility = true;
            GameManager.singleton.acm.isAttackDealer = true; 
        }

        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank2 = true;
            GameManager.singleton.acm.isAttackHealer2 = true;
            GameManager.singleton.acm.isAttackUtility2 = true;
            GameManager.singleton.acm.isAttackDealer2 = true; 
        }

    }

    public override void OnUpdate()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.SwitchSprite();
            buttonNavigation.text[3].SetActive(false);
            buttonNavigation.text[2].SetActive(false);
            buttonNavigation.text[1].SetActive(true);
            buttonNavigation.text[0].SetActive(false);
        }
        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.SwitchSprite();
            buttonNavigation.text[3].SetActive(false);
            buttonNavigation.text[2].SetActive(false);
            buttonNavigation.text[1].SetActive(true);
            buttonNavigation.text[0].SetActive(false);
        }
    }

    public override void OnExit()
    {
        if (GameManager.singleton.acm.menuActionPlayer1.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank = false;
            GameManager.singleton.acm.isAttackHealer = false;
            GameManager.singleton.acm.isAttackUtility = false;
            GameManager.singleton.acm.isAttackDealer = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.ChangeImageButton();
            if (buttonNavigation.activeatk == true)
            {
                //slide back attack button
                RectTransform movedback = buttonNavigation.attack.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[1].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("attack" + destination2Dback);
                    buttonNavigation.activeatk = false;
                });
            }
        }

        if (GameManager.singleton.acm.menuActionPlayer2.activeSelf == true)
        {
            GameManager.singleton.acm.isAttackTank2 = false;
            GameManager.singleton.acm.isAttackHealer2 = false;
            GameManager.singleton.acm.isAttackUtility2 = false;
            GameManager.singleton.acm.isAttackDealer2 = false;
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.index = 1;
            buttonNavigation.ChangeImageButton();
            if (buttonNavigation.activeatk == true)
            {
                //slide back attack button
                RectTransform movedback = buttonNavigation.attack.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[1].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("attack" + destination2Dback);
                    buttonNavigation.activeatk = false;
                });
            }
        }
    }

}
