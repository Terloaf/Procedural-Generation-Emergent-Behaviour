using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public Transform ballPrefab;
    public float delay = 0.5f;
    public float timeBetweenBalls = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0 && Mouse.current.leftButton.isPressed)
        {
            delay = timeBetweenBalls;
            SpawnBall();
        }

        delay -= Time.deltaTime;

 
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}
