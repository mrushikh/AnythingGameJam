using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using System.Collections;

public class bossScript : MonoBehaviour
{
    public int health;
    public Slider Slider2;
    private float maxVal;
    private StudioEventEmitter emitter;
    public static bool spider;
    private int phase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxVal = health;
        emitter = GetComponent<StudioEventEmitter>();
        spider = true;
        phase = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayBull")) {
            Destroy(collision.gameObject);
            health -= 5;
        }
    }
    public void  healthbar(float currentValue,float maxValue)
    {
        if (health==0) {
            Slider2.fillRect.gameObject.SetActive(false);
        }
        Slider2.value = currentValue/maxValue;
        
    }

    public IEnumerator destroyGround() {
        Debug.Log("shake");
        yield return new WaitForSeconds(2);
        Destroy(GameObject.FindWithTag("ground"));
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("SpiderEnemy");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    // Update is called once per frame
    void Update()
    {

        healthbar(health,maxVal);

         if (emitter != null && emitter.IsPlaying())
        {
            if (health <= maxVal / 3f)
            {
                emitter.SetParameter("BossPhase", 3);
            }
            else if (health <= (2f * maxVal) / 3f)
            {
                emitter.SetParameter("BossPhase", 2);
            }
            else
            {
                emitter.SetParameter("BossPhase", 1);
            }
        }

        if (health<maxVal/2&&phase==1)
        {
            phase = 2;
            spider = false;
            StartCoroutine(destroyGround());
            
        }
    }
}
