using UnityEngine;

using System.Collections;

public class Weapon : MonoBehaviour {

    public virtual void Hide(bool toggle)
    {
        Debug.Log("Unimplimented");
    }

    public virtual void Fire(PlayerInventory playerInv, float deltaTime)
    {
        Debug.Log("Unimplimented");
    }

    public virtual void CeaseFire()
    {

    }
}
