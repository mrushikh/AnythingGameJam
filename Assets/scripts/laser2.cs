using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class laser2 : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public StudioEventEmitter SpiderBotLaserEmitter;
    public IEnumerator die1()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    private void Start()
    {   
        if (SpiderBotLaserEmitter != null)
            {
                SpiderBotLaserEmitter.Play();
            }
        transform.Rotate(0, 0, 90);
        StartCoroutine(die1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
