using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public float speed = 2;
    public Transform bg1;
    public Transform bg2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bg2.Translate(Vector3.down * speed * Time.deltaTime);
        bg1.Translate(Vector3.down * speed * Time.deltaTime);

        if (bg1.position.y < -8.52f)
        {
            bg1.position = new Vector3(bg2.position.x, bg2.position.y + 8.52f, bg2.transform.position.z);
        }
        if (bg2.position.y < -8.52f)
        {
            bg2.position = new Vector3(bg1.position.x, bg1.position.y + 8.52f, bg1.transform.position.z);
        }
    }
}
