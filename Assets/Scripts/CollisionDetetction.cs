using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetetction : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitParticle;
    public static int Score = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBody" && wc.IsAttacking)
        {
            Debug.Log(other.name);
            GameObject Impact =  Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            Destroy(Impact, 2f);
            Score+=1;
        }
        if (other.tag == "EnemyHead" && wc.IsAttacking)
        {
            Debug.Log(other.name);
            GameObject Impact = Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            Destroy(Impact, 2f);
            Score += 5;
        }
    }
}
