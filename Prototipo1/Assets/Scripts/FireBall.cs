using System.Collections;
using System.Collections.Generic;
using GridSystem;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public AbilityDealer ab;
    public GameObject firecross;

    public int Damage;

    public bool exploded = false;

    void Start()
    {

        ab = FindObjectOfType<AbilityDealer>();

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
                spwanCross();
                exploded = true;
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
                spwanCross();
                exploded = true;
                break;

            case "Obstacle":
                Destroy(gameObject);
                break;

            case "SelectorFire":
                spwanCross();
                Destroy(gameObject);
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
