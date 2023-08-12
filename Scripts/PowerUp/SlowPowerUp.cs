using UnityEngine;
using UnityEngine.EventSystems;
public class SlowPowerUp : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject slowExplosionParticle;
    [SerializeField] private GameObject answerObject;
    //[SerializeField] private float explosionParticleOffsetY;
    private SlowPowerUpTimer slowPowerUpTimer;


    void Start()
    {
        DestroyWhenPowerUpNearby(answerObject, 1.4f);
        slowPowerUpTimer = GameObject.FindGameObjectWithTag(Constants.GameManagerTag).GetComponent<SlowPowerUpTimer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.slowPowerUpSoundOn = true;

        GameManager.isSlowPowerUpRunning = true;
        GameManager.onGoingTimeScale = Time.timeScale;
        slowPowerUpTimer.Being(6);
        Time.timeScale = 0.5f;
        Instantiate(slowExplosionParticle,
                new Vector2(transform.position.x, transform.position.y),
                slowExplosionParticle.transform.rotation);

        CameraShake.Shake(0.14f, 0.16f);
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
