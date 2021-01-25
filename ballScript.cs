using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Charlize Rosenblad
// Ball script [Brickout a la Charlize]
// 25/01/2021 21:45pm

public class ballScript : MonoBehaviour { // The variables
    private bool ballIsActive = false;
    private Vector3 ballPosition;
    public Vector2 ballInitialForce;
    public Rigidbody2D rb2d;
    public Transform startPosition;
    public gameManager gameManager;
    public AudioSource[] AudioClips = null;

    // Use this for initialization
    void Start () { // Puts the ball in a specific starting position and gives it 2D physics that can be manipulated
        transform.position = startPosition.position; // Where the ball starts 
        rb2d = GetComponent<Rigidbody2D>(); // Gives it 2D physics 
 

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) // Initiates the movement of the ball when you press space (the jump key)
        {
            if (!ballIsActive) // What happens if the ball is in motion
            {
                rb2d.AddForce(ballInitialForce); // Adds a initial force in a certain angle set in unity
                ballIsActive = true; // The ball is now in motion 
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) // Code for when the ball collides with either a brick or the ground
    {
        if (collision.collider.CompareTag("block")) // What happens when the ball collides with the bricks
        {

            if(gameManager.score == 250) // If the score reaches 250 and you hit the last brick it initiates the win image
            {
                gameManager.winGame(); // Game manager initiates win game
                rb2d.velocity = Vector2.zero; // The velocity of the ball becomes zero

            }
            else if(gameManager.score < 250) // If the score is less than 250 and you hit a brick
            {
                AudioClips[0].Play(); // Plays a specific audio clip when the ball hits a brick if the score is 250 or less
                Destroy(collision.collider.gameObject); // The brick that the ball collides with gets destroyed
                gameManager.increaseScore(); //The number next to "Score:" increases by 10
            }
            
        }
        else if (collision.collider.CompareTag("ground")) // What happens if the ball hits the ground
        {
            if(gameManager.lives == 0) // If the player has 0 lives and the ball hits the ground it initiates the game over image
            {
                gameManager.endGame(); // Game manager initiates end game
                rb2d.velocity = Vector2.zero; // The velocity of the ball becomes zero
            }
            else if(gameManager.lives > 0) // if the player has more than 0 lives and the ball hits the ground the ball goes back to the start position
            {
                AudioClips[1].Play(); // Plays a specific audio clip when the ball hits the ground if the lives are more than 0
                gameObject.transform.position = startPosition.position; // The ball returns to the starting position
                ballIsActive = false; // The ball is stationary and doesn't interact with any other forces
                rb2d.velocity = Vector2.zero; // The velocity of the ball becomes zero
                gameManager.loseLife(); // The number next to "Lives:" decreases by one
            }
        }
    }
}
