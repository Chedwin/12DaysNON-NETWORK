using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PresentFactory : MonoBehaviour
{
    //Present Factory - Factory Design Pattern
    //Creates Presents when given a GameObject, it reads thier position, creates a randomly generated Present at that location with random properties

    //List of available Prefabs for Presents
    public List<GameObject> presentBoxPrefabs;

    //Different Present Types
    private enum PresentType
    {
        CAKE,
        AMMO
    }

    //Command to Make a Present
    public void CmdMakePresent(GameObject gObject)
    {
        //Randomly Generates Present Box Type and Chooses a Prefab to use as a base
        PresentType pBType = (PresentType)UnityEngine.Random.Range(0, 2);
        int pBoxModel = UnityEngine.Random.Range(0, presentBoxPrefabs.Count);

        //Creates the Box at the GameObject's position and rotation
        GameObject Box = (GameObject)Instantiate(presentBoxPrefabs[pBoxModel], gObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f), gObject.transform.rotation);

        switch (pBType)
        {
            case (PresentType.AMMO):
                {
                    //Creates Ammo Box
                    AmmoPresentBox aBox = Box.AddComponent<AmmoPresentBox>();
                    aBox.name = "Ammo Box";
                    break;
                }
            case (PresentType.CAKE):
                {
                    //Creates Cake Box
                    HealthPresentBox hBox = Box.AddComponent<HealthPresentBox>();
                    hBox.name = "Health Box";
                    break;
                }
            default:
                {
                    Debug.Log("Please Check Factory, Something went Wrong.");
                    break;
                }
        }
    }

}
