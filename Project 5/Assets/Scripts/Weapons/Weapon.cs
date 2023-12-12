using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public  bool canShoot, unlocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected IEnumerator AllowPlayerToShoot()
    {
        //change while to till game over maybe?
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (canShoot == false)
            {
                canShoot = true;
            }
        }
    }
    protected void OnEnable()
    {
        StartCoroutine(AllowPlayerToShoot());
    }

    public bool IsUnlocked() { return unlocked; }

}
