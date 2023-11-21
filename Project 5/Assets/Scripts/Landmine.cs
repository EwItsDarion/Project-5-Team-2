using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public GameObject shockwavePrefab;
    public LayerMask affectedLayers;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Infected"))
        {
            CreateShockwave();
        }
    }

    private void CreateShockwave()
    {
        GameObject shockwaveInstance = Instantiate(shockwavePrefab, transform.position, Quaternion.identity);

        Shockwave shockwaveScript = shockwaveInstance.GetComponent<Shockwave>();

        if (shockwaveScript != null )
        {
            shockwaveScript.setAffectedLayers(affectedLayers);
        }
        else
        {
            print("Prefab not found");
        }
    }
}
