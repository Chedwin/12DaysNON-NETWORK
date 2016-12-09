﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    public Canvas inventoryCanvas;

    public Text snowballAmount;
    public Text presentAmount;
    public Text fuelAmount;

    public Weapon[] playerWeapons = new Weapon[3];

 
    public int snowballCount;


    public int presentCount;


    public int fuelCount;

    // Use this for initialization
    void Start() {
        inventoryCanvas.enabled = false;

        snowballCount = 100;
        presentCount = 15;
        fuelCount = 50;

        SetInventoryText();
	}

    public void SetInventoryText()
    {
        snowballAmount.text = snowballCount.ToString();
        presentAmount.text = presentCount.ToString();
        fuelAmount.text = fuelCount.ToString();
    }

    public void UpdateSnowballs(int snowballCount)
    {
        snowballAmount.text = snowballCount.ToString();
    }

    public void UpdatePresents(int presentCount)
    {
        presentAmount.text = presentCount.ToString();
    }

    public void UpdateFuel(int fuelCount)
    {
        fuelAmount.text = fuelCount.ToString();
    }

    public void ToggleInventory(bool toggle)
    {
        inventoryCanvas.enabled = toggle;
    }
}