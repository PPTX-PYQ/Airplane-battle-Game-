using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy0Prefab;
    public float enemy0SpawnInterval = 1;


    public GameObject enemy1Prefab;
    public float enemy1SpawnInterval = 5;


    public GameObject enemy2Prefab;
    public float enemy2SpawnInterval = 15;

    public GameObject award1Prefab;
    public float award1SpawnInterval = 8;

    public GameObject award2Prefab;
    public float award2SpawnInterval = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy0", 1, enemy0SpawnInterval);
        InvokeRepeating("SpawnEnemy1", 1, enemy1SpawnInterval);
        InvokeRepeating("SpawnEnemy2", 1, enemy2SpawnInterval);

        InvokeRepeating("SpawnAward1", 1, award1SpawnInterval);
        InvokeRepeating("SpawnAward2", 1, award2SpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy0()
    {
        float x = Random.Range(-1.98f, 1.98f);
        Instantiate(enemy0Prefab, new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
    }
    void SpawnEnemy1()
    {
        float x = Random.Range(-1.95f, 1.95f);
        Instantiate(enemy1Prefab, new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
    }
    void SpawnEnemy2()
    {
        float x = Random.Range(-1.46f, 1.46f);
        Instantiate(enemy2Prefab, new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
    }
    void SpawnAward1()
    {
        float x = Random.Range(-1.96f, 1.96f);
        Instantiate(award1Prefab, new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
    }
    void SpawnAward2()
    {
        float x = Random.Range(-1.96f, 1.96f);
        Instantiate(award2Prefab, new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
    }
}
