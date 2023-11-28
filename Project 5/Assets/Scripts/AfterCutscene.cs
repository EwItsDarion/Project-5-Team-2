using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCutscene : MonoBehaviour
{
    public GameObject objectToEnable;

    void Start()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }
        StartCoroutine(ReEnableAfterDelay(3f));
    }

    IEnumerator ReEnableAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

 
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
    }
}
