using UnityEngine;
using UnityEngine.EventSystems;
public class BurstPowerUp : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject burstExplosionParticle;
    [SerializeField] private GameObject answerExplosionParticle;
    [SerializeField] private GameObject answerObject;

    //[SerializeField] private float explosionParticleOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        DestroyWhenPowerUpNearby(answerObject, 1.4f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.burstPowerUpSoundOn = true;
            GameObject[] answerObjects = GameObject.FindGameObjectsWithTag(Constants.AnswerObjectTag);
            foreach (GameObject answerObject in answerObjects)
            {
                RefreshExpression.manualAnswerRefreshTrigger = true;
                AnswerManager.isCorrectAnswerCarrying = false;

                Instantiate(answerExplosionParticle,
                    new Vector2(answerObject.transform.position.x, answerObject.transform.position.y),
                    answerExplosionParticle.transform.rotation);

                Destroy(answerObject);
            }
        Instantiate(burstExplosionParticle,
                new Vector2(transform.position.x, transform.position.y),
                burstExplosionParticle.transform.rotation);

        CameraShake.Shake(0.20f, 0.16f);
        
        Destroy(gameObject);
    }

    void DestroyWhenPowerUpNearby(GameObject powerUpObject, float distance)
    {
        //facing left
        if (transform.position.x < powerUpObject.transform.position.x)
        {
            if (Vector3.Distance(transform.position, powerUpObject.transform.position) < distance)
            {
                //Do something because the distance is less than 1.4
                //print("falling");
                Destroy(gameObject);
            }
        }
        else
        {
            //facing right
            if (Vector3.Distance(powerUpObject.transform.position, transform.position) < distance)
            {
                //Do something because the distance is less than 1.4
                //print("falling 2");
                Destroy(gameObject);
            }
        }
    }
}
