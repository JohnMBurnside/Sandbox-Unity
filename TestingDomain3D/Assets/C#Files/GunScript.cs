using UnityEngine;
public class GunScript : MonoBehaviour
{
    #region VARIABLES
    public float damage = 10;
    public float range = 100;
    public float fireRate = 0.2f;
    public float impactForce = 60;
    public Camera fpsCam;
    public ParticleSystem muzzleEffect;
    public GameObject impactEffect;
    float timer;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > fireRate)
            Shoot();
    }
    #endregion
    //GUN FUNCTIONS
    #region SHOOT FUNCTION
    void Shoot()
    {
        timer = 0;
        muzzleEffect.Play();
        RaycastHit raycastHit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out raycastHit, range))
        {
            EnemyScript enemy = raycastHit.transform.GetComponent<EnemyScript>();
            if (enemy != null)
                enemy.TakeDamage(damage);
            if (raycastHit.rigidbody != null)
                raycastHit.rigidbody.AddForce(-raycastHit.normal * impactForce);
            GameObject impact = Instantiate(impactEffect, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            Destroy(impact, 2f);
        }        
    }
    #endregion
}
