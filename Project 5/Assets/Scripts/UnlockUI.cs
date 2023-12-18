using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTimer());
    }


    public IEnumerator LifeTimer() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
