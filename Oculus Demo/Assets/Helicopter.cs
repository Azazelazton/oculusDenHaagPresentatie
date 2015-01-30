using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {
    
    [SerializeField]
    float upForce = 0;
    [SerializeField]
    float acceleration = 5f;
    [SerializeField]
    float drag = 0.999f;
    [SerializeField]
    float rotateSpeed = 10f;

    [SerializeField]
    Transform rotor;
    [SerializeField]
    float rotorAcceleration = 15;

    void Update()
    {
        if (upForce < 0) upForce = 0;
        transform.rigidbody.velocity += upForce * transform.up*Time.deltaTime;
		rotor.Rotate(new Vector3(0,0,15 * Time.deltaTime * rotorAcceleration)); //rotor.Rotate(new Vector3(0,0,upForce * Time.deltaTime * rotorAcceleration));


        if (Input.GetKey(KeyCode.LeftShift))
			upForce = 14;//upForce += acceleration * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftControl))
			upForce = 6;//upForce -= acceleration * Time.deltaTime;
		else
			upForce = 9.8f;

        if (Input.GetKey(KeyCode.W))
            transform.Rotate(new Vector3(-rotateSpeed * Time.deltaTime,0,0));
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3( 0, 0,-rotateSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));

		Vector3 up = new Vector3(0, 1, 0);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(up * (-1* rotateSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(up * (rotateSpeed * Time.deltaTime));
    }

    void Reset()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
}
