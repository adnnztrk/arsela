using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    float x, y, sayac = 10;
    public float hiz,ziplamagucu, Forwardstrength;
    public bool zipla=true, dodge=true;
    public Rigidbody rb;
    public GameObject mermi, mermispawn, respawn, menu;
    public AudioSource shoutgun;
    int health = 3;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        Cursor.visible = false;
        respawn.SetActive(false);
    }


    void Update()
    {
        //Dodge Power Recharging
        if (dodge==false)
        {
            sayac -= Time.deltaTime;
            if (sayac <= 0f)
            {
                dodge = true;
                sayac = 10;
            }
        }
        
        //Mouse invisible
        Cursor.visible = false;

        //Movement
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        y *= Time.deltaTime * hiz;
        x *= Time.deltaTime * hiz;
        transform.Translate(x, 0f, y);
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && zipla==true)
        {
            rb.AddForce(Vector3.up * ziplamagucu);
            zipla = false;
        }
        //Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            menu.SetActive(true);
        }
        //Dodge Power
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dodge == true)
            {
                Vector3 v3Force = Forwardstrength * transform.forward;
                rb.AddForce(v3Force);
                dodge = false;
            }
            
        }
        //Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoutgun.Play();
          GameObject spawnmermi = Instantiate(mermi, mermispawn.transform.position, mermispawn.transform.rotation) as GameObject;
          spawnmermi.GetComponent<Rigidbody>().velocity = mermispawn.transform.forward * 50f;
        }
        //health control
        if (health<=0)
        {
            Cursor.visible = true;
            respawn.SetActive(true);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        //Collision Controls
        if (collision.gameObject.tag.Equals("ground"))
        {
            zipla = true;
        }
        if (collision.gameObject.tag.Equals("lava"))
        {
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag.Equals("monster"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("heal"))
        {
            if (health<=3)
            {
                health += 1;
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            
            
        }
    }
    public void respawner()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
