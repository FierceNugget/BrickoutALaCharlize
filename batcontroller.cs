using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Charlize Rosenblad
// Bat controller script [Brickout a la Charlize]
// 25/01/2021 21:45pm

public class batcontroller : MonoBehaviour { // The bat variables
    public float playerVelocity;
    private Vector3 playerPosition;
    public float boundaryLeft;
    public float boundaryRight;
    

    // Use this for initialization
    void Start () { // the bat at the start of the game
        playerPosition = gameObject.transform.position; // The starting position of the bat
	}
	
	// Update is called once per frame
	void Update () { // The possible movement for the bat
        playerPosition.x += Input.GetAxisRaw("Horizontal") * playerVelocity; // Can only move in the X-axis
        if (playerPosition.x < boundaryLeft) // If its on the boundry set in unity on the left side
        {
            playerPosition.x = boundaryLeft; // Doesn't let the bat move out of the boundary on the left
        }
        if (playerPosition.x > boundaryRight) // If its on the boundry set in unity on the right side
        {
            playerPosition.x = boundaryRight; // Doesn't let the bat move out of the boundary on the right
        }
        transform.position = playerPosition; // Where the position of the bat is transformed is where the bat is played
	}

}
