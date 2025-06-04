using System.Collections;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemy;
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
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
