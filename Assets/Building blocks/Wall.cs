using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1,1));
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
