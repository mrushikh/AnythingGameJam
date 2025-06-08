using System;
using System.Collections;
using UnityEngine;

public class enemyPatrol1 : MonoBehaviour
{   //patrol1
    public GameObject pointC;
    public GameObject pointD;
    private Rigidbody2D rb;
    private bool faceLeft = true;
    private Transform currPoint;
    public float speed;

    //laser
    private bool laserOccur=false;
    public GameObject laser2;
    public Transform statPoint;

    private float timeLeft=5;
    //health
    public int health;
    private Collider2D col;
    public GameObject parent;
    //animator
    Animator animator1;
    public IEnumerator spawnLaser1()
    {

       
            laserOccur = true;
            rb.linearVelocityX = 0;
            yield return new WaitForSeconds(0.5f);
            float yOffset=(laser2.transform.localScale.y)/2;
            Vector2 place = new Vector2(statPoint.position.x, statPoint.position.y+8.3f);
            
            Instantiate(laser2, place, Quaternion.identity);
            yield return new WaitForSeconds(1);
            laserOccur = false;
       

    }
    public IEnumerator letPass(float b)
    {


        col.enabled = false;
        yield return new WaitForSeconds(b);
        col.enabled = true;


    }
    
    private void OnDestroy()
    {
        Destroy(parent);
        Destroy(pointC);
        Destroy(pointD);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator1 = GetComponent<Animator>();
        currPoint = pointD.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;       
        

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5 && currPoint == pointD.transform)
        {
            currPoint = pointC.transform;
            if (faceLeft == true)
            {
                transform.Rotate(0, 180, 0);
                faceLeft = false;
            }
            
            
        }
        if (Vector2.Distance(transform.position, currPoint.position) < 0.5 && currPoint == pointC.transform)
        {
            currPoint = pointD.transform;
            if (faceLeft == false)
            {
                transform.Rotate(0, 180, 0);
                faceLeft = true;
            }
            
            
        }

        if (timeLeft<0){
            StartCoroutine(spawnLaser1());
            timeLeft = 5;
        }
        if (health < 1)
        {

            Destroy(pointC);
            Destroy(pointD);
            Destroy(gameObject);

        }
        if (laserOccur == false)
        {
            if (animator1 != null)
            {
                animator1.SetFloat("shoot", 1);
            }
        }
        else
        {
            if (animator1 != null)
            {
                animator1.SetFloat("shoot", 0);
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
       
        if (collision.CompareTag("SpiderEnemy"))
        {
            int rand = UnityEngine.Random.Range(0, 4);
            if (rand <3)
            {
                StartCoroutine(letPass(0.5f));
            }
            else 
            {
                if (collision.gameObject != null)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(letPass(0.5f));
        }
    }
    private void FixedUpdate()
    {
        
        if (currPoint == pointD.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        if (currPoint == pointC.transform)
        {

            rb.linearVelocity = new Vector2(-speed, 0);
        }
        if (laserOccur == true)
        {
            rb.linearVelocity = new Vector2(0, 0);
            
            

        }
       
    }
}
