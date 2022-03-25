using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoiSpawn : MonoBehaviour
{
    public GameObject objToSpawn;
    public float timeLeft, originalTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
            timeLeft = originalTime;
        }
    }
}