using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private string expression;
    [SerializeField] private string destroyTags;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == destroyTags)
        {
            Destroy(gameObject);
        }
    }
}
