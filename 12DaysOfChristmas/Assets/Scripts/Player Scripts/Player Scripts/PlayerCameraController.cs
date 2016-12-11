using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour {

    //Player Camera Controller
    //Allows the Player to move their camera and look around

    //Gets Mouse Position and Smoothing Vector
    Vector2 mouseLook;
    Vector2 smoothingVector;

    //Movement variables
    public float sensitivity;
    public float smoothing;

    //Host PlayerCharacter
    GameObject playerCharacter;

	// Use this for initialization
	void Start () {
        //Sets playerCharacter as the parent of the Camera Object
        playerCharacter = this.transform.parent.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //Camera Control Script
        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothingVector.x = Mathf.Lerp(smoothingVector.x, mouseDirection.x, 1.0f / smoothing);
        smoothingVector.y = Mathf.Lerp(smoothingVector.y, mouseDirection.y, 1.0f / smoothing);
        mouseLook += smoothingVector;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -25.0f, 15.0f);

        //Rotates Camera and Parent Body to match Horizontal and Vertical Changes
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerCharacter.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
	}
}
