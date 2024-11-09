using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rigidBody;
    //
    public float height = 1.0f;

    public float waveHeight = 2.0f;

    public float waveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        var newPositionY = height + waveHeight * Mathf.Sin(Time.time * waveSpeed);
        rigidBody.MovePosition(new Vector3(transform.position.x, newPositionY, transform.position.z));
    }
}
