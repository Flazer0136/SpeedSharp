using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartUI()
    {
        // Load StartUI scene
        SceneManager.LoadScene("StartUI", LoadSceneMode.Single);

        // Optionally, preload track scenes in the background
        SceneManager.LoadSceneAsync("Track1", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Track2", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Track3", LoadSceneMode.Additive);
    }
}