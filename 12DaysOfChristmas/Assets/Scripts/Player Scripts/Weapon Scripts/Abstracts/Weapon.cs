using UnityEngine;

using System.Collections;

public class Weapon : MonoBehaviour {

    //This is a purely abstract class for use by the Player only
    //Every Weapon inherits from this class

    //This method is meant to Hide the Weapon when switching to another one
    public virtual void Hide(bool toggle)
    {
        //Tells the editor that the inherited class is not overriding the method call
        Debug.Log("Unimplimented");
    }

    //This is called when a Weapon is Fired
    public virtual void Fire(PlayerInventory playerInv, float deltaTime)
    {
        //Tells the editor that the inherited class is not overriding the method call
        Debug.Log("Unimplimented");
    }

    //This one is called when the Weapon stops firing
    public virtual void CeaseFire()
    {
        //Tells the editor that the inherited class is not overriding the method call
        Debug.Log("Unimplimented");
    }
}
