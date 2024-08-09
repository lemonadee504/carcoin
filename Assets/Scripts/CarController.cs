using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 100f; // Maximum speed of the car
    public float acceleration = 10f; // Acceleration of the car
    public float steering = 2f; // Steering sensitivity
    public float brakingForce = 50f; // Braking force

    private float currentSpeed = 0f; // Current speed of the car
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleSteering();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = 0f;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        rb.velocity = transform.forward * currentSpeed;
    }

    void HandleSteering()
    {
        float steer = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            steer = -steering * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            steer = steering * Time.deltaTime;
        }

        transform.Rotate(0, steer, 0);
    }
}
