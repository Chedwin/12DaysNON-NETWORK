using UnityEngine;
using System.Collections;

public class Flamethrower : Weapon {

    //Flamethrower Class, Manages the Flamethrower Object and the Flame Particle System

    //The Flame Partice System
    public ParticleSystem Flame;

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

    //Method Override of Fire, deducts fuel over time, and activates Particle System
    public override void Fire(PlayerInventory playerInv, float deltaTime)
    {
        if (playerInv.fuelCount - 1 >= 0)
        {
            //Starts Particles
            Flame.Play();
            playerInv.fuelCount -= 1;
        }
    }

    //Method Overrid of CeaseFire, stops Particle System
    public override void CeaseFire()
    {
        //Stops Particles
        Flame.Stop();
    }
}
