using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraTeleport : MonoBehaviour
{
    public Transform[] teleportPoints; // Array to store the teleport points
    public float delayBetweenTeleports = 2f; // Delay between teleports
    public Text displayText; // Reference to the UI text element
    private int currentPointIndex = 0; // Index of the current teleport point
    private Coroutine teleportCoroutine; // Coroutine reference for teleportation

    void Start()
    {
        StartCoroutine(TeleportSequence());
    }

    void Update()
    {
        // Clear text on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearText();
        }
    }

    IEnumerator TeleportSequence()
    {
        foreach (Transform point in teleportPoints)
        {
            yield return new WaitForSeconds(delayBetweenTeleports);

            // Display text before teleporting
            DisplayText("Teleporting to Point " + (currentPointIndex + 1));

            // Teleport camera to the next point
            transform.position = point.position;
            transform.rotation = point.rotation;

            currentPointIndex++;
        }

        // Clear text after teleportation sequence ends
        ClearText();
    }

    void DisplayText(string message)
    {
        if (displayText != null)
        {
            displayText.text = message;
        }
    }

    void ClearText()
    {
        if (displayText != null)
        {
            displayText.text = "";
        }
    }
}
