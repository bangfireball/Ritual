using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private float distanceFromGround = 1f;
    private bool isMoving = false;
    public float speed;
    GameObject flashlight;
    GameObject MainCamera;

    Vector3 forwarDir;
    Rigidbody playerRB;

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        flashlight = GameObject.FindGameObjectWithTag("Flashlight");
         playerRB = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Cardboard.SDK.Triggered)
        {
            isMoving = !isMoving;
        }

        //code to move the player if the trigger is pulled 
        //the player will move in the direction that the player is looking. 
        if(isMoving)
        {
            forwarDir = MainCamera.transform.forward;
            forwarDir.y = 0;
            forwarDir.Normalize();
            playerRB.velocity = forwarDir * speed;
        }
        else
        {
            playerRB.velocity = new Vector3(0, 0, 0);
        }


        //GameObject.FindGameObjectWithTag("Player").transform.localRotation
        flashlight.transform.position = MainCamera.transform.position;

	}
}
