using UnityEngine;
using System.Collections;

public class PresentLauncher : Weapon {

    //Present Launcher Class, Manages Presents thrown and how they spawn

    //Projectile Speed
    public float projectileSpeed;

    //Present Prefab and Direction/Location of thier Spawning
    public Rigidbody presentPrefab;
    public Transform projectileSpawn;

    //Shot Cooldown
    private float elapsedTime;
    private float timeBetweenShots = 0.5f;

    //Method Override of Hide
    public override void Hide(bool toggle)
    {
        if (toggle)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    //Method Override for Fire, Spawns Present, applies Force and decrements ammo count
    public override void Fire(PlayerInventory playerInv, float deltaTime)
    {
        elapsedTime += deltaTime;
        if (elapsedTime >= timeBetweenShots)
        {
            if (playerInv.presentCount - 1 >= 0)
            {
                Rigidbody proj = (Rigidbody)Instantiate(presentPrefab, projectileSpawn.position, projectileSpawn.rotation);
                proj.AddForce(projectileSpawn.transform.forward * projectileSpeed, ForceMode.Impulse);
                Destroy(proj.gameObject, 2);
                playerInv.presentCount -= 1;
            }
            elapsedTime = 0.0f;
        }
    }

    //Method Override for CeaseFire
    public override void CeaseFire()
    {
        //Does Nothing
    }

}
