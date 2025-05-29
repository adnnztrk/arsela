using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnercontrol : MonoBehaviour
{
    int spawnhealth = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnhealth<=0)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("mermi"))
        {
            spawnhealth -= 1;
        }
    }
}
