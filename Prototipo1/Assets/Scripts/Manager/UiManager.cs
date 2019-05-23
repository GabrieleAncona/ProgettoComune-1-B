using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public MainMenùController MainMenu;
    public GamePlayUi _gpmenu;
    public MenuType CurrentMenu =MenuType.nullo;


    public void OpenMenu(MenuType _menuType)
    {
        switch (_menuType)
        {
            case MenuType.MainMenu:
                CurrentMenu = MenuType.MainMenu;
                MainMenu.ToogleMenu(true);
                break;
            case MenuType.GamePlayMenu:
                CurrentMenu = MenuType.GamePlayMenu;
                MainMenu.ToogleMenu(true);
                break;
            case MenuType.PauseMenu:
                CurrentMenu = MenuType.PauseMenu;
                MainMenu.ToogleMenu(true);
                break;
            default:
                break;
        }
    }
}
public enum MenuType
{
    nullo,
    MainMenu,
    GamePlayMenu,
    PauseMenu
};
