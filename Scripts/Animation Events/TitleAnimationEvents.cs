using UnityEngine;

public class TitleAnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject extraItems;
    [SerializeField] private GameObject buttonsAndOthers;

    public void EnableAfterNameAnimation()
    {
        extraItems.SetActive(true);
        buttonsAndOthers.SetActive(true);
    }
}
