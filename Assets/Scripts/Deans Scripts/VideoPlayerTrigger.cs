using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoPlayerTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player")) // Make sure the object touching is the player
        {
            // Play the video
            videoPlayer.Play();
            hasPlayed = true;

            EndGame();
        }
    }

    private void EndGame()
    {
      Application.Quit();
    }
}
