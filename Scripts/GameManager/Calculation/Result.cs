using System.Data;
using UnityEngine;

public class Result: MonoBehaviour
{
    //Answer Part//

    public static bool checkIfAnswerCorrect(string ans, string exp)
    {
        DataTable dt = new DataTable();
        string tempAns = dt.Compute(exp, "").ToString();

        if (ans == tempAns)
            return true;
        return false;
    }

    public static string getAnswerFromExpression(string exp)
    {
        DataTable dt = new DataTable();
        return dt.Compute(exp, "").ToString();
    }

    //Answer Part End//
}
