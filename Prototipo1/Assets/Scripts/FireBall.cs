using System.Collections;
using System.Collections.Generic;
using GridSystem;
using UnityEngine;
using DG.Tweening;

public class FireBall : MonoBehaviour
{
    public AbilityDealer ab;
    public GameObject firecross;
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

    public int Damage;

    public bool exploded = false;

    void Start()
    {
        vibrato = 10;
        strength = 0.1f;
        ab = FindObjectOfType<AbilityDealer>();
        tankP1 = FindObjectOfType<PositionTester>();
        healerP1 = FindObjectOfType<PositionHealer>();
        tankP2 = FindObjectOfType<PositionTester2>();
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
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionTester2>().GetDamage(Damage);
                    //tankP2.transform.DOShakePosition(2f, strength, vibrato);
                    //tankP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionHealer2>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionHealer2>().GetDamage(Damage);
                    //healerP2.transform.DOShakePosition(2f, strength, vibrato);
                   // healerP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionUtility2>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionUtility2>().GetDamage(Damage);
                    //utilityP2.transform.DOShakePosition(2f, strength, vibrato);
                   // utilityP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionDealer2>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionDealer2>().GetDamage(Damage);
                    //dealerP2.transform.DOShakePosition(2f, strength, vibrato);
                   // dealerP2.hit.transform.GetComponent<Player>().HitAnim();
                }
                spwanCross();
                exploded = true;
                break;

            case "UnitP1":
                if (other.gameObject.GetComponent<PositionTester>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionTester>().GetDamage(Damage);
                    //tankP1.transform.DOShakePosition(2f, strength, vibrato);
                   // tankP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionHealer>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionHealer>().GetDamage(Damage);
                    //healerP1.transform.DOShakePosition(2f, strength, vibrato);
                    //healerP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionUtility>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionUtility>().GetDamage(Damage);
                    //utilityP1.transform.DOShakePosition(2f, strength, vibrato);
                    //utilityP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                else if (other.gameObject.GetComponent<PositionDealer>())
                {
                    Destroy(gameObject);
                    SoundManager.PlaySound(SoundManager.Sound.esplosione);
                    other.GetComponent<PositionDealer>().GetDamage(Damage);
                    //dealerP1.transform.DOShakePosition(2f, strength, vibrato);
                   // dealerP1.hit.transform.GetComponent<Player>().HitAnim();
                }
                spwanCross();
                exploded = true;
                break;

            case "Obstacle":
                Destroy(gameObject);
                SoundManager.PlaySound(SoundManager.Sound.esplosione);
                break;

            case "SelectorFire":
                spwanCross();
                Destroy(gameObject);
                SoundManager.PlaySound(SoundManager.Sound.esplosione);
                exploded = true;
                
                break;

        }
    }
        public void spwanCross()
        {
            Instantiate(firecross , Vector3.forward + ab.selector.transform.position, Quaternion.identity);
            Instantiate(firecross, Vector3.back + ab.selector.transform.position, Quaternion.identity);
            Instantiate(firecross, Vector3.left + ab.selector.transform.position, Quaternion.identity);
            Instantiate(firecross, Vector3.right + ab.selector.transform.position, Quaternion.identity);
        //Instantiate(firecross, -transform.forward + new Vector3(transform.position.x - 1, 0.5f, transform.position.z), Quaternion.identity);
        //Instantiate(firecross, -transform.right + new Vector3(transform.position.x, 0.5f, transform.position.z - 1 ), Quaternion.identity);
        //Instantiate(firecross, transform.right + new Vector3(transform.position.x, 0.5f, transform.position.z + 1), Quaternion.identity);


    }
}
