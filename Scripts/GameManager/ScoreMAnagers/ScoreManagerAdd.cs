using UnityEngine;

public class ScoreManagerAdd : ScoreManager
{
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        if (HomeMenu.selectedDifficulty == Constants.EASY) {
            if (PlayerPrefs.GetString(Constants.HIGHSCORE_ADD_EASY) == "")
            {
                PlayerPrefs.SetString(Constants.HIGHSCORE_ADD_EASY, "0");
            }
        }
        else if (HomeMenu.selectedDifficulty == Constants.MEDIUM)
        {
            if (PlayerPrefs.GetString(Constants.HIGHSCORE_ADD_MEDIUM) == "")
            {
                PlayerPrefs.SetString(Constants.HIGHSCORE_ADD_MEDIUM, "0");
            }
        }
        else if (HomeMenu.selectedDifficulty == Constants.HARD)
        {
            if (PlayerPrefs.GetString(Constants.HIGHSCORE_ADD_HARD) == "")
            {
                PlayerPrefs.SetString(Constants.HIGHSCORE_ADD_HARD, "0");
            }
        }
        
        //highScore = PlayerPrefs.GetString(Constants.HIGHSCORE);
        //highScoreTxt.text = highScore;
        //updateScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
