using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class laserBullet : MonoBehaviour
{
    public int speed;
    public StudioEventEmitter EyebotLaserEmitter;
    
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
    
}
