using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialoguePanel;

    private Queue<string> dialogueQueue;

    private bool isDisplayingText;




    private void Start()
    {
        dialogueQueue = new Queue<string>();
        dialoguePanel.SetActive(false);
        isDisplayingText = false;
    }

    public void StartDialogue(List<string> dialogue)
    {
        dialoguePanel.SetActive(true);
        dialogueQueue.Clear();

        foreach (string sentence in dialogue)
        {
            dialogueQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isDisplayingText) return;

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = dialogueQueue.Dequeue();
        StartCoroutine(DisplayText(sentence));
    }

    IEnumerator DisplayText(string sentence)
    {
        isDisplayingText = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the speed of character display here
        }

        isDisplayingText = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
