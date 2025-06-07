using System.Collections;
using UnityEngine;

public class MouthLaser : MonoBehaviour
{// Start is called once before the first execution of Update after the MonoBehaviour is created

    public IEnumerator die1()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
    private void Start()
    {
        StartCoroutine(die1());
    }

   
}
