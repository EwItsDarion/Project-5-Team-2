using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public Weapon slingShot,maskGun,mine;
    public GameObject spawner,levelManager;
    public GameObject inventorySystem;
    public GameObject entry1, entry2, entry3;

    public bool trigger1Enter, trigger2Enter, trigger3Enter, trigger4Enter, trigger5Enter,triggerFinalEnter;

    public GameObject slingShotTutorialPanel, maskGunTutorialPanel, mineTutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        trigger1Enter = trigger2Enter = trigger3Enter = trigger4Enter = trigger5Enter = triggerFinalEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (trigger1Enter == true )
            {
                entry1.SetActive(false);
            }
            if (trigger2Enter == true)
            {
                entry2.SetActive(false);
            }
            if (trigger3Enter==true)
            {
                slingShot.gameObject.SetActive(true);
            slingShotTutorialPanel.gameObject.SetActive(true);

            if (GameObject.FindGameObjectWithTag("Sphere") == null)
            {
                entry3.gameObject.SetActive(false);
                slingShotTutorialPanel.gameObject.SetActive(false);
            }

                spawner.SetActive(true);
            levelManager.SetActive(true);
            }

            if(trigger4Enter==true)
            {

            slingShot.gameObject.SetActive(false);
            slingShotTutorialPanel.gameObject.SetActive(false);

            maskGun.gameObject.SetActive(true);
            maskGunTutorialPanel.gameObject.SetActive(true);
            }


        if (trigger5Enter == true)
        {
            maskGun.gameObject.SetActive(false);
            maskGunTutorialPanel.gameObject.SetActive(false);

            mine.gameObject.SetActive(true);
            mineTutorialPanel.gameObject.SetActive(true);
        }

        if (triggerFinalEnter)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }



