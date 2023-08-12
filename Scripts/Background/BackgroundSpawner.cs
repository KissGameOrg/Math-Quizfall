using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnBackground();
    }

    void spawnBackground()
    {
        int tempId = Random.Range(0, backgrounds.Length);
        Transform background = backgrounds[tempId].transform;

        Instantiate(backgrounds[tempId], new Vector3(
            background.position.x,
            background.position.y,
            background.position.z
            ), transform.rotation);
    }
}
