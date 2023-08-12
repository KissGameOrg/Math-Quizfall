using System.Collections;
using UnityEngine;

public class AnswerObjectSpawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnRate;
    [SerializeField] private float initialDelayTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("initialDelay");
    }

    IEnumerator initialDelay()
    {
        yield return new WaitForSeconds(initialDelayTime);
        StartCoroutine("spawnRoutine");
    }

    IEnumerator spawnRoutine()
    {
        yield return new WaitForSeconds(spawnRate);

        while (!GameManager.isGameOver)
        {
            Instantiate(objectToSpawn, transform.position , objectToSpawn.transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
