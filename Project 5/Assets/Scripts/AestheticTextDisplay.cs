using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AestheticTextDisplay : MonoBehaviour
{
    public Text displayText; // Reference to the UI text element
    public string[] texts; // Array of texts to display
    public float textSpeed = 0.1f; // Speed at which text is displayed
    public float delayBeforeNextText = 1f; // Delay before displaying the next text
    private int currentTextIndex = 0; // Index of the current text
    private bool awaitingInput = true; // Flag to check for user input

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    void Update()
    {
        // Proceed to the next text only when awaiting input and 'N' key is pressed
        if (awaitingInput && Input.GetKeyDown(KeyCode.N))
        {
            NextText();
            awaitingInput = false;
        }
    }

    IEnumerator DisplayTextSequence()
    {
        // Loop through the texts array
        for (int i = 0; i < texts.Length; i++)
        {
            displayText.text = "";

            // Display each character of the text with a delay
            for (int j = 0; j < texts[i].Length; j++)
            {
                displayText.text += texts[i][j];
                yield return new WaitForSeconds(textSpeed);
            }

            // Wait for a delay before displaying the next text
            yield return new WaitForSeconds(delayBeforeNextText);
            awaitingInput = true;
        }

        // Reset the currentTextIndex to loop through the texts again
        currentTextIndex = 0;
        StartCoroutine(DisplayTextSequence());
    }

    void NextText()
    {
        currentTextIndex = (currentTextIndex + 1) % texts.Length;
        StartCoroutine(DisplayTextSequence());
    }
}