using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackManager : MonoBehaviour
{
    private string currentLoadedTrackScene = "";

    public void EnableTrack(int trackNumber)
    {
        UnloadAllTracks();

        switch (trackNumber)
        {
            case 1:
                LoadTrackScene("Track1");
                Debug.Log("Loading Track1...");
                break;
            case 2:
                LoadTrackScene("Track2");
                Debug.Log("Loading Track2...");
                break;
            case 3:
                LoadTrackScene("Track3");
                Debug.Log("Loading Track3...");
                break;
            default:
                Debug.LogError("Invalid track selection.");
                break;
        }
    }

    private void LoadTrackScene(string sceneName)
    {
        if (currentLoadedTrackScene == sceneName) return;
        currentLoadedTrackScene = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    private void UnloadAllTracks()
    {
        foreach (var scene in SceneManager.GetAllScenes())
        {
            if (scene.isLoaded && scene.name.StartsWith("Track"))
            {
                if (scene.name != currentLoadedTrackScene)
                {
                    SceneManager.UnloadSceneAsync(scene);
                    Debug.Log($"Unloading scene: {scene.name}");
                }
            }
        }
    }
}