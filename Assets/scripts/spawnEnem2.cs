using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnem2 : MonoBehaviour
{
    public GameObject spider1;
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
        if (collision.CompareTag("ground"))
        {   

            Instantiate(spider1, new Vector2(transform.position.x,-4), Quaternion.identity);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
