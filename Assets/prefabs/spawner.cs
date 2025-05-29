using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject ucan;
    public GameObject spw1, spw2, spw3, spw4;
    public float zamansayaci = 6;
    void Start()
    {
        
    }

    void Update()
    {
        //Monster Spawner
        zamansayaci -= Time.deltaTime;
        if (zamansayaci<=0)
        {
            Instantiate(ucan, spw1.transform.position, spw1.transform.rotation);
            Instantiate(ucan, spw4.transform.position, spw4.transform.rotation);
            Instantiate(ucan, spw2.transform.position, spw2.transform.rotation);
            Instantiate(ucan, spw3.transform.position, spw3.transform.rotation);
            float random = Random.Range(6, 9);
            zamansayaci = random;
        }
        
    }
}
