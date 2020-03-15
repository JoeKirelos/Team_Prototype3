using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;
    Vector2 direction;
    Vector2 mousePosition;
    float horDir;
    float verDir;
    Vector2 horMove = new Vector2(1f,0f);
    Vector2 verMove = new Vector2(0f,1f);
    public Rigidbody2D player;
    public float speed;
    public Transform firePoint;
    public LineRenderer lr;
    public int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        horDir = Input.GetAxisRaw("Horizontal");
        verDir = Input.GetAxisRaw("Vertical");
        Aiming();
        Shooting();
        Moving();
        EndGame();
    }

    void Aiming()
    {
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
           RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
            if (hitInfo)
            {
                lr.SetPosition(0, firePoint.position);
                lr.SetPosition(1, hitInfo.point);


               enemy enemy = hitInfo.transform.GetComponent<enemy>();
                if( enemy != null)
                {
                    enemy.DestroySelf();
                }
                bullets bullet = hitInfo.transform.GetComponent<bullets>();
                if (bullet != null)
                {
                    bullet.DestroySelf();
                }

            }
            else
            {
                lr.SetPosition(0, firePoint.position);
                lr.SetPosition(1, firePoint.position + firePoint.up * 100);
            }
            lr.enabled = true;
            Invoke("DisableLine", 0.02f);

        }
    }
    void Moving()
    {

        player.position += (horMove * horDir * speed * Time.deltaTime);
        player.position += (verMove * verDir * speed * Time.deltaTime);
    }
    void DisableLine()
    {
        lr.enabled = false;
    }

    public void TakeDamage()
    {
        hitPoints--;
    }

    void EndGame()
    {
        if(hitPoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
