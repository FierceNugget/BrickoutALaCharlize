using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Charlize Rosenblad
// Game manager script [Brickout a la Charlize]
// 25/01/2021 21:45pm

public class gameManager : MonoBehaviour
{ // The variables
    public int score; //
    public int lives;
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverImage;
    public GameObject winImage;
    bool isPaused = false;
    public GameObject button;
   



    private void Start() // What the player starts with
    {
        lives = 3; // 3 lives
        score = 0; // 0 score
        gameOverImage.SetActive(false); // The game over image is not visable
        winImage.SetActive(false); // The win image is not visable
    }


    public void loseLife() // If the ball hits the ground the game manager initiates the loseLife sequence
    {
        lives -= 1; // The lives are decreased by one
        livesText.text = ("Lives: " + lives); // Decrease in lives is shown after the text "Lives: "
    }

    public void increaseScore() // Whenever the ball hits a brick the game manager initiates the increaseScore sequence
    {
        score += 10; // The score is increased by 10
        scoreText.text = ("Score: " + score); // Increase in score is shown after the text "Score: "
    }

    public void restart() // Code for the restart button in order to restart the level and load the starting screen
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Gets the scene to start again
    }

    public void endGame() // Making the game over image visable after your lives reach 0
    {
        gameOverImage.SetActive(true); // Activates game over image
    }

    public void winGame() // Making the winning screen visable as your score reaches 260
    {
        winImage.SetActive(true); // Activates win image
    }

    public void mainMenu() // The main menu button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Loads the scene before which is the main menu scene
    }

    public void pauseGame() // Pressing the pause button will activate this
    {
        if (isPaused)
        {
            Time.timeScale = 1; // If the game is running, indicating that time is moving
            isPaused = false; // The game is not paused
            button.SetActive(true); // The pause button is visable
            
            
        }
        else
        {
            Time.timeScale = 0; // If time is stopped
            isPaused = true; // The game is paused
            button.SetActive(false); // Makes the pause button disappear

        }
    }
}

    