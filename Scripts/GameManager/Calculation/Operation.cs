using UnityEngine;

public class Operation : MonoBehaviour
{
    protected static string myOperator;

    public static int getElementOfExpression(int minElement, int maxElement)
    {
        return (int)UnityEngine.Random.Range(minElement, maxElement);
    }
}
