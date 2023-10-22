using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string EndCutscene;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Hole"))
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
