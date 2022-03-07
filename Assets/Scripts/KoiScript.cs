using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
