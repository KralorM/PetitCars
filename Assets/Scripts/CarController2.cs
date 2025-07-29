using UnityEngine;

public class CarController2 : MonoBehaviour
{


    public Rigidbody theRB;

    public float forwardAccel = 8f;
    public float reverseAccel = 4f;

    public float maxSpeed = 50f;

    public float turnStrength = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = theRB.transform.position;
    }

    void FixedUpdate()
    {
        theRB.AddForce(transform.forward * forwardAccel);
    }
}
