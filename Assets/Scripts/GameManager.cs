using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restarting Game via SceneLoader...");

        // Find the SceneLoader component in the scene
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader != null)
        {
            sceneLoader.LoadStartUI(); // Call the LoadStartUI method
        }
        else
        {
            Debug.LogError("SceneLoader not found in the scene!");
        }
    }
}
