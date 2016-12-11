using UnityEngine;

using System.Collections;

public class PresentBox : MonoBehaviour {

    //Parent class of every Present Box, for the use of the Present Factory Only

    //Virtual Method of OpenBox
    public virtual int OpenBox()
    {
        Debug.Log("Unimplimented");
        return 0;
    }

}
