using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapCounter : MonoBehaviour
{
    public LeaderboardManager leaderboardManager;
    public int lapsCompleted = 0;
    public int totalLaps = 3;
    public Text lapText;
    private float raceTime = 0f;
    private string playerName = "Player";
    public GameObject finishPanel;
    public GameObject leaderboardText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lapsCompleted++;
            if (lapText != null)
            {
                lapText.text = "Laps finished: " + lapsCompleted + "/" + totalLaps;
            }
            if (lapsCompleted >= totalLaps)
            {
                Debug.Log("Race Finished");
                Object.FindFirstObjectByType<AchievementSystem>().RaceCompleted();
                Object.FindFirstObjectByType<RaceTimer>().StopTimer();
                // Finish the race and add the race time to the leaderboard
                leaderboardManager.AddLapTime(playerName,raceTime);
                raceTime = 0f;  // Reset the race time for the next race
                lapsCompleted = 0;  // Reset lap count
                if (finishPanel != null)
                {
                    finishPanel.SetActive(true);
                }
            }
        }
    }

    void Start()
    {
        // Ensure the finish panel is hidden at the start
        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
        }
    }

    public void RestartRace()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

    // Update is called once per frame
    void Update()
    {
        raceTime += Time.deltaTime;
    }

    public void ShowLeaderboard()
    {
        leaderboardText.gameObject.SetActive(true);  // Enable leaderboard text
    }
}
