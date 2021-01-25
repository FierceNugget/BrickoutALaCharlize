using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Charlize Rosenblad
// Volume script [Brickout a la Charlize]
// 25/01/2021 21:45pm

public class volume : MonoBehaviour {

    public AudioMixer audioMixer; // The audio variable 

	public void setVolume (float volume) // Setting the master volume with numbers with decimals
    {
        audioMixer.SetFloat("volume", volume); // Changing the master volume and giving it a name
    }
    public void setMusicVolume (float music) // Setting the music volume with numbers with decimals
    {
        audioMixer.SetFloat("music", music); // Changing the music volume and giving it a name
    }
    public void setSoundEffects (float soundEffects) // Setting the sound effects volume with numbers with decimals
    {
        audioMixer.SetFloat("soundEffects", soundEffects); // Changing the sound effects volume and giving it a name
    }
}
