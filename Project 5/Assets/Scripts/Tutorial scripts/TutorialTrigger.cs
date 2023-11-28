using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialTrigger : MonoBehaviour
{
    public Weapon maskCannon;
    public GameObject entry3;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered");
            if (gameObject.name == "TutorialTrigger1")
            {
                GameObject.Find("Entry1").SetActive(false);
            }
            if (gameObject.name == "TutorialTrigger2")
            {
                GameObject.Find("Entry2").SetActive(false);
            }
            if (gameObject.name == "TutorialTrigger3")
            {
                entry3.gameObject.SetActive(false);
                maskCannon.gameObject.SetActive(true);
                spawner.SetActive(true);
            }
            if (gameObject.name == "TutorialTrigger4")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}

