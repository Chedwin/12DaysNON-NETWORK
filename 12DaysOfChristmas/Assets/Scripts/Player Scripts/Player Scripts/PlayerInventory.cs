using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    //Player Inventory Class
    //Handles Weapons, Ammo, Ammo Amounts, and Updating the Ammo Meter

    //Player Controller pointer
    private PlayerController playerController;

    //Ammo Meter
    public GameObject ammoContainer;
    public Text ammoCount;

    //Weapons
    public Weapon[] playerWeapons = new Weapon[3];

    //Ammo Counts
    public int snowballCount;
    public int presentCount;
    public int fuelCount;

    // Use this for initialization
    void Start() {
        //Gets the PlayerController from the GameObject
        this.playerController = this.gameObject.GetComponent<PlayerController>();

        //Activates the Ammo Meter
        ammoContainer.SetActive(true);

        //Sets Starting Ammo
        snowballCount = 400;
        presentCount = 40;
        fuelCount = 500;

        //Updates Ammo Meter
        SetAmmoText();
	}

    // Called Every Frame
    void Update()
    {
        //Sets Ammo Meter
        SetAmmoText();
    }

    //Sets Ammo Meter to have the Ammo of the currently active Weapon
    public void SetAmmoText()
    {
        switch (playerController.currentWeaponSlot)
        {
            case PlayerController.WeaponSlot.SLOT_ONE:
                {
                    ammoCount.text = snowballCount.ToString();
                    break;
                }
            case PlayerController.WeaponSlot.SLOT_TWO:
                {
                    ammoCount.text = presentCount.ToString();
                    break;
                }
            case PlayerController.WeaponSlot.SLOT_THREE:
                {
                    ammoCount.text = fuelCount.ToString();
                    break;
                }
        }
    }

    //Toggles Ammo Meter Visibility
    public void ToggleInventory(bool toggle)
    {
        ammoContainer.SetActive(toggle);
    }
}
