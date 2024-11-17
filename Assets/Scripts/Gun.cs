using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f; //how much damage the gun is going to do (10 default)
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam; //Reference camera

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) //If button pressed and the cooldown is over we can shoot again
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit; //store info
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))//Make a raycast from the position of
                                                                                                //the camera,fowards and store all the
        {                                                                                       //information in the hit Raycast Variable
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>(); //Get the target component on the object that we hit (Stored in a variable)
            if (target != null) // if we found component we make damage
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null) //if its hits something with rigid body it will move it
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //make gameobject of particle effect
            Destroy(impactGO, 2f); //deleat effect
        } 
    }
}
