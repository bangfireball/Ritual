using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private float distanceFromGround = 1f;
    private bool isMoving = false;
    public float speed;

    Vector3 forwarDir;
    Rigidbody playerRB;

	// Use this for initialization
	void Start () {
        
         playerRB = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Cardboard.SDK.Triggered)
        {
            isMoving = !isMoving;
        }

        if(isMoving)
        {
            forwarDir = GameObject.FindGameObjectWithTag("MainCamera").transform.forward;
            forwarDir.y = 0;
            forwarDir.Normalize();
            playerRB.velocity = forwarDir * speed ;
        }
        else
        {
            playerRB.velocity = new Vector3(0, 0, 0);
        }
	}
}
