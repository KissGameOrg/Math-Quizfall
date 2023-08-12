using UnityEngine;

public class PauseAnimationEvent : MonoBehaviour
{
    public void Pause()
    {
        PauseMenu.isPaused = true;
        GameManager.onGoingTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }
}
