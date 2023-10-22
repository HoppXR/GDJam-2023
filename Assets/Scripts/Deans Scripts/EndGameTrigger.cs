using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the object touching is the player
        {
            // Play the cutscene
            cutsceneDirector.Play();

            EndGame();
        }
    }

    private void EndGame()
    {
       Application.Quit();
    }
}
