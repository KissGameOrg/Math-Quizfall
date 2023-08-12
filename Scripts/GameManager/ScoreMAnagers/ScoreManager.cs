using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static bool updateScore;    
    public static float score;
    public static string highScore;
    
    [SerializeField] private TMP_Text scoreTxtGameOver;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text highScoreTxtGameOver;
    [SerializeField] private TMP_Text highScoreTxtPause;

    private void Start()
    {
        highScore = PlayerPrefs.GetString(Constants.HIGHSCORE + HomeMenu.selectedCategory + HomeMenu.selectedDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateScore)
        {
            UpdateScore();
        }

        //resetting highscore
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.SetString(Constants.HIGHSCORE + HomeMenu.selectedCategory + HomeMenu.selectedDifficulty, "0");
        }

        if (highScore != "")
        {
            highScoreTxtGameOver.text = highScore;
            highScoreTxtPause.text = highScore;
        }
        else
        {
            highScoreTxtGameOver.text = "0";
            highScoreTxtPause.text = "0";
        }
    }

    void UpdateScore()
    {
        score += 1;
        scoreTxtGameOver.text = score.ToString();
        scoreTxt.text = score.ToString();
        updateScore = false;
    }
}
