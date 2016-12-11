using UnityEngine;
using System.Collections;

public class AmmoPresentBox : PresentBox {

    //When an object Collides with the Box
    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision Registered");

        //Gets the other GameObject
        GameObject hit = col.gameObject;

        //Checks Collision Properties
        if (hit.name != "RobPlayerPrefab")
            return;

        //Gets Player Inventory
        PlayerInventory pInv = hit.GetComponent<PlayerInventory>();
        if (pInv)
        {
            //Debug.Log("Player has Inventory!");
            //Chooses Ammo Type
            int choice = Random.Range(0, 3);
            switch (choice)
            {
                case 0:
                    {
                        pInv.snowballCount += OpenBox();
                        break;
                    }
                case 1:
                    {
                        pInv.presentCount += OpenBox();
                        break;
                    }
                case 2:
                    {
                        pInv.fuelCount += OpenBox();
                        break;
                    }
            }
            //Destroys Self
            Destroy(this.gameObject);
        }
    }

    //Method Override of OpenBox
    public override int OpenBox()
    {
        //Generates and Returns a Random Int
        int ammoAmount = Random.Range(5, 50);
        return ammoAmount;
    }


}
