﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    //The Player Controller Class
    //Manages Every Input the Player can Use, as well as Menus, Weapon Switching, and Movement

    //Enumeration to make Weapon switching easier
    public enum WeaponSlot
    {
        SLOT_ONE,
        SLOT_TWO,
        SLOT_THREE
    }

    //Toggles to turn menus on and off
    public bool toggleInventory;
    public bool toggleMenu;

    //Current Weapon
    public WeaponSlot currentWeaponSlot;

    //Holds pointers to the Body of the player, the Inventory, and the Pause Menu to access them
    public GameObject body;
    public PlayerInventory playerInventory;
    public PauseMenu playerPauseMenu;

    //Movement Speed and Movement Variables
    public float movementSpeed;
    private float translation;
    private float strafe;

	// Use this for initialization
	void Start ()
    {
        //Locks Cursor to Center of Screen
        Cursor.lockState = CursorLockMode.Locked;

        //Sets Menu and Inventory Screens to be Off
        toggleInventory = false;
        toggleMenu = false;

        //Sets Weapon and Toggles Correct Weapon Slot
        currentWeaponSlot = WeaponSlot.SLOT_ONE;
        CmdToggleWeapon();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Get Movement Input
        float translation   = Input.GetAxis("Vertical") * movementSpeed;
        float strafe        = Input.GetAxis("Horizontal") * movementSpeed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        body.transform.Translate(strafe, 0.0f, translation);

        //Get Weapon Switch Input
        if (Input.GetButtonDown("Slot1"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_ONE;
            CmdToggleWeapon();
            //Debug.Log("Switch to Slot 1");
        }
        if (Input.GetButtonDown("Slot2"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_TWO;
            CmdToggleWeapon();
            //Debug.Log("Switch to Slot 2");
        }
        if (Input.GetButtonDown("Slot3"))
        {
            currentWeaponSlot = WeaponSlot.SLOT_THREE;
            CmdToggleWeapon();
            //Debug.Log("Switch to Slot 3");
        }
        if (Input.GetButtonDown("Slot4"))
        {
            //PresentFactory pf = FindObjectOfType<PresentFactory>();
            //pf.CmdMakePresent(this.gameObject);
        }

        if (Input.GetButton("Fire1"))
        {
            CmdFireWeapon(Time.deltaTime);
        }
        else
        {
            CeaseFire();
        }

        //Get Inventory Input
        /*
        if (Input.GetButtonDown("Inventory") && !toggleMenu)
        {
            if (!toggleInventory)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Opening Inventory");
                toggleInventory = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Closing Inventory");
                toggleInventory = false;
            }
            playerInventory.ToggleInventory(toggleInventory);
        }
        */

        //Return Cursor Input
        if (Input.GetButtonDown("Cancel"))
        {
            if (!toggleMenu)
            {
                Cursor.lockState = CursorLockMode.None;
                //Debug.Log("Opening Menu");
                toggleMenu = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                //Debug.Log("Closing Menu");
                toggleMenu = false;
            }
            playerPauseMenu.ToggleVisibility(toggleMenu);
        }
	}

    //Switches Between Weapons
    void CmdToggleWeapon()
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    playerInventory.playerWeapons[0].Hide(false);
                    playerInventory.playerWeapons[1].Hide(true);
                    playerInventory.playerWeapons[2].Hide(true);
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    playerInventory.playerWeapons[0].Hide(true);
                    playerInventory.playerWeapons[1].Hide(false);
                    playerInventory.playerWeapons[2].Hide(true);
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    playerInventory.playerWeapons[0].Hide(true);
                    playerInventory.playerWeapons[1].Hide(true);
                    playerInventory.playerWeapons[2].Hide(false);
                    break;
                }
        }
    }

    //Fires Active Weapon
    void CmdFireWeapon(float deltaTime)
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    playerInventory.playerWeapons[0].Fire(playerInventory, deltaTime);
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    playerInventory.playerWeapons[1].Fire(playerInventory, deltaTime);
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    playerInventory.playerWeapons[2].Fire(playerInventory, deltaTime);
                    break;
                }
        }
    }

    //Calls the CeaseFire of the Active Weapon
    void CeaseFire()
    {
        switch (currentWeaponSlot)
        {
            case WeaponSlot.SLOT_ONE:
                {
                    playerInventory.playerWeapons[0].CeaseFire();
                    break;
                }
            case WeaponSlot.SLOT_TWO:
                {
                    playerInventory.playerWeapons[1].CeaseFire();
                    break;
                }
            case WeaponSlot.SLOT_THREE:
                {
                    playerInventory.playerWeapons[2].CeaseFire();
                    break;
                }
        }
    }
}
