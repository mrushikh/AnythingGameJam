using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{   //takes double damage
    //patrol
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private bool faceLeft = true;
    private Transform currPoint;
    public float speed;

    //laser
    public GameObject laser1;
    private Vector2 scaleChange;
    public Transform startPoint;
    private bool laserHap = false;
    //health
    public int health;
    private Collider2D col1;
    public GameObject parent1;
    private bool active;

    private bool notFirst;
    public IEnumerator spawnLaser()
    {

        if (currPoint == pointB.transform)
        {
            laserHap = true;

            scaleChange.x = 1.95f;
            laser1.transform.localScale = scaleChange;
            Vector2 place = new Vector2(startPoint.position.x + 2.2f, startPoint.position.y);

            Instantiate(laser1, place, Quaternion.identity);
            yield return new WaitForSeconds(1);
            laserHap = false;
        }
        else if (currPoint == pointA.transform)
        {
            laserHap = true;
            scaleChange.x = 1.95f;
            laser1.transform.localScale = scaleChange;
            Vector2 place1 = new Vector2(startPoint.position.x - 2.2f, startPoint.position.y);
            Instantiate(laser1, place1, Quaternion.identity);
            yield return new WaitForSeconds(1);
            laserHap = false;
        }

    }
    
    public IEnumerator letPass1(float a)
    {
        col1.enabled = false;
        yield return new WaitForSeconds(a);
        col1.enabled = true;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleChange.y = 2f;
        rb = GetComponent<Rigidbody2D>();
        col1 = GetComponent<Collider2D>();
        currPoint = pointB.transform;
        

    }
    private void OnDestroy()
    {
        Destroy(parent1);
        Destroy(pointB);
        Destroy(pointA);

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 point = currPoint.position - transform.position;
        if (currPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        if (currPoint == pointA.transform)
        {

            rb.linearVelocity = new Vector2(-speed, 0);
        }
        if (laserHap == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5 && currPoint == pointB.transform)
        {
            currPoint = pointA.transform;
            if (faceLeft == true)
            {
                transform.Rotate(0, 180, 0);
                faceLeft = false;
            }
            rb.linearVelocity = new Vector2(0, 0);
            StartCoroutine(spawnLaser());
        }
        if (Vector2.Distance(transform.position, currPoint.position) < 0.5 && currPoint == pointA.transform)
        {
            currPoint = pointB.transform;
            if (faceLeft == false)
            {
                transform.Rotate(0, 180, 0);
                faceLeft = true;
            }
            rb.linearVelocity = new Vector2(0, 0);
            StartCoroutine(spawnLaser());
        }
        //death
        if (health < 1)
        {
            
            Destroy(gameObject);

        }

        if (bossScript.phase==3&&notFirst==false)
        {   
            notFirst = true;
            if (rb.transform.position.x>10|| rb.transform.position.x < -10) { 
                Destroy(gameObject);
            }
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayBull"))
        {
            
            Destroy(collision.gameObject);
            health = health - 5;
        }
        if (collision.CompareTag("EnemyEye"))
        {
            
            int rand = Random.Range(0, 4);

            if (rand < 3||laserHap==true)
            {
                StartCoroutine(letPass1(0.5f));
            }
            else
            {
                if (collision.gameObject != null)
                {
                    Destroy(collision.gameObject);
                }
            }

        }
        if (collision.CompareTag("SpawnEye"))
        {
            
            if (collision.gameObject != null)
            {
                StartCoroutine(letPass1(0.2f));
            }
        }

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(letPass1(0.3f));
        }




    }
}
  

