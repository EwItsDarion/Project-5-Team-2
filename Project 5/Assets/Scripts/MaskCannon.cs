using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskCannon : MonoBehaviour
{
    public Projectile mask;
    public GameObject projectileSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(mask, projectileSpawnPosition.transform.position, projectileSpawnPosition.transform.rotation);

        }
    }
}
