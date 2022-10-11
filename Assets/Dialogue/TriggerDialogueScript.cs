using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDialogueScript : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    public AudioClip Landing;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("1");
        if (other.CompareTag("Player") && !triggered)
        {
            //Debug.Log("2");
            dialogueManager.TriggerStartDialogue();
            triggered = true;
            if (SceneManager.GetActiveScene().name == "Level0")
            {
                AudioSource.PlayClipAtPoint(Landing, transform.position);
            }
        }
    }
}
