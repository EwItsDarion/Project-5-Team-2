using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialTrigger : MonoBehaviour
{ 
    public TutorialManager manager;
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
                manager.trigger1Enter = true;
            }
            if (gameObject.name == "TutorialTrigger2")
            {
                manager.trigger2Enter = true;
            }
            if (gameObject.name == "TutorialTrigger3")
            {
                manager.trigger3Enter = true;
            }
            if (gameObject.name == "TutorialTrigger4")
            {
                manager.trigger4Enter = true;
            }
            if (gameObject.name == "TutorialTrigger5")
            {
                manager.trigger5Enter = true;
            }

            if (gameObject.name == "TutorialTrigger6")
            {
                manager.trigger6Enter = true;
            }

            if (gameObject.name == "TutorialTriggerFinal")
            {
                manager.triggerFinalEnter = true;
            }
        }
    }
}

