using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public  bool canShoot, unlocked;
    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Coroutine that allows the player to shoot after some time (timeForReload)
    protected IEnumerator AllowPlayerToShoot(float timeForReload)
    {
        //change while to till game over maybe?
        while (!manager.gameOver)
        {
            yield return new WaitForSeconds(timeForReload);
            if (canShoot == false)
            {
                canShoot = true;
            }
        }
    }

    //Checks to see if the weapon is unlocked
    public bool IsUnlocked() { return unlocked; }

}
