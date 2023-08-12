using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //[SerializeField] private AudioClip onClickAnswerObjectSound;
    [SerializeField] private AudioSource answerAudioSource;
    public static bool correctAnsSoundOn = false;

    [SerializeField] private AudioSource gameOverAudioSource;
    public static bool gameOverSound = false;

    [SerializeField] private AudioSource bgMusic;

    [SerializeField] private AudioSource burstPowerUpAudioSource;
    public static bool burstPowerUpSoundOn= false;

    [SerializeField] private AudioSource slowPowerUpAudioSource;
    public static bool slowPowerUpSoundOn = false;

    private static bool isBGMusicPaused = false;

    private void Awake()
    {
        if (HomeMenu.isSoundOn)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }

    private void Start()
    {
        bgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (correctAnsSoundOn)
        {
            //answerAudioSource.PlayOneShot(onClickAnswerObjectSound);
            answerAudioSource.Play();
            correctAnsSoundOn = false;
        }

        if (gameOverSound)
        {
            //answerAudioSource.PlayOneShot(onClickAnswerObjectSound);
            bgMusic.Stop();
            gameOverAudioSource.Play();
            gameOverSound = false;
        }

        if (burstPowerUpSoundOn)
        {
            //answerAudioSource.PlayOneShot(onClickAnswerObjectSound);
            burstPowerUpAudioSource.Play();
            burstPowerUpSoundOn = false;
        }

        if (slowPowerUpSoundOn)
        {
            //answerAudioSource.PlayOneShot(onClickAnswerObjectSound);
            slowPowerUpAudioSource.Play();
            slowPowerUpSoundOn = false;
        }

        if (PauseMenu.isPaused)
        {
            if (!isBGMusicPaused)
            {
                bgMusic.Pause();
                isBGMusicPaused = true;
            }
        }
        else
        {
            if (isBGMusicPaused)
            {
                bgMusic.Play();
                isBGMusicPaused = false;
            }
        }
    }
}
