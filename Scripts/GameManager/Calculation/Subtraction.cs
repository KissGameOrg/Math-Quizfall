public class Subtraction : Operation
{
    /// <summary>
    /// Calculation of expression is done on this class, 
    /// but activeExpressions and activeAnswers are updated whenever bubble is generated and destroyed
    /// </summary>
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
        myOperator = Constants.MINUS;

        if (HomeMenu.selectedDifficulty == Constants.EASY)
        {
            int firstElement = getElementOfExpression(10, 20);

            int secondElement = getElementOfExpression(2, firstElement);

            return firstElement + " " + myOperator + " " + secondElement;
        }
        else if (HomeMenu.selectedDifficulty == Constants.MEDIUM)
        {
            int firstElement = getElementOfExpression(2, 40);
            int secondElement = getElementOfExpression(2, 40);

            return firstElement + " " + myOperator + " " + secondElement;
        }
        else if (HomeMenu.selectedDifficulty == Constants.HARD)
        {
            int firstElement = getElementOfExpression(2, 20);
            int secondElement = getElementOfExpression(2, 20);
            int thirdElement = getElementOfExpression(2, 20);

            return firstElement + " " + myOperator + " " + secondElement + " " + myOperator + " " + thirdElement;
        }
        else
        {
            return "Something went wrong";
        }
    }
}
