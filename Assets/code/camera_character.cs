using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_character : MonoBehaviour
{
    public float hassasiyet = 5f, yumusaklik = 2f;
    Vector2 gecispos, farepos;
    public GameObject oyuncu;

    void Start()
    {
        oyuncu = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));

        gecispos.x = Mathf.Lerp(gecispos.x, md.x, 1f / yumusaklik);
        gecispos.y = Mathf.Lerp(gecispos.y, md.y, 1f / yumusaklik);
        farepos += gecispos;

        transform.localRotation = Quaternion.AngleAxis(-farepos.y, Vector3.right);

        oyuncu.transform.localRotation = Quaternion.AngleAxis(farepos.x, oyuncu.transform.up);
    }
}
