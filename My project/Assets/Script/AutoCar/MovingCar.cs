using UnityEngine;

public class MovingCar : MonoBehaviour
{
    private Transform pointB;
    public float speed = 5f;

    public void SetDestination(Transform destination, float rotationZ)
    {
        pointB = destination;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ); // Rotate the car properly
    }

    void Update()
    {
        if (pointB != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
