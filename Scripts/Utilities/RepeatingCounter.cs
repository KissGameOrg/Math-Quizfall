using UnityEngine;

public class RepeatingCounter
{
    public float refreshTimer;
    public bool refreshTrigger;
    public float currentTimer = 0f;

    // Start is called before the first frame update
    public void initializeTimers()
    {
        currentTimer = refreshTimer;
        refreshTrigger = true;
    }

    public void countdownTimerProcess()
    {
        if (refreshTrigger)
        {
            if (currentTimer > 0.5f)
            {
                currentTimer -= Time.deltaTime;
            }
            else
            {
                currentTimer = 0;
                refreshTrigger = false;
            }
        }

        if (currentTimer == 0 && !refreshTrigger)
        {
            currentTimer = refreshTimer;
            refreshTrigger = true;
        }
    }
}
