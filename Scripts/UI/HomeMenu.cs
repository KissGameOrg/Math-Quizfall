using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainAreaCanvas;
    [SerializeField]private GameObject loadingCanvas;
    [SerializeField] private GameObject difficultyCanvas;
    [SerializeField] private Image loadingFill;
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;
    [SerializeField] private GameObject categoryCanvas;
    [SerializeField] private GameObject highScoreCanvas;
    [SerializeField] private GameObject exitGameCanvas;
    [SerializeField] private Animator categoryAnimator;
    [SerializeField] private Animator difficultyAnimator;

    public static string selectedCategory;
    public static string selectedDifficulty;


    //sounds
    public static bool isSoundOn;
    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;


    private void Start()
    {
        selectedCategory = "";
        selectedDifficulty = "";

        if (PlayerPrefs.GetString(Constants.ISSOUNDON) == "yes" || PlayerPrefs.GetString(Constants.ISSOUNDON) == "")
        {
            SoundOn();
        }
        else
        {
            SoundOff();
        }
    }

    public void SelectHighScore()
    {
        mainAreaCanvas.SetActive(false);
        highScoreCanvas.SetActive(true);
        highScoreCanvas.GetComponent<Animator>().SetTrigger("fadeIn");
    }

    public void StartGameWithDifficulty(string difficultyLevel)
    {
        difficultyCanvas.SetActive(false);
        switch (difficultyLevel)
        {
            case "easy":
                selectedDifficulty = Constants.EASY;
                SelectDifficultyCommonActions();
                break;

            case "medium":
                selectedDifficulty = Constants.MEDIUM;
                SelectDifficultyCommonActions();
                break;

            case "hard":
                selectedDifficulty = Constants.HARD;
                SelectDifficultyCommonActions();
                break;
        }
    }

    IEnumerator LoadPlaySceneAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        
        loadingCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadingFill.fillAmount = progressValue;
            yield return null;
        }
    }

    public void OpenDifficultyDialog()
    {
        categoryCanvas.SetActive(false);
        difficultyCanvas.SetActive(true);
        difficultyAnimator.SetTrigger("fadeIn");
    }

    private void SelectDifficultyCommonActions()
    {
        difficultyCanvas.SetActive(false);
        StartCoroutine(LoadPlaySceneAsync("PlayScene"));
    }

    public void ChooseCategory(string category)
    {
        selectedCategory = category;
        CloseCategory();
        OpenDifficultyDialog();
    }

    public void OpenCategoryDialog()
    {
        mainAreaCanvas.SetActive(false);
        categoryCanvas.SetActive(true);
        categoryAnimator.SetTrigger("fadeIn");
    }

    public void CloseCategory()
    {
        mainAreaCanvas.SetActive(false);
        categoryAnimator.SetTrigger("fadeOut");
    }

    public void CloseDifficulty()
    {
        mainAreaCanvas.SetActive(false);
        difficultyAnimator.SetTrigger("fadeOut");
    }

    void ChangeSound(bool isSoundOnTobeChangedNow, bool isSoundOffTobeChangedNow, bool currentSoundIsOn)
    {
        soundOn.SetActive(isSoundOnTobeChangedNow);
        soundOff.SetActive(isSoundOffTobeChangedNow);

        isSoundOn = currentSoundIsOn;
        AudioListener.pause = !currentSoundIsOn;

        if (isSoundOn)
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

    public void CloseHighScore()
    {
        mainAreaCanvas.SetActive(false);
        highScoreCanvas.GetComponent<Animator>().SetTrigger("fadeOut");
    }

    public void OpenExitGameDialog()
    {
        mainAreaCanvas.SetActive(false);
        exitGameCanvas.SetActive(true);
        exitGameCanvas.GetComponent<Animator>().SetTrigger("fadeIn");
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Application quitted");
    }

    public void CloseExitGameDialog()
    {
        mainAreaCanvas.SetActive(false);
        exitGameCanvas.GetComponent<Animator>().SetTrigger("fadeOut");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OpenExitGameDialog();
    }
}
