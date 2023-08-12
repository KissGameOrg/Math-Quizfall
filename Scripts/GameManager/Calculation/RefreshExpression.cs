using TMPro;
using UnityEngine;

public class RefreshExpression : MonoBehaviour
{
    [SerializeField] public TMP_Text expression;
    public static string currentExpression;

    public static bool manualAnswerRefreshTrigger;

    // Start is called before the first frame update
    void Start()
    {
        manualAnswerRefreshTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manualAnswerRefreshTrigger)
        {
            TriggerNewExpression();
            manualAnswerRefreshTrigger = false;
        }
    }


    public void TriggerNewExpression()
    {
        if (HomeMenu.selectedCategory == Constants.ADD_TEXT)
        {
            expression.text = Addition.callFinalExpression();
        } 
        else if (HomeMenu.selectedCategory == Constants.MINUS_TEXT)
        {
            expression.text = Subtraction.callFinalExpression();
        }
        else if (HomeMenu.selectedCategory == Constants.PRODUCT_TEXT)
        {
            expression.text = Product.callFinalExpression();
        }
        else if (HomeMenu.selectedCategory == Constants.MIX_TEXT)
        {
            expression.text = Mix.callFinalExpression();
        }

        currentExpression = expression.text;
    }
}
