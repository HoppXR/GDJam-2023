using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerObject : MonoBehaviour
{
    private bool cutscenePlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !cutscenePlayed)
        {
            // Player touched the object, trigger the cutscene.
            cutscenePlayed = true;
            // Add code to play the cutscene here.

            // Subscribe to an event or timer that signals when the cutscene is finished.
            // Example: cutscene.OnCutsceneFinished += EndGame;
        }
    }

    // This method is called when the cutscene is finished.
    private void EndGame()
    {
        // You can put game-ending logic here, such as transitioning to a game-over screen or quitting the application.
        // Example: SceneManager.LoadScene("GameOverScene");
    }
}
