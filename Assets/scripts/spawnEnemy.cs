using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy;
<<<<<<< Updated upstream
=======
    public StudioEventEmitter EyebotSpawnEmitter;
    private bool spawned;
>>>>>>> Stashed changes
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(destroy());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("platform")) { 
            Instantiate(enemy,new Vector2(transform.position.x,transform.position.y+0.01f),Quaternion.identity);
            Destroy(gameObject);
<<<<<<< Updated upstream
        }
=======
            if (spawned == false)
            {
                Instantiate(enemy, new Vector2(transform.position.x, transform.position.y + 0.01f), Quaternion.identity);
                if (EyebotSpawnEmitter != null)
                    {
                        EyebotSpawnEmitter.Play();
                    }
                spawned = true;
            }
>>>>>>> Stashed changes

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
