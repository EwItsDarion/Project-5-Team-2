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

    public bool trigger1Enter, trigger2Enter, trigger3Enter, trigger4Enter, trigger5Enter, trigger6Enter,triggerFinalEnter;

    public GameObject slingShotTutorialPanel, maskGunTutorialPanel, mineTutorialPanel,inventoryTutorialPanel,healthBarTutorial,progressBarTutorial;
    public GameObject healthBar, progressBar, reticle;

    // Start is called before the first frame update
    void Start()
    {
        trigger1Enter = trigger2Enter = trigger3Enter = trigger4Enter = trigger5Enter = trigger6Enter=triggerFinalEnter = false;
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

            reticle.SetActive(true);
            healthBar.SetActive(true);
            healthBarTutorial.SetActive(true);

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
            


            progressBar.SetActive(true);
            healthBarTutorial.SetActive(false);
            progressBarTutorial.SetActive(true);

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


        if (trigger6Enter == true)
        {

            mine.gameObject.SetActive(false);
            mineTutorialPanel.gameObject.SetActive(false);

            inventoryTutorialPanel.SetActive(true);
            inventorySystem.SetActive(true);
          
        }

        if (triggerFinalEnter)
            {
            LoadNextScene();
            }
        }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

}






