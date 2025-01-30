using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    [System.Serializable]
    public class LeaderboardEntry
    {
        public string playerName; // Player's name
        public float lapTime;     // Player's lap time

        public LeaderboardEntry(string playerName, float lapTime)
        {
            this.playerName = playerName;
            this.lapTime = lapTime;
        }
    }

    [System.Serializable]
    public class LeaderboardData
    {
        public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
    }

    public Text leaderboardText; // Reference to the UI text to display the leaderboard
    private List<LeaderboardEntry> leaderboardEntries; // List to store leaderboard entries
    private int maxLeaderboardEntries = 5; // Max number of entries to display
    private string saveFilePath;

    void Start()
    {
        // Initialize the leaderboard
        saveFilePath = Application.persistentDataPath + "/leaderboard.json";
        leaderboardEntries = new List<LeaderboardEntry>();

        leaderboardText.gameObject.SetActive(false);

        // Load saved leaderboard data if available
        LoadLeaderboard();

        // Update the UI
        UpdateLeaderboardUI();
    }

    public void AddLapTime(string playerName, float lapTime)
    {
        // Add a new leaderboard entry
        leaderboardEntries.Add(new LeaderboardEntry(playerName, lapTime));

        // Sort the entries by lap time (ascending order, best time first)
        leaderboardEntries.Sort((a, b) => a.lapTime.CompareTo(b.lapTime));

        // If the leaderboard exceeds the max entries, remove the last entry
        if (leaderboardEntries.Count > maxLeaderboardEntries)
        {
            leaderboardEntries.RemoveAt(leaderboardEntries.Count - 1);
        }

        // Save the updated leaderboard
        SaveLeaderboard();

        // Update the leaderboard UI
        UpdateLeaderboardUI();

        leaderboardText.gameObject.SetActive(true);
    }

    void UpdateLeaderboardUI()
    {
        // Clear the leaderboard text and refresh it
        leaderboardText.text = "Leaderboard\n";

        // Display the top leaderboard entries
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            LeaderboardEntry entry = leaderboardEntries[i];
            leaderboardText.text += $"{i + 1}. {entry.playerName} - {entry.lapTime:F2} seconds\n";
        }
    }

    void SaveLeaderboard()
    {
        // Create a LeaderboardData object
        LeaderboardData data = new LeaderboardData();
        data.entries = leaderboardEntries;

        // Convert the object to JSON and save it to a file
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }

    void LoadLeaderboard()
    {
        // Check if the save file exists
        if (File.Exists(saveFilePath))
        {
            // Read the JSON file
            string json = File.ReadAllText(saveFilePath);

            // Convert the JSON back to a LeaderboardData object
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);

            // Populate the leaderboardEntries list
            leaderboardEntries = data.entries;
        }
    }
}