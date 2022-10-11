using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public GameObject PlayerLifePrefab;
    List<GameObject> lifeObjects = new List<GameObject>();
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(6, 6));
    }

    // Use this for initialization
    void Start()
    {
        RefillLives();
    }
        // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Health == 9)
        {
            Destroy(lifeObjects[lifeObjects.Count - 1]);
        }
        else if (PlayerMovement.Health == 8)
        {
            Destroy(lifeObjects[lifeObjects.Count - 2]);
        }
        else if (PlayerMovement.Health == 7)
        {
            Destroy(lifeObjects[lifeObjects.Count - 3]);
        }
        else if (PlayerMovement.Health == 6)
        {
            Destroy(lifeObjects[lifeObjects.Count - 4]);
        }
        else if (PlayerMovement.Health == 5)
        {
            Destroy(lifeObjects[lifeObjects.Count - 5]);
        }
        else if (PlayerMovement.Health == 4)
        {
            Destroy(lifeObjects[lifeObjects.Count - 6]);
        }
        else if (PlayerMovement.Health == 3)
        {
            Destroy(lifeObjects[lifeObjects.Count - 7]);
        }
        else if (PlayerMovement.Health == 2)
        {
            Destroy(lifeObjects[lifeObjects.Count - 8]);
        }
        else if (PlayerMovement.Health == 1)
        {
            Destroy(lifeObjects[lifeObjects.Count - 9]);
        }
        else if (PlayerMovement.Health == 0)
        {
            Destroy(lifeObjects[lifeObjects.Count - 10]);
            RefillLives();
        }
    }

    public void RefillLives()
    {
        foreach (Transform child in transform)
        {
            GameObject PlayerLife = Instantiate(PlayerLifePrefab, child.transform.position, Quaternion.identity);
            lifeObjects.Add(PlayerLife);
        }
    }
}