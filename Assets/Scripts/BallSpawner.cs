using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class BallSpawner : MonoBehaviour
{
    public Transform ballPrefab;


    public GameObject aimPoint;
    private Camera mainCam;

    public float delay = 0.5f;
    private float zRotation;
    public float timeBetweenBalls = 0.5f;
    Rigidbody2D rb;

    Vector2 shootLine;
    public float shootPower = 1;
    Vector3 mousePos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        shootLine = aimPoint.transform.position - transform.position;
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 rotation = mousePos - transform.position;

        zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (zRotation >= -40)
        {
            zRotation = -40;
        }
        if (zRotation <= -140)
        {
            zRotation = -140;
        }
        transform.rotation = Quaternion.Euler(0, 0, zRotation - 90);
        Debug.Log(zRotation);

        if (delay <= 0 && Mouse.current.leftButton.isPressed)
        {
            delay = timeBetweenBalls;
            SpawnBall();

            

            
        }

        delay -= Time.deltaTime;

 
    }

    void SpawnBall()
    {

        Transform ball = Instantiate(ballPrefab, transform.position, transform.rotation);

        ball.GetComponent<Rigidbody2D>().AddForce(shootLine * shootPower, ForceMode2D.Impulse);
    }


}
