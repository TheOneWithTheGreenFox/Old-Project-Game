using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Dialogue TMP Text")]
    [SerializeField] private TextMeshProUGUI DialogueText;

    [Header("Next Btn")]
    [SerializeField] private GameObject NextBtn;

    [Header("Animation Controller")]
    [SerializeField] private Animator DialogueAnimator;

    [Header("Dialogue")]
    [TextArea]
    [SerializeField] private string[] Dialogue;

    private PlayerMovement MoveScript;

    private int TextIndex;
    private float AnimationDelay = 0.6f;

    private void Start()
    {
        MoveScript = FindObjectOfType<PlayerMovement>();
    }

    public void TriggerStartDialogue()
    {
        StartCoroutine(StartDialogue());
    }

    private void Update()
    {
        if (NextBtn.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerDialogue();
            }
        }
    }

    private IEnumerator StartDialogue()
    {
        MoveScript.ToggleInteraction();

        DialogueAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(AnimationDelay);
        StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        foreach (char letter in Dialogue[TextIndex].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        NextBtn.SetActive(true);
    }

    private IEnumerator ContinueDialogue()
    {
        DialogueText.text = string.Empty;
        DialogueAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(AnimationDelay);
        DialogueAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(AnimationDelay);

        TextIndex++;
        StartCoroutine(TypeDialogue());
    }

    public void TriggerDialogue()
    {
        NextBtn.SetActive(false);
        if (TextIndex >= Dialogue.Length - 1)
        {
            DialogueText.text = string.Empty;
            DialogueAnimator.SetTrigger("Close");
            MoveScript.ToggleInteraction();
        }
        else
        {
            StartCoroutine(ContinueDialogue());
        }
    }
}
