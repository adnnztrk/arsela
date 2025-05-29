using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstertakip : MonoBehaviour
{
    GameObject karakter;
    
    bool dead = false;
    void Start()
    { //Find Character With Tag
        karakter = GameObject.FindGameObjectWithTag("karakter");
    }

    void Update()
    {
        //If not dead
        if (dead==false)
        {
            //Look the Character
            transform.LookAt(karakter.transform);
            //The monster moves towards the character
            GetComponent<Rigidbody>().AddForce(transform.forward * 50f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("mermi"))
        {
            GetComponent<Rigidbody>().useGravity = true;
            dead = true;
            Destroy(this.gameObject, 2f);
        }
    }
}
