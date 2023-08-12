using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //it should be 3.4f
    [SerializeField] private float gameStartTime;
    
    private float inGameDuration = 0f;

    [SerializeField] private GameObject startGameText;
    [SerializeField] private RefreshExpression refreshExpression;
    [SerializeField] private AnswerManager answerManager;
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Animator gameOverAnimation;

    private float fixedGlobalDeltaTime;
    public static float onGoingTimeScale;

    [SerializeField] private TMP_Text expressionText;

    //all the game related public static values
    public static bool isGameStarted;
    public static bool isSlowPowerUpRunning;
    public static bool isGameOver = false;
    public static bool isGameOverActionDone = false;

    [SerializeField] private GameObject easySpawnObject;
    [SerializeField] private GameObject mediumSpawnObject;
    [SerializeField] private GameObject hardSpawnObject;

    void Awake()
    {
        //Manually set category and difficulty whithout home meny load
        //HomeMenu.selectedCategory = Constants.ADD_TEXT;
        //HomeMenu.selectedDifficulty = Constants.HARD;
        print("selected Categroy > " + HomeMenu.selectedCategory + " selected difficulty > " + HomeMenu.selectedDifficulty);

        if (HomeMenu.selectedDifficulty == Constants.EASY)
        {
            easySpawnObject.SetActive(true);
        }
        else if (HomeMenu.selectedDifficulty == Constants.MEDIUM)
        {
            mediumSpawnObject.SetActive(true);
        }
        else if (HomeMenu.selectedDifficulty == Constants.HARD)
        {
            hardSpawnObject.SetActive(true);
        }

        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        fixedGlobalDeltaTime = Time.fixedDeltaTime;
        onGoingTimeScale = Time.timeScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        disableAndEnableForGameStart(false);
        StartCoroutine(startGame());
        Instantiate(startGameText, startGameText.transform.position, startGameText.transform.rotation);
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(gameStartTime);
        isGameStarted = true;
        disableAndEnableForGameStart(true);
    }

    void disableAndEnableForGameStart(bool value)
    {
        refreshExpression.enabled = value;
        refreshExpression.expression.enabled = value;

        if (value)
        {
            refreshExpression.TriggerNewExpression();
        }
        answerManager.enabled = value;
        pauseButton.SetActive(value);
        uiCanvas.SetActive(value);
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (isGameStarted && !isGameOver)
            {
                inGameDuration += Time.deltaTime;
            }

            if (inGameDuration > 67f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 2.6f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
            else if (inGameDuration > 57f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 2.3f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
            else if (inGameDuration > 47f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 1.9f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
            else if (inGameDuration > 37f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 1.6f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
            else if (inGameDuration > 27f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 1.6f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
            else if (inGameDuration > 17f && !isSlowPowerUpRunning)
            {
                Time.timeScale = 1.3f;
                Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;
            }
        }

        //for testing timescale
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Time.deltatime > " + Time.fixedDeltaTime + " Time.timeScale > "+ Time.timeScale 
                + " ingame time > " + (int)inGameDuration);
        }


        if (isGameOver && !isGameOverActionDone)
        {
            AudioManager.gameOverSound = true;
            
            inGameDuration = 0f;

            Time.timeScale = 1f;
            Time.fixedDeltaTime = fixedGlobalDeltaTime * Time.timeScale;

            gameOverAnimation.SetTrigger("gameOver");
            expressionText.enabled = false;
            pauseButton.SetActive(false);
            //isGameOver = false;
            isGameStarted = false;
            isGameOverActionDone = true;
        }

        //hide pauseMenu when slow power up is running to avoid timescale issue
        if (isGameStarted)
        {
            if (isSlowPowerUpRunning)
            {
                if (pauseButton.activeSelf)
                {
                    pauseButton.SetActive(false);
                }
            }
            else
            {
                if (!pauseButton.activeSelf)
                {
                    pauseButton.SetActive(true);
                }
            }
        }
    }
}
