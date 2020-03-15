using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public Transform player;
    public float speed;
    public Rigidbody2D rb;
    public GameObject self;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        target = (transform.position - player.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= target* speed * Time.deltaTime;
    }

    public void DestroySelf()
    {
        Destroy(self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            Destroy(self);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage();
            Destroy(self);
        }
    }
}
