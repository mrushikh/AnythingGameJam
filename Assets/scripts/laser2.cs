using System.Collections;
using UnityEngine;

public class laser2 : MonoBehaviour
{
    public int speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public IEnumerator die1()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    private void Start()
    {
        StartCoroutine(die1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
