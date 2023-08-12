using UnityEngine;

public class ExitGameAnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject mainAreaCanvas;
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;

    public void CloseExitGameDialog()
    {
        mainAreaCanvas.SetActive(true);
        extraItems.SetActive(false);
        buttonsAndOthers.SetActive(false);
    }
}
