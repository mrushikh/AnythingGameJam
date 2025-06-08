using Unity.Mathematics;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class shooting : MonoBehaviour
{   //gun follow
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject player;
    public SpriteRenderer gun;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBWFiring;
    private bool gunLeft;

    // FMOD emitter reference
    public StudioEventEmitter gunshotEmitter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunshotEmitter = GetComponent<StudioEventEmitter>(); // Telling Unity to talk to FMOD Studio Event Emitter component
        mainCam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gunLeft=false;
    }

    // Update is called once per frame
    void Update()
    {
        


        //follow script
        mousePos=mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation=mousePos - transform.position;
        float rotZ=Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0,0,rotZ);
        if(!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBWFiring)
            {
                canFire=true;
                timer=0;
            }
        }
        if(Input.GetMouseButton(0)&&canFire)
        {
            canFire=false;
            Instantiate(bullet,bulletTransform.position,Quaternion.identity);
            if (gunshotEmitter != null) // Playing gunshot SFX via the emitter
            {
                gunshotEmitter.Play();
            }
        }

        if (bulletTransform.transform.position.x<player.transform.position.x&&gunLeft==false)
        {
            gun.flipY = !gun.flipY;
            gunLeft = true;
        }
        if (bulletTransform.transform.position.x > player.transform.position.x && gunLeft == true)
        {
            gun.flipY = !gun.flipY;
            gunLeft = false;
        }

    }
}
