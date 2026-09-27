using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType
{
    SuperGun,
    Bomb
}

public class award : MonoBehaviour
{
    public float speed = 1.4f;
    public AwardType awardType;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4.8f)
        {
            Destroy(this.gameObject);
        }
    }
}
