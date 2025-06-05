using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class bossScript : MonoBehaviour
{
    public int health;
    public Slider Slider2;
    private float maxVal;
    private StudioEventEmitter emitter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxVal = health;
        emitter = GetComponent<StudioEventEmitter>();
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
    }
}
