using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowPowerUpTimer : MonoBehaviour
{
    [SerializeField] private GameObject progressiveBar;
    [SerializeField] private Image fill;

    [SerializeField] public int duration;
    private static float remainingDuration;

    // Start is called before the first frame update
    void Start()
    {
        progressiveBar.SetActive(false);
        //Being(duration);
    }

    public void Being(int second)
    {
        progressiveBar.SetActive(true);
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            fill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration -= Time.deltaTime;
            yield return null;
        }

        OnEnd();
    }

    private void OnEnd()
    {
        AudioManager.slowPowerUpSoundOn = true;
        progressiveBar.SetActive (false);
        GameManager.isSlowPowerUpRunning = false;
        Time.timeScale = GameManager.onGoingTimeScale;
    }
}
