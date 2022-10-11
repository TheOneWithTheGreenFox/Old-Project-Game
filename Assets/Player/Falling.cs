using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float FallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, FallSpeed, 0);

        if(transform.position.y < -6f)
        {
            transform.position = new Vector3(0, 5.9f, -1);
        }

        if (transform.position.y > 6f)
        {
            transform.position = new Vector3(0, -5.9f, 0);
        }
    }
}
