using System.Collections.Generic;

public class Mix : Operation
{
    /// <summary>
    /// Calculation of expression is done on this class, 
    /// but activeExpressions and activeAnswers are updated whenever bubble is generated and destroyed
    /// </summary>

    private static List<string> easyOperator = new List<string> { Constants.PLUS, Constants.MINUS };
    private static List<string> mediumHardOperator = new List<string> { Constants.PLUS, Constants.MINUS, Constants.PRODUCT };

    public static string callFinalExpression()
    {
        return getFinalExpression();
    }

    /*
     * there are 3 scenes for different levels - easy, medium, hard
     * Easy: will call expression of 2 elements and no negative values as ans and only +,-
     * Medium: will call expression of 2 elements including negative answers (+,-,*)
     * Hard: will call expression of 3 elements only operator is +,-, incase of * expression wil have 2 elements
     */
    public static string getFinalExpression()
    {
        if (HomeMenu.selectedDifficulty == Constants.EASY)
        {
            int firstElement = 0;
            string tempMyOperator = getOperator(easyOperator);

            int secondElement = 0;

            if (tempMyOperator == Constants.MINUS)
            {
                firstElement = getElementOfExpression(10, 20);
                secondElement = getElementOfExpression(2, firstElement);
            }
            else
            {
                firstElement = getElementOfExpression(2, 20);
                secondElement = getElementOfExpression(2, 20);
            }

            return firstElement + " " + tempMyOperator + " " + secondElement;
        }
        else if (HomeMenu.selectedDifficulty == Constants.MEDIUM)
        {
            string tempMyOperator = getOperator(mediumHardOperator);
            int firstElement = getElementOfExpression(2, 40);
            int secondElement = getElementOfExpression(2, 40);

            if (tempMyOperator == Constants.PRODUCT)
            {
                firstElement = getElementOfExpression(2, 20);
                secondElement = getElementOfExpression(2, 10);
            }

            return firstElement + " " + tempMyOperator + " " + secondElement;
        }
        else if (HomeMenu.selectedDifficulty == Constants.HARD)
        {
            string tempMyOperator1 = getOperator(mediumHardOperator);

            if (tempMyOperator1 != Constants.PRODUCT)
            {
                string tempMyOperator2 = getOperator(easyOperator);

                int firstElement = getElementOfExpression(2, 20);
                int secondElement = getElementOfExpression(2, 20);
                int thirdElement = getElementOfExpression(2, 20);

                return firstElement + " " + tempMyOperator1 + " " + secondElement + " " + tempMyOperator2 + " " + thirdElement;
            }
            else
            {
                int firstElement = getElementOfExpression(2, 20);
                int secondElement = getElementOfExpression(2, 20);

                return firstElement + " " + tempMyOperator1 + " " + secondElement;
            }
        }
        else
        {
            return "Something went wrong";
        }
    }

    public static string getOperator(List<string> operatorType)
    {
        System.Random rnd = new System.Random();

        int operatorId;
        string randomOperator = "";
        operatorId = rnd.Next(operatorType.Count);
        randomOperator = mediumHardOperator[operatorId];

        return randomOperator;
    }
}
