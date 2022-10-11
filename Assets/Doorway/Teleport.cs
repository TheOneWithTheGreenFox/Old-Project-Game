using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Summit");
        }
        if (SceneManager.GetActiveScene().name == "Summit")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
