using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Animator camera;

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 5.5)
        {
            camera.SetTrigger("Right");
        }
        if (Player.transform.position.x < 5.5)
        {
            camera.SetTrigger("Left");
        }
    }
}
