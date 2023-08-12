using UnityEngine;

public class PauseMenu : GameUI
{
    [SerializeField] private Animator pausePanel;
    public static bool isPaused = false;

    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;
    private void Awake()
    {
        if (HomeMenu.isSoundOn)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
    }

    void ChangeSound(bool isSoundOnTobeChangedNow, bool isSoundOffTobeChangedNow, bool currentSoundIsOn)
    {
        soundOn.SetActive(isSoundOnTobeChangedNow);
        soundOff.SetActive(isSoundOffTobeChangedNow);

        HomeMenu.isSoundOn = currentSoundIsOn;
        AudioListener.pause = !currentSoundIsOn;

        if (HomeMenu.isSoundOn)
            PlayerPrefs.SetString(Constants.ISSOUNDON, "yes");
        else
            PlayerPrefs.SetString(Constants.ISSOUNDON, "no");
    }

    public void SoundOn()
    {
        ChangeSound(false, true, true);
    }

    public void SoundOff()
    {
        ChangeSound(true, false, false);
    }

    public void PausePanelIn()
    {
        pausePanel.SetBool("pause", true);
    }

    public void Resume()
    {
        PauseMenu.isPaused = false;
        pausePanel.SetBool("pause", false);
        Time.timeScale = GameManager.onGoingTimeScale;
    }
}
