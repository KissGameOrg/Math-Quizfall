using UnityEngine;

public class DifficultyAnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject mainAreaCanvas;
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;

    public void CloseDifficulty()
    {
        mainAreaCanvas.SetActive(true);
        extraItems.SetActive(false);
        buttonsAndOthers.SetActive(false);
    }
}
