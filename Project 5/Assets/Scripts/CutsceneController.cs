using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutsceneController : MonoBehaviour
{
    public Image[] images; // Array to store your 6 images
    public Text dialogueText;
    public Text personTalking;

    public string[] sentences; // Array to store your dialogue sentences
    private int sentenceIndex = 0;
    private bool isDisplayingText = false;
    private int numCount = 0;
    private bool isOver = false;

    void Start()
    {
        // Hide all images at the start of the scene
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // Show the first image
        images[0].gameObject.SetActive(true);

        // Start displaying dialogue
        StartCoroutine(ShowText());
    }

    void Update()
    {

        if(isOver)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (numCount == 0 || numCount == 1)
        {
            personTalking.text = "Dr. Bright";
        }

        if (numCount > 1 && numCount < 7)
        {
            personTalking.text = "News Anchor";
        }

        if(numCount == 7)
        {
            personTalking.text = "Phone Ringing!";
        }

        if (numCount == 8)
        {
            personTalking.text = "Dr. Bright";
        }

        if (numCount == 9)
        {
            personTalking.text = "Sergeant Richards";
        }

        if (numCount > 9 && numCount < 12)
        {
            personTalking.text = "Dr. Bright";
        }

        if (numCount == 12)
        {
            personTalking.text = "Sergeant Richards";
        }

        if (numCount == 13)
        {
            personTalking.text = "Dr. Bright";
        }

        if (numCount == 14)
        {
            personTalking.text = "Sergeant Richards";
        }

        if(numCount > 14 && numCount < 19)
        {
            personTalking.text = "Dr. Bright";
        }

        if(numCount == 19)
        {
            personTalking.text = "Sergeant Richards";
        }

        if (numCount > 19 && numCount < 22)
        {
            personTalking.text = "Dr. Bright";
        }

        if (numCount == 22)
        {
            personTalking.text = "Sergeant Richards";
        }

        if (numCount == 5)
        {
            foreach (Image image in images)
            {
                image.gameObject.SetActive(false);
            }

            images[1].gameObject.SetActive(true);
        }

        if (numCount == 7)
        {
            foreach (Image image in images)
            {
                image.gameObject.SetActive(false);
            }

            images[2].gameObject.SetActive(true);
        }

        if (numCount == 13)
        {
            foreach (Image image in images)
            {
                image.gameObject.SetActive(false);
            }

            images[3].gameObject.SetActive(true);
        }

        if (numCount == 17)
        {
            foreach (Image image in images)
            {
                image.gameObject.SetActive(false);
            }

            images[4].gameObject.SetActive(true);
        }

        if (numCount == 23)
        {
            isOver = true;
        }
    }


    IEnumerator ShowText()
    {
        isDisplayingText = true;
        foreach (char letter in sentences[sentenceIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the speed of character display here
        }
        isDisplayingText = false;
    }

    public void MoveToNextSentence()
    {
        if (!isDisplayingText)
        {
            numCount++;
            NextSentence();
        }
    }

    public void NextSentence()
    {
        if (sentenceIndex < sentences.Length - 1)
        {
            sentenceIndex++;
            dialogueText.text = "";
            StartCoroutine(ShowText());
        }
        else
        {
            // Handle end of dialogue or scene transition here
        }
    }



    public void ChangeImage(int index)
    {
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
        images[index].gameObject.SetActive(true);
    }
}
