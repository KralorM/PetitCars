using UnityEngine;

public class ArcadeCarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float acceleration = 800f;
    public float maxSpeed = 20f;
    public float steering = 100f;
    public float drag = 0.98f;

    [Header("Visuals")]
    public Transform carBody;

    private float moveInput;
    private float steerInput;
    private Vector3 velocity;

    [Header("Wheels")]
    public Transform frontLeftWheel;
    public Transform frontRightWheel;
    public Transform rearLeftWheel;
    public Transform rearRightWheel;


    void Update()
    {
        // Pobranie wejścia
        moveInput = Input.GetAxis("Vertical");   // W/S
        steerInput = Input.GetAxis("Horizontal"); // A/D
    }

    void FixedUpdate()
    {
        // Dodanie prędkości do przodu
        velocity += transform.forward * moveInput * acceleration * Time.fixedDeltaTime;

        // Ograniczenie prędkości
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Obracanie auta
        float steerAmount = steerInput * steering * Time.fixedDeltaTime;
        transform.Rotate(0f, steerAmount, 0f);

        // Poruszanie pojazdem
        transform.position += velocity * Time.fixedDeltaTime;

        // Powolne wyhamowywanie
        velocity *= drag;

        // Opcjonalne pochylanie wizualnej bryły auta przy skręcie
        if (carBody)
        {
            float tilt = -steerInput * 10f;
            carBody.localRotation = Quaternion.Euler(0, 0, tilt);
        }


        // Oblicz prędkość toczenia (w zależności od kierunku ruchu)
        float wheelRotationSpeed = velocity.magnitude * Mathf.Sign(moveInput) * 360f * Time.fixedDeltaTime;

        // Obracanie kół wokół osi X (obrót toczenia)
        frontLeftWheel.Rotate(Vector3.right, wheelRotationSpeed);
        frontRightWheel.Rotate(Vector3.right, wheelRotationSpeed);
        rearLeftWheel.Rotate(Vector3.right, wheelRotationSpeed);
        rearRightWheel.Rotate(Vector3.right, wheelRotationSpeed);

        // Skręt wizualny przednich kół (obrót wokół osi Y)
        float steerVisualAngle = steerInput * 30f;
        frontLeftWheel.localRotation = Quaternion.Euler(frontLeftWheel.localRotation.eulerAngles.x, steerVisualAngle, 0);
        frontRightWheel.localRotation = Quaternion.Euler(frontRightWheel.localRotation.eulerAngles.x, steerVisualAngle, 0);




    }
}
