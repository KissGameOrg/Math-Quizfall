using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f;
        ChangeSceneAndResetAllValues(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        ChangeSceneAndResetAllValues(0);
    }

    void ChangeSceneAndResetAllValues(int sceneId)
    {
        GameManager.isGameOver = false;
        GameManager.isGameStarted = false;
        GameManager.isGameOverActionDone = false;
        SceneManager.LoadScene(sceneId);
    }
}
