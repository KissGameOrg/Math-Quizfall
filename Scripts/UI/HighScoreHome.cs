using TMPro;
using UnityEngine;

public class HighScoreHome : MonoBehaviour
{
    [SerializeField] private TMP_Text addEasy;
    [SerializeField] private TMP_Text addMedium;
    [SerializeField] private TMP_Text addHard;
    
    [SerializeField] private TMP_Text minusEasy;
    [SerializeField] private TMP_Text minusMedium;
    [SerializeField] private TMP_Text minusHard;
    
    [SerializeField] private TMP_Text productEasy;
    [SerializeField] private TMP_Text productMedium;
    [SerializeField] private TMP_Text productHard;

    [SerializeField] private TMP_Text mixEasy;
    [SerializeField] private TMP_Text mixMedium;
    [SerializeField ]private TMP_Text mixHard;

    // Start is called before the first frame update
    void Start()
    {
        addEasy.SetText(Constants.EASY + "   " + CheckHighScore(Constants.ADD_TEXT, Constants.EASY));
        addMedium.SetText(Constants.MEDIUM + "   " + CheckHighScore(Constants.ADD_TEXT, Constants.MEDIUM));
        addHard.SetText(Constants.HARD + "   " + CheckHighScore(Constants.ADD_TEXT, Constants.HARD));

        minusEasy.SetText(Constants.EASY + "   " + CheckHighScore(Constants.MINUS_TEXT, Constants.EASY));
        minusMedium.SetText(Constants.MEDIUM + "   " + CheckHighScore(Constants.MINUS_TEXT, Constants.MEDIUM));
        minusHard.SetText(Constants.HARD + "   " + CheckHighScore(Constants.MINUS_TEXT, Constants.HARD));

        productEasy.SetText(Constants.EASY + "   " + CheckHighScore(Constants.PRODUCT_TEXT, Constants.EASY));
        productMedium.SetText(Constants.MEDIUM + "   " + CheckHighScore(Constants.PRODUCT_TEXT, Constants.MEDIUM));
        productHard.SetText(Constants.HARD + "   " + CheckHighScore(Constants.PRODUCT_TEXT, Constants.HARD));

        mixEasy.SetText(Constants.EASY + "   " + CheckHighScore(Constants.MIX_TEXT, Constants.EASY));
        mixMedium.SetText(Constants.MEDIUM + "   " + CheckHighScore(Constants.MIX_TEXT, Constants.MEDIUM));
        mixHard.SetText(Constants.HARD + "   " + CheckHighScore(Constants.MIX_TEXT, Constants.HARD));
    }

    string CheckHighScore(string categoryLevel, string difficultyLevel)
    {
        if (PlayerPrefs.GetString(Constants.HIGHSCORE + categoryLevel + difficultyLevel) == "")
        {
            PlayerPrefs.SetString(Constants.HIGHSCORE + categoryLevel + difficultyLevel, "0");
        }
        return PlayerPrefs.GetString(Constants.HIGHSCORE + categoryLevel + difficultyLevel);
    }
}
