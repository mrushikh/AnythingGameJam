using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Slider = UnityEngine.UI.Slider;

public class moveAndShoot : MonoBehaviour
{
    // Left/Right Movement
    private Rigidbody2D rb;
    private float moveX;
    private Vector2 movement;
    public float MoveSpeed = 5f;
    public SpriteRenderer SpriteRenderer;
    private bool leftfacing=false;
    private bool onPlatform=false;

    // Jumping
    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool OnGround;

    //health
    public int healthInt;

    //enemySpawn
    public GameObject enemySpawner;
    
    private float timeCount1 = 5;
    //spiderSpawn
    public GameObject enemySpawner2;
    public GameObject enemySpawner3;
    //slider
    public Slider Slider1;
    private int maxVal1;
    private float timeCount2 = 5;
    //laserMouth
    public GameObject laserMouth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnGround = true;
        maxVal1=healthInt;

    }
    public void healthbar1(float currentValue, float maxValue)
    {
        if (healthInt == 0)
        {
            Slider1.fillRect.gameObject.SetActive(false);
        }
        Slider1.value = currentValue / maxValue;

    }
    public void spawnEnem()
    {
        
        
        
            float[] spot = { -12.8f, -7.2f, 0, 7.2f, 12.6f };
            int space=Random.Range(0,5);
            float spawnX=spot[space];
            Vector2 spaw=new Vector2(spawnX,12);
            Instantiate(enemySpawner,spaw,Quaternion.identity);
            
        
    }

    public void spawnEnem2()
    {
        int pick=Random.Range(0,2);
        if (pick == 0)
        {
            Instantiate(enemySpawner2, new Vector2(-17,13), Quaternion.identity);
        }
        if (pick == 1)
        {
            Instantiate(enemySpawner3, new Vector2(17, 13), Quaternion.identity);
        }

    }


    public IEnumerator spawnLazerMouth()
    {   
        Instantiate(laserMouth,new Vector2(0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        
    }
    public IEnumerator falltimer()
    {   
        GetComponent<BoxCollider2D>().enabled = false;  
        yield return new WaitForSeconds(0.2f);
        GetComponent<BoxCollider2D>().enabled=true;


    }

    public IEnumerator damage(int a)
    {
        healthInt -= a;
        yield return new WaitForSeconds(2f);

    }

    void Update()
    {   //slider
        healthbar1(healthInt, maxVal1);

        //spawning enemy
        timeCount1 -= Time.deltaTime;
        if (timeCount1 < 0) { 
            spawnEnem();
            timeCount1 = 3;
            StartCoroutine(spawnLazerMouth());
        }

        timeCount2 -= Time.deltaTime;
        if (timeCount2 < 0)
        {
            spawnEnem2();
            timeCount2 = 2;
       
        }
        //fliping
        moveX = Input.GetAxisRaw("Horizontal");
        if (moveX < 0)
        {
            if (leftfacing==false)
            {
                transform.Rotate(0, 180, 0);
                leftfacing = true;
            }

        }
        else if (moveX > 0)
        {
            if (leftfacing == true)
            {
                transform.Rotate(0, 180, 0);
                leftfacing=false;
            }

        }

        //jump movement check
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            // Make our player jump
            rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpForce);
            OnGround = false;
        }
        
       
        //fallthrough platform
        
        if (Input.GetKey(KeyCode.S)&&onPlatform==true&&rb.position.y>-4.5)
        {

            StartCoroutine(falltimer());

        }


       

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we collided with the ground
        if (GroundLayer == (1 << other.gameObject.layer))
        {
            OnGround = true;
            onPlatform = false;
        }

        //check if onplatform
        if (other.CompareTag("platform"))
        {   
            onPlatform = true;


        }
        else
        {
            onPlatform=false;
        }
        if (other.CompareTag("EnemyBull"))
        {
            StartCoroutine (damage(10));
        }
        if (other.CompareTag("EnemyEye"))
        {
            StartCoroutine(damage(5));
        }
        if (other.CompareTag("SpiderEnemy"))
        {
            StartCoroutine(damage(5));
        }
        if (other.CompareTag("laser2"))
        {
            StartCoroutine(damage(10));
        }
        //Debug.Log(healthInt);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        onPlatform=false ;
    }
    //movement
    void FixedUpdate()
    {
        // Determine our movement vector based on our speed and move inputs
        movement = new Vector2(moveX * MoveSpeed, rb.linearVelocityY);

        // Make our player move left/right
        rb.linearVelocity = movement;
    }
}
