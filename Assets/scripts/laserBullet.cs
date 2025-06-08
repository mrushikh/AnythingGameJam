using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class laserBullet : MonoBehaviour
{
    public int speed;
<<<<<<< Updated upstream
    private Rigidbody2D rb;
=======
    public StudioEventEmitter EyebotLaserEmitter;
    
>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public IEnumerator die()
    {
        yield return new WaitForSeconds(speed);
        Destroy(gameObject);

    }
    
    void Start()
    {
        if (EyebotLaserEmitter != null)
            {
                EyebotLaserEmitter.Play();
            }
        StartCoroutine(die());
        //rb=GetComponent<Rigidbody2D>();
        //rb.linearVelocity = transform.right * speed;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("EnemyEye"))
    //    {
    //        if (collision.gameObject!=null)
    //        {
    //            Destroy(collision.gameObject);
    //        }
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        //if (rb.position.x>15||rb.position.x<-15||rb.position.y>10||rb.position.y<-10)
        //{
        //    if (gameObject != null)
        //    {
        //        Destroy(gameObject);
        //    }
            
        //}
    }
}
