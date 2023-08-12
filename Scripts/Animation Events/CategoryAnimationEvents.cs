using UnityEngine;

public class CategoryAnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject mainAreaCanvas;
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;

    public void CloseCategory()
    {
        mainAreaCanvas.SetActive(true);
        extraItems.SetActive(false);
        buttonsAndOthers.SetActive(false);
    }
}
