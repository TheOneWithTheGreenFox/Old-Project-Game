using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", 0.5f);
    }

    // Update is called once per frame
    private void Death()
    {
        Destroy(gameObject);
    }
}
