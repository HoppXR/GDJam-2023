using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string EndCutscene;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            Debug.Log("Collision detected with Hole");
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(EndCutscene);
    }
}
