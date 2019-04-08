using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class FireCross : MonoBehaviour {
    public int Damage;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "UnitP2":
                if (other.gameObject.GetComponent<PositionTester2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionTester2>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionHealer2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionHealer2>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionUtility2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionUtility2>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionDealer2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionDealer2>().GetDamage(Damage);
                }
    
                break;

            case "UnitP1":
                if (other.gameObject.GetComponent<PositionTester>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionTester>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionHealer>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionHealer>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionUtility>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionUtility>().GetDamage(Damage);
                }
                else if (other.gameObject.GetComponent<PositionDealer>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionDealer>().GetDamage(Damage);
                }

                break;

            case "Obstacle":
                Destroy(gameObject);
                break;

            case "SelectorFire":
                //Destroy(gameObject);

                break;

        }

        
    }

    void Update()
    {
        StartCoroutine(DestroyOnTime());
    }

    IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
