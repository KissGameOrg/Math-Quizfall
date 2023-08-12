using TMPro;
using UnityEngine;

public class StartingGame : MonoBehaviour
{
    [SerializeField]private int timer;
    RepeatingCounter repeatingCounter;

    // Start is called before the first frame update
    void Start()
    {
        repeatingCounter = new RepeatingCounter();
        repeatingCounter.refreshTimer = timer;
        repeatingCounter.initializeTimers();
    }

    private void Update()
    {
        repeatingCounter.countdownTimerProcess();
        showStartTime(repeatingCounter.currentTimer);
    }

    void showStartTime(float timeToDisplay)
    {
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (seconds == 0)
        {
            gameObject.GetComponent<TMP_Text>().text = "GO!";
            return;
        }
        gameObject.GetComponent<TMP_Text>().text = "<" + seconds.ToString() + ">";
    }
}
