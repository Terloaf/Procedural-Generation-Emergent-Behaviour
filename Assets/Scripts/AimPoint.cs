using UnityEngine;
using UnityEngine.InputSystem;

public class AimPoint : MonoBehaviour
{
    private Camera mainCam;
    public float zRotation;
    Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 rotation = mousePos - transform.position;

        zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if(zRotation >= -40)
        {
            zRotation = -40;
        }
        if (zRotation <= -140)
        {
            zRotation = -140;
        }
        transform.rotation = Quaternion.Euler(0, 0, zRotation - 90);
        Debug.Log(zRotation);

    }
}
