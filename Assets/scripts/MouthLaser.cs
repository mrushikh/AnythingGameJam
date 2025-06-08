using System.Collections;
using UnityEngine;

public class MouthLaser : MonoBehaviour
{// Start is called once before the first execution of Update after the MonoBehaviour is created
    public int dieTime;
    public IEnumerator die1()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);

    }
    private void Start()
    {   
        StartCoroutine(die1());
    }

   
}
