using UnityEngine;
using UnityEngine.UI;
public class RaceTimer : MonoBehaviour
{
    public Text timerText;
    private float timeElapsed = 0f;
    private bool raceActive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (raceActive)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = FormatTime(timeElapsed);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        raceActive = false;
    }
}
