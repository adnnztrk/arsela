using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie_script : MonoBehaviour
{
    GameObject karakter;
    public int hiz;
    private NavMeshAgent nv;
    private Animator anim;
    bool dead = false;
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        karakter = GameObject.FindGameObjectWithTag("karakter");
        nv = this.gameObject.GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //Animatordeki a deðeri bekleme b deðeri ise koþma
        float dest = Vector3.Distance(karakter.transform.position, this.gameObject.transform.position);
        if (dead == false)
        {
            
            nv.SetDestination(karakter.transform.position);
            if (dest<=2)
            {
               
                anim.SetFloat("a", 1);
                anim.SetFloat("b", 0);
            }
            else if (dest>2)
            {
                anim.SetFloat("a", 0);
                anim.SetFloat("b", 1);
            }
        }
    }
}
