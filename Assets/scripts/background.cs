using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed = 2;
    public Transform otherBg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -8.52f)
        {
            transform.position = new Vector3(otherBg.position.x, otherBg.position.y + 8.52f, otherBg.transform.position.z);
        }
    }
}
