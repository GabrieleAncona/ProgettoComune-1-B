using UnityEngine;

namespace GridSystem
{

    [CreateAssetMenu(fileName = "new data units", menuName = "data/units", order = 1)]
    public class UnitsData : ScriptableObject
    {
        public Enemytype Enemytype;
        public int life;
        public int damageAttackBase;
        public int damageAbility;
    }

    public enum Enemytype
    {
        tank,
        healer,
        utility,
        dealer

    }

}

