using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    public int health;
    public Slider Slider2;
    private float maxVal;
    private StudioEventEmitter emitter;
    public static bool spider;
    public static int phase;
    public StudioEventEmitter bossDamagedEmitter;
    //anim
    public Animator ground;
    public Animator plat1;
    public Animator plat5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxVal = health;
        emitter = GetComponent<StudioEventEmitter>();
        spider = true;
        phase = 1;
    }
    public void winScreen()
    {
        SceneManager.LoadScene(3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayBull")) {
            Destroy(collision.gameObject);
            health -= 5;
            bossDamagedEmitter.Play();
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
        ground.SetFloat("shakedd",5);
        plat1.SetFloat("platSS", 5);
        plat5.SetFloat("platS",5);
        Debug.Log("shake");
        yield return new WaitForSeconds(3);
        Destroy(GameObject.FindWithTag("ground"));
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("SpiderEnemy");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    public IEnumerator destroyPlatform()
    {
        Debug.Log("shake");
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/GroundShake");
        yield return new WaitForSeconds(3);
        
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Finish");
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

        if (health<(maxVal-(maxVal/3))&&phase==1)
        {
            
            phase = 2;
            

        }
        if (health < (maxVal - (maxVal /2)) && phase == 2)
        {   
            phase = 3;
            spider = false;
            StartCoroutine(destroyGround());
            StartCoroutine(destroyPlatform());
            
        }
        if (health < 0)
        {   
            winScreen();
        }
    }
}
