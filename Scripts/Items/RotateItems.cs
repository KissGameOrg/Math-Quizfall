using UnityEngine;

public class RotateItems : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        float[] actualRotationSpeed = { rotationSpeed, -rotationSpeed };
        System.Random rnd = new System.Random();
        int id = rnd.Next(actualRotationSpeed.Length);
        rotationSpeed = actualRotationSpeed[id];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
