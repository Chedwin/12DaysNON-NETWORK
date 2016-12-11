using UnityEngine;
using System.Collections;

public class HealthPresentBox : PresentBox {

    //When an object Collides with the Box
    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision Registered");

        //Gets the other GameObject
        GameObject hit = col.gameObject;

        //Checks Collision Properties
        if (hit.name != "RobPlayerPrefab")
            return;

        //Gets Player Health
        PlayerHealth pHealth = hit.GetComponent<PlayerHealth>();

        //If Player Health exists
        if (pHealth)
        {
            //Debug.Log("Player Healed");
            pHealth.Heal(OpenBox());
            Destroy(this.gameObject);
        }
    }

    //Method Override of OpenBox
    public override int OpenBox()
    {
        int healingAmount = Random.Range(10, 50);
        return healingAmount;
    }

}
