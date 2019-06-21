using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GridSystem;

public class LifeManager : MonoBehaviour
{
    public int lifeTank;
    public int lifeHealer;
    public int lifeUtility;
    public int lifeDealer;
    public int lifeMaxHealer;
    public int lifeMaxUtility;
    public int lifeMaxDealer;
    public int lifeHealerPlayer2;
    public int lifeUtilityPlayer2;
    public int lifeDealerPlayer2;
    public int lifeMaxHealerPlayer2;
    public int lifeMaxUtilityPlayer2;
    public int lifeMaxDealerPlayer2;
    public int lifeTankPlayer2;
    public int lifeMaxTank;
    public int lifeMaxTankPlayer2;


    [SerializeField]
    internal UnitsData unitsData;
    // Use this for initialization
    void Start () {

        lifeDealer = 12;
        lifeUtility = 14;
        lifeMaxUtility = lifeUtility;
        lifeMaxDealer = lifeDealer;
        lifeTank = 20;
        lifeHealer = 9;
        lifeTankPlayer2 = 20;
        lifeHealerPlayer2 = 9;
        lifeMaxTank = lifeTank;
        lifeMaxTankPlayer2 = lifeTankPlayer2;
        lifeMaxHealer = lifeHealer;
        lifeMaxHealerPlayer2 = lifeHealerPlayer2;
        lifeDealerPlayer2 = 12;
        lifeUtilityPlayer2 = 14;
        lifeMaxUtilityPlayer2 = lifeUtilityPlayer2;
        lifeMaxDealerPlayer2 = lifeDealerPlayer2;



    }

    // Update is called once per frame
    void Update () 
    {

       VictoryPlayer1();
       VictoryPlayer2();

    }



    public void VictoryPlayer1()
    {

        if (lifeDealer <= 0 && lifeUtility <= 0 && lifeHealer <= 0 && lifeTank <= 0)
        {
            SceneManager.LoadScene("VittoriaPlayer1");
        }

    }

    public void VictoryPlayer2()
    {

        if (lifeDealerPlayer2 <= 0 && lifeUtilityPlayer2 <= 0 && lifeHealerPlayer2 <= 0 && lifeTankPlayer2 <= 0)
        {
            SceneManager.LoadScene("VittoriaPlayer2");
        }

    }

    
    public int DamageAttack(int _damage)
    {
        _damage = unitsData.damageAttackBase;
        unitsData.life -= _damage;

        return _damage;
    }

   /* public int DamageAbility(int _dmg)
    {
        _dmg = unitsData.damageAbility;
        unitsData.life -= _dmg;

        return _dmg;
    }*/

     /*void RemoveLife(UnitController unit)
    {

        unit.pedina.life -= DamageAttack();

         
    }*/
}
