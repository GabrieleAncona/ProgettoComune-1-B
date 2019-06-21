using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using DG.Tweening;

public class FireCross : MonoBehaviour {
    public int Damage;
    public PositionTester tankP1;
    public PositionTester2 tankP2;
    public PositionHealer healerP1;
    public PositionHealer2 healerP2;
    public PositionUtility utilityP1;
    public PositionUtility2 utilityP2;
    public PositionDealer dealerP1;
    public PositionDealer2 dealerP2;
    public float strength;
    public int vibrato;

    private void Start()
    {
        vibrato = 10;
        strength = 0.1f;
        tankP1 = FindObjectOfType<PositionTester>();
        tankP2 = FindObjectOfType<PositionTester2>();
        healerP1 = FindObjectOfType<PositionHealer>();
        healerP2 = FindObjectOfType<PositionHealer2>();
        utilityP1 = FindObjectOfType<PositionUtility>();
        utilityP2 = FindObjectOfType<PositionUtility2>();
        dealerP1 = FindObjectOfType<PositionDealer>();
        dealerP2 = FindObjectOfType<PositionDealer2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "UnitP2":
                if (other.gameObject.GetComponent<PositionTester2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionTester2>().GetDamage(Damage);
                    //tankP2.transform.DOShakePosition(2f, strength, vibrato);
                    tankP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionHealer2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionHealer2>().GetDamage(Damage);
                    //healerP2.transform.DOShakePosition(2f, strength, vibrato);
                    healerP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionUtility2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionUtility2>().GetDamage(Damage);
                    //utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                    utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionDealer2>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionDealer2>().GetDamage(Damage);
                    //dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                    dealerP2.hit.transform.GetComponent<Player>().HitAnim();
                }
    
                break;

            case "UnitP1":
                if (other.gameObject.GetComponent<PositionTester>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionTester>().GetDamage(Damage);
                    //tankP1.transform.DOShakePosition(2f, strength, vibrato);
                    tankP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionHealer>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionHealer>().GetDamage(Damage);
                    //healerP1.transform.DOShakePosition(2f, strength, vibrato);
                    healerP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionUtility>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionUtility>().GetDamage(Damage);
                    //utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                    utilityP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionDealer>())
                {
                    Destroy(gameObject);
                    other.GetComponent<PositionDealer>().GetDamage(Damage);
                    //dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                    dealerP1.hit.transform.GetComponent<Player>().HitAnim();
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
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
