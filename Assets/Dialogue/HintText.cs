using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintText : MonoBehaviour
{
    [Header("Animation Controller")]
    [SerializeField] private Animator DialogueAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenHint();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseHint();
    }

    private void OpenHint()
    {
        DialogueAnimator.SetTrigger("Open");
    }

    private void CloseHint()
    {
        DialogueAnimator.SetTrigger("Close");
    }
}
