using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class AnswerObject : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]private TMP_Text answerObject;
    string answer;
    [SerializeField] private string[] destroyTags;
    [SerializeField] private GameObject explosionParticle;
    [SerializeField] private GameObject floatingPoints;
    [SerializeField] private float answerFallingPositionY;

    [SerializeField] private GameObject burstPowerUp;
    [SerializeField] private GameObject slowPowerUp;


    //[SerializeField] private float explosionParticleOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        DestroyWhenPowerUpNearby(burstPowerUp, 1.4f);
        DestroyWhenPowerUpNearby(slowPowerUp, 1.4f);

        if (AnswerManager.isCorrectAnswerCarrying)
        {

            //Generating random answer incorrect ans close to correct ones
            int temp1 = int.Parse (AnswerManager.correctAnswer) + 1;
            int temp2 = int.Parse(AnswerManager.correctAnswer) - 1;
            int temp3 = int.Parse(AnswerManager.correctAnswer) + 3;
            int temp4 = int.Parse(AnswerManager.correctAnswer) - 3;
            int temp5 = int.Parse(AnswerManager.correctAnswer) - 2;
            int temp6 = int.Parse(AnswerManager.correctAnswer) + 4;
            int temp7 = int.Parse(AnswerManager.correctAnswer) - 5;
            int temp8 = int.Parse(AnswerManager.correctAnswer) - 4;

            string[] incorrectAnswerTemp = { temp1.ToString(), temp2.ToString(), 
                temp3.ToString(), temp4.ToString(), temp5.ToString(), temp6.ToString(),
                temp7.ToString(), temp8.ToString() };

            System.Random random = new System.Random();
            int id = random.Next(0, incorrectAnswerTemp.Length);
            answer = incorrectAnswerTemp[id];
        }
        else
        {
            answer = Result.getAnswerFromExpression(RefreshExpression.currentExpression);
            AnswerManager.correctAnswer = answer;
            AnswerManager.isCorrectAnswerCarrying = true;
        }
        answerObject.text = answer;
    }

    void DestroyWhenPowerUpNearby(GameObject powerUpObject, float distance )
    {
        //facing left
        if (transform.position.x < powerUpObject.transform.position.x)
        {
            if (Vector3.Distance(transform.position, powerUpObject.transform.position) < distance)
            {
                //Do something because the distance is less than 1.4
                Destroy(gameObject);
            }
        }
        else
        {
            //facing right
            if (Vector3.Distance(powerUpObject.transform.position, transform.position) < distance)
            {
                //Do something because the distance is less than 1.4
                Destroy(gameObject);
            }
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (Result.checkIfAnswerCorrect(answer, RefreshExpression.currentExpression))
        {
            ScoreManager.updateScore = true;
            Instantiate(floatingPoints,
            new Vector2(transform.position.x, transform.position.y), floatingPoints.transform.rotation);

            AudioManager.correctAnsSoundOn = true;
        }
        else
        {
            CameraShake.Shake(0.14f, 0.16f);
            DestroyAllExistingObjects();
            UpdateHighScore();
            GameManager.isGameOver = true;            
        }

        AnswerManager.isCorrectAnswerCarrying = false;
        RefreshExpression.manualAnswerRefreshTrigger = true;

        Instantiate(explosionParticle,
            new Vector2(transform.position.x, transform.position.y), explosionParticle.transform.rotation);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        foreach (string tag in destroyTags)
        {
            if (col.tag == tag)
            { 
                if (answer == Result.getAnswerFromExpression(RefreshExpression.currentExpression))
                {
                    RefreshExpression.manualAnswerRefreshTrigger = true;
                    AnswerManager.isCorrectAnswerCarrying = false;
                    CameraShake.Shake(0.14f, 0.16f);

                    DestroyAllExistingObjects();
                    UpdateHighScore();

                    Instantiate(explosionParticle,
                        new Vector2(transform.position.x, answerFallingPositionY), explosionParticle.transform.rotation);

                    GameManager.isGameOver = true;
                }

                //Instantiate(explosionParticle,
                //    new Vector2(transform.position.x, transform.position.y + explosionParticleOffsetY), transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void DestroyAllExistingObjects()
    {
        GameObject[] answerObjects = GameObject.FindGameObjectsWithTag(Constants.AnswerObjectTag);
        foreach(GameObject answerObject in answerObjects)
        {
            if (answerObject != gameObject)
            {
                Instantiate(explosionParticle,
                        answerObject.transform.position, transform.rotation);
                Destroy(answerObject);
            }
        }
    }

    void UpdateHighScore()
    {
        string exhighScore = PlayerPrefs.GetString(Constants.HIGHSCORE + HomeMenu.selectedCategory + HomeMenu.selectedDifficulty);
        if (ScoreManager.score > 
            int.Parse(exhighScore))
        {
            ScoreManager.highScore = ScoreManager.score.ToString();
            PlayerPrefs.SetString(Constants.HIGHSCORE + HomeMenu.selectedCategory + HomeMenu.selectedDifficulty,
                ScoreManager.score.ToString());
            ScoreManager.score = 0f;
        }
    }
}
