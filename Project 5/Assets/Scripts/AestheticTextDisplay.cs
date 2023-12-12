using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class AestheticTextDisplay : MonoBehaviour
{
    public Text displayText; // Reference to the UI text element
    public string[] texts; // Array of texts to display
    public float textSpeed = 0.1f; // Speed at which text is displayed
    public float delayBetweenTexts = 1f; // Delay between texts
    private int currentTextIndex = 0; // Index of the current text
    private bool displayComplete = false; // Flag to check if text display is complete

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    void Update()
    {
        // Proceed to the next text on spacebar press or if text display is complete
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && displayComplete)
        {
            NextText();
        }
    }

    IEnumerator DisplayTextSequence()
    {
        // Loop through the texts array
        foreach (string text in texts)
        {
            displayComplete = false;
            displayText.text = "";

            // Display each character of the text with a delay
            foreach (char letter in text)
            {
                displayText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }

            displayComplete = true;

            // Wait for a delay before displaying the next text
            yield return new WaitForSeconds(delayBetweenTexts);
        }

        // If all texts are displayed, set the displayComplete flag to true
        displayComplete = true;
    }

    void NextText()
    {
        // Check if there are more texts to display
        if (currentTextIndex < texts.Length - 1)
        {
            currentTextIndex++;
            StartCoroutine(DisplayTextSequence());
        }
        else
        {
            // If no more texts, reset the currentTextIndex to loop through the texts again
            currentTextIndex = 0;
            StartCoroutine(DisplayTextSequence());
        }
    }
}
