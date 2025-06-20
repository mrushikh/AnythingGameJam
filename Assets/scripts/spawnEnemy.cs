using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public StudioEventEmitter EyebotSpawnEmitter;
    private bool spawned;
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        StartCoroutine(destroy());
        spawned=false;
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("platform")|| collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
            if (spawned == false)
            {
                Instantiate(enemy, new Vector2(transform.position.x, transform.position.y + 0.01f), Quaternion.identity);
                if (EyebotSpawnEmitter != null)
                    {
                        EyebotSpawnEmitter.Play();
                    }
                spawned = true;
            }

        }
        if (collision.CompareTag("Player"))
        {
            if (gameObject!=null) {
                Destroy(gameObject);
            }
        }
    }   
}
