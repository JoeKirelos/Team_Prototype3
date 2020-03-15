using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    GameObject currentEnemy;
    public float shootingInt;
    public float randomizerEnemyInt;
    public float bounceEnemyInt;
    public float enemyInitialShoot;
    public Vector3 movement = new Vector3(1, 1,0);
    public float speed;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 0f);
        Invoke("OneTwo", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position += (movement * speed * Time.deltaTime);
    }

    void Spawn()
    { if(currentEnemy == null)
        {
            currentEnemy = (Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation));
        }
        currentEnemy.GetComponent<enemy>().initialShoot = enemyInitialShoot;
        currentEnemy.GetComponent<enemy>().shootInterval = shootingInt;
        currentEnemy.GetComponent<enemy>().randomizerInt = randomizerEnemyInt;
        currentEnemy.GetComponent<enemy>().bounceInt = bounceEnemyInt;
        Invoke("Spawn", 1.5f);

    }
    void OneTwo()
    {
        speed = -speed;
        Invoke("OneTwo", 2f);
    }
}
