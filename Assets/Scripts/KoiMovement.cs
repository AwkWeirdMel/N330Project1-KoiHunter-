using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void onCollisionEnter(Collision coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
