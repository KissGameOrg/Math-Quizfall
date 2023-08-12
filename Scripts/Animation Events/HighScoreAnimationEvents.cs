using UnityEngine;

public class HighScoreAnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject mainAreaCanvas;
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;

    public void CloseHighScore()
    {
        mainAreaCanvas.SetActive(true);
        extraItems.SetActive(false);
        buttonsAndOthers.SetActive(false);
    }
}
