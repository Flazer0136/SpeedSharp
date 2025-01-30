using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanelScript : MonoBehaviour
{
    public GameObject startPanel;
    public Button playButton;
    public Dropdown trackDropdown;

    public TrackManager trackManager;

    private int selectedTrackIndex = 1;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        trackDropdown.onValueChanged.AddListener(OnTrackDropdownChange);
    }

    void OnTrackDropdownChange(int index)
    {
        selectedTrackIndex = index + 1;
        trackManager.EnableTrack(selectedTrackIndex);
    }

    private void OnPlayButtonClick()
    {
        Debug.Log($"Starting selected track: {selectedTrackIndex}");
        // Unload the UI safely and load the selected track
        startPanel.SetActive(false);

        switch (selectedTrackIndex)
        {
            case 1:
                SceneManager.LoadScene("Track1");
                break;
            case 2:
                SceneManager.LoadScene("Track2");
                break;
            case 3:
                SceneManager.LoadScene("Track3");
                break;
        }
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
