using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().ToString() == "Start screen")
            {
                Debug.Log("Level load requested for: Level0");
                SceneManager.LoadScene("Level0");
            }
            if (SceneManager.GetActiveScene().ToString() == "Win")
            {
                Debug.Log("Level load requested for: Start screen");
                SceneManager.LoadScene("Start screen");
            }
        }
    }
}
