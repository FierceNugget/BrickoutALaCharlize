using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Charlize Rosenblad
// Main menu script [Brickout a la Charlize]
// 25/01/2021 21:45pm

public class mainMenu : MonoBehaviour {

	public void playGame() // What happens if you press the PLAY button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // The next scene loads (the game scene)
    }

    public void quitGame() // What happens if you press the QUIT button
    {
        Application.Quit(); // The Brickout game closes
    }
}
