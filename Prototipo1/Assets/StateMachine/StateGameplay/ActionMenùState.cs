using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActionMenùState : StateBehaviourBase
{

    public override void OnEnter()
    {
        //Debug.LogFormat("SetupState {0} in Init_State", ctx.SetupDone);
        GameManager.singleton.acm.isActionMenu = true;
        //ctx.previousState = "ActionMenuState";
    }

    public override void OnUpdate()
    {
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            GameManager.singleton.acm.menuActionPlayer1.SetActive(true);

            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            if (buttonNavigation.activemov == true)
            {
                //slide back movement button
                RectTransform movedback = buttonNavigation.movement.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[0].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("Movimento " + destination2Dback);
                    buttonNavigation.activemov = false;
                }); 
            }
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
            if (buttonNavigation.activeab == true)
            {
                // slide back ability button
                RectTransform movedback = buttonNavigation.ability.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[2].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("ability" + destination2Dback);
                    buttonNavigation.activeab = false;
                }); 
            }
            buttonNavigation.KeyboardKey1.enabled = true;
            buttonNavigation.KeyboardKey2.enabled = true;
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            GameManager.singleton.acm.menuActionPlayer2.SetActive(true);

            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            if (buttonNavigation.activemov == true)
            {
                //slide back movement button
                RectTransform movedback = buttonNavigation.movement.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[0].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("Movimento " + destination2Dback);
                    buttonNavigation.activemov = false;
                });
            }
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
            if (buttonNavigation.activeab == true)
            {
                // slide back ability button
                RectTransform movedback = buttonNavigation.ability.GetComponent<RectTransform>();
                RectTransform destback = buttonNavigation.slidebacktransform[2].GetComponent<RectTransform>();
                Vector2 destination2Dback = new Vector2(movedback.anchoredPosition.x, destback.anchoredPosition.y);
                movedback.DOLocalMoveY(destination2Dback.y, 0.4f).OnComplete(() =>
                {
                    Debug.Log("ability" + destination2Dback);
                    buttonNavigation.activeab = false;
                });
            }
            buttonNavigation.KeyboardKey1.enabled = true;
            buttonNavigation.KeyboardKey2.enabled = true;
        }
    }

    public override void OnExit()
    {
        GameManager.singleton.acm.isActionMenu = false;
        if (ctx.currentPlayer.IdPlayer == 1)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.KeyboardKey1.enabled = false;
            buttonNavigation.KeyboardKey2.enabled = false;
        }
        if (ctx.currentPlayer.IdPlayer == 2)
        {
            ButtonNavigation buttonNavigation = FindObjectOfType<ButtonNavigation>();
            buttonNavigation.KeyboardKey1.enabled = false;
            buttonNavigation.KeyboardKey2.enabled = false;
        }
    }
}
