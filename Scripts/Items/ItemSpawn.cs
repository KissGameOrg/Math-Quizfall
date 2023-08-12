using System.Collections;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform minSpawnLocationX;
    [SerializeField] private Transform maxSpawnLocationX;
    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnItems");
    }

    IEnumerator spawnItems()
    {
        yield return new WaitForSeconds(spawnInterval);

        while (!GameManager.isGameOver)
        {
            float spawnLocationX = Random.Range(minSpawnLocationX.position.x, maxSpawnLocationX.position.x);
            Instantiate(objectToSpawn, 
                new Vector2(spawnLocationX, transform.position.y), objectToSpawn.transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
