using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static bool isShaking = false;
    //public float duration = 1f;

    //public AnimationCurve curve;

    //way 2
    static float shakeAmount;
    static float shakeTimer;

    private Vector3 cameraStartLocation;

    private void Start()
    {
        cameraStartLocation = transform.position;
    }
    // Start is called before the first frame update
    void Update()
    {
        //if (startShake)
        //{
        //    startShake = false;
        //    StartCoroutine(ShakeCamera());
        //}

        if (shakeTimer > 0 && isShaking)
        {

            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            gameObject.transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y,
                gameObject.transform.position.z);

            shakeTimer -= Time.deltaTime;

            if (shakeTimer < 0.05f)
            {
                isShaking = false;
                transform.position = cameraStartLocation;
            }
        }

    }

    public static void Shake(float amt, float time)
    {
        shakeAmount = amt;
        shakeTimer = time;
        isShaking = true;
    }

    //IEnumerator ShakeCamera()
    //{
    //    Vector3 startPosition = transform.position;
    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        float strength = curve.Evaluate(elapsedTime/duration);
    //        transform.position = startPosition + Random.insideUnitSphere * strength;
    //        yield return null;
    //    }

    //    transform.position = startPosition;
    //}
}
