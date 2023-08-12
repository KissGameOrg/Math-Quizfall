using UnityEngine;

public class DestroyOnSomeTime : MonoBehaviour
{
    [SerializeField]
    private float destroyTimer;

    private void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
