using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    public int racesCompleted = 0; // Current races completed
    public int racesToWinBadge = 5; // Races needed for achievement
    public Text achievementText; // Text to display achievement messages
    public GameObject achievementPanel; // Panel for achievements
    public float notificationDuration = 3f; // Time for the popup to stay visible

    private const string RacesCompletedKey = "RacesCompleted"; // Key for PlayerPrefs

    private void Start()
    {
        // Load the progress when the game starts
        racesCompleted = PlayerPrefs.GetInt(RacesCompletedKey, 0);
        achievementPanel.SetActive(false); // Hide the achievement panel at the start

        // Check if the achievement was already unlocked
        if (racesCompleted >= racesToWinBadge)
        {
            UnlockAchievement();
        }
    }

    public void RaceCompleted()
    {
        racesCompleted++;
        PlayerPrefs.SetInt(RacesCompletedKey, racesCompleted); // Save progress
        PlayerPrefs.Save();

        CheckAchievements();
    }

    private void CheckAchievements()
    {
        if (racesCompleted >= racesToWinBadge)
        {
            UnlockAchievement();
        }
    }

    private void UnlockAchievement()
    {
        achievementPanel.SetActive(true);
        achievementText.text = "Achievement Unlocked: Winner Badge";
        Debug.Log("Achievement Unlocked: Winner Badge");

        // Start the coroutine to hide the notification after some time
        StartCoroutine(HideAchievementPanelAfterDelay());
    }

    private System.Collections.IEnumerator HideAchievementPanelAfterDelay()
    {
        yield return new WaitForSeconds(notificationDuration);
        achievementPanel.SetActive(false); // Hide the panel
    }

    public void ResetProgress()
    {
        // Reset progress and save it
        racesCompleted = 0;
        PlayerPrefs.SetInt(RacesCompletedKey, racesCompleted);
        PlayerPrefs.Save();

        achievementPanel.SetActive(false); // Hide the panel after reset
        Debug.Log("Achievement progress reset.");
    }
}
