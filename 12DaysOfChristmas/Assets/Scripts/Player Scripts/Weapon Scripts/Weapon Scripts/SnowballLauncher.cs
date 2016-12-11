using UnityEngine;
using System.Collections;

public class SnowballLauncher : Weapon {

    //Snowball Launcher, the most useful weapon in the game

    //Projectile Speed
    public float projectileSpeed;

    //Projectile Information
    public Rigidbody projectilePrefab;
    public Transform projectileSpawn;

    //Subobjects
    public GameObject cylinder;
    public GameObject lights;

    //Firerate
    private float elaspedTime;
    private float timeBetweenShots = 0.15f;

    //Method override of Hide
    public override void Hide(bool toggle)
    {
        if (toggle)
        {
            cylinder.GetComponent<Renderer>().enabled = false;
            lights.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            cylinder.GetComponent<Renderer>().enabled = true;
            lights.GetComponent<Renderer>().enabled = true;
        }
    }

    //Method override of Fire
    public override void Fire(PlayerInventory playerInv, float deltaTime)
    {
        elaspedTime += deltaTime;
        if (elaspedTime >= timeBetweenShots)
        {
            if (playerInv.snowballCount - 1 >= 0)
            {
                Rigidbody proj = (Rigidbody)Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
                proj.AddForce(projectileSpawn.transform.forward * projectileSpeed, ForceMode.Impulse);
                Destroy(proj.gameObject, 1);
                playerInv.snowballCount -= 1;
            }
            elaspedTime = 0.0f;
        }

    }

    //Method override CeaseFire
    public override void CeaseFire()
    {
        //Do Nothing
    }

}
