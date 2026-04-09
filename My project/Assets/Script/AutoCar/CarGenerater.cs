using UnityEngine;

public class CarGenerater : MonoBehaviour
{
    public GameObject[] carPrefabs;  // Array of car prefabs

    // Left-to-right spawn points and destinations
    public Transform[] spawnPointsLeft;  // (A & B)
    public Transform[] destinationsLeft; // (Destination A & Destination B)

    // Right-to-left spawn points and destinations
    public Transform[] spawnPointsRight;  // (C & D)
    public Transform[] destinationsRight; // (Destination C & Destination D)

    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, spawnInterval);
    }

    void SpawnCar()
    {
        GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
        bool spawnFromLeft = Random.value > 0.5f; // Randomly choose left-to-right or right-to-left

        if (spawnFromLeft)
        {
            int index = Random.Range(0, spawnPointsLeft.Length);
            Transform spawnPoint = spawnPointsLeft[index];
            Transform destination = destinationsLeft[index];

            GameObject car = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);
            car.GetComponent<MovingCar>().SetDestination(destination, -90); 
        }
        else
        {
            int index = Random.Range(0, spawnPointsRight.Length);
            Transform spawnPoint = spawnPointsRight[index];
            Transform destination = destinationsRight[index];

            GameObject car = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);
            car.GetComponent<MovingCar>().SetDestination(destination, 90);  
        }
    }

    public void StopCarGeneration()
    {
        //Debug.Log("CancelInvoke called.");

        if (IsInvoking("SpawnCar"))
        {
            CancelInvoke("SpawnCar");
            //Debug.Log("Car generation stopped.");
        }
        else
        {
            //Debug.Log("No active Invoke to cancel.");
        }
    }
}
