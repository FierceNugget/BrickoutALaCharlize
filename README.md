# BrickoutALaCharlize
<!-- PROJECT LOGO -->
<p align="center">
  <h1 align="center">Brickout a la Charlize</h1>
  <h3 align="center">Introduction to Games Programming</h3>
  
  <p align="center">
    <h3">Charlize Rosenblad</h3>
    ·
    <h3">S2031891</h3>
    ·
    <h3">Computer Games (Design)</h3>
  </p>
</p>




_I confirm that the code contained in this file (other than that provided or authorised) is all my own work and has not been submitted elsewhere in fulfilment of this or any other award._ 

_-Charlize Rosenblad_


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
      <li><a href="#description-of-the-code">Description of the Code</a></i>
      <ul>
        <li><a href="#code-for-ball">Code for Ball</a></li>
        <li><a href="#code-for-bat">Code for Bat</a></li>
        <li><a href="#main-menu">Main Menu</a></li>
        <li><a href="#game-manager">Game Manager</a></li>
        <li><a href="#volume">Volume</a></li>
      </ul>
    </li>
    <li><a href="#challenging-code">Challenging Code</a></li>
  </ol>
</details>

## Description of the Code

### CODE FOR BALL

The script for the ball contains code in order to set the ball at a starting position and giving it rigid body 2D physics (that was manipulated with and given gravity = 0), initiate the velocity of the ball upon pressing the spacebar, deal with what happens when the ball hits a brick as well as the ground. It adds to the score when it hits a brick and plays an audio clip as it simultaneously destroys it. When it hits the ground a second audio clip plays, the Lives count decreases and the position of the ball resets. 

```sh
else if (collision.collider.CompareTag("ground"))
   {
 else if(gameManager.lives > 0) 
            {
               	 AudioClips[1].Play();
               	 gameObject.transform.position = startPosition.position;
               	 ballIsActive = false;
               	 rb2d.velocity = Vector2.zero;
                	gameManager.loseLife(); 
            }
     }
```

### CODE FOR BAT

For the movement of the bat I restricted it to the x-axis.

```sh
playerPosition.x += Input.GetAxisRaw("Horizontal") * playerVelocity;
```

I also made the walls of the game the boundaries for the movement of the bat on both the right and left side by writing:
  
```sh
if (playerPosition.x < boundaryLeft)
        {
            playerPosition.x = boundaryLeft;
```  
### MAIN MENU

This script deals with the PLAY and QUIT button in the main menu screen as the PLAY button changes the scene to the “Level 1” scene and the QUIT button exits the application all together.

```sh
public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 public void quitGame()
    {
        Application.Quit();
    }
```

### GAME MANAGER

Most of the mechanics of the game is put in here. It is used to link everything together. It contains the script to make the game over image appear when you lose and the champion image appear when you win. It also makes the main menu button take the player to the main menu and the restart button reset the scene.

```sh
public void restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
```

It also contains the function of the pause button, the settings for the score and lives and the start conditions of the game.

```sh
private void Start() 
    {
        lives = 3; 
        score = 0; 
        gameOverImage.SetActive(false); 
        winImage.SetActive(false); 
    }
```

### VOLUME

This script contains the different audio mixers for master volume, music and sound effect. This allows the player to change the volume for the different types of audio sounds.

```sh
public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
```

## Challenging Code

There were a few difficult parts that I had to figure out throughout programming this game but one part I spent extra time trying to figure out was how to make the pause button work properly. Activating the pause screen on the click of the pause button was easy, you simply had to add the pause image to the “On click” section, it was actually pausing the game and making the pause button disappear on click that was an issue. For this I added the public void “pauseGame” that makes pause determine the “time”. When time is frozen the game is paused and vice versa. This makes the ball stop in its position as soon as you hit the pause button. 

```sh
if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;  
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
```

As I already had assigned a resume button that disables the pause image and activates the game again I wanted to remove the pause button as this activated the ball without removing the pause screen. I did so by adding a game object called button and made it active when the game was not paused and not active when the game was paused by adding an extra line on each. 

```sh
if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            button.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            button.SetActive(false);
```

Finally, the last thing that I had to fix was that you could still move the bat during pause. I first tried to add a boolean expression for the movement that I would set as false during pause but instead I added the script of the bat to the pause button and disabled it on click and the opposite to the resume button.

