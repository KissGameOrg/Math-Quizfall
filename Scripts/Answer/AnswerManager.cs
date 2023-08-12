using UnityEngine;
using System.Collections;

public class AnswerManager : MonoBehaviour
{
    public static bool isCorrectAnswerCarrying;
    //private int minValue = 4;
    //private int maxValue = 8;
    //private int actualValue;
    public static string correctAnswer = "";

    // Start is called before the first frame update
    void Start()
    {
        isCorrectAnswerCarrying = false;
        //actualValue = Random.Range(minValue, maxValue);
        //StartCoroutine("generateCorrectResponse");
    }

    /*
    IEnumerator generateCorrectResponse()
    {
        yield return new WaitForSeconds(actualValue);

        while (!isCorrectAnswerCarrying)
        {
            actualValue = Random.Range(minValue, maxValue);
            yield return new WaitForSeconds(actualValue);
        }
    }
    */
}
