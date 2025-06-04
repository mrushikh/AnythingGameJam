using Unity.Mathematics;
using UnityEngine;

public class shooting : MonoBehaviour
{   //gun follow
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBWFiring;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        mainCam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        }

        
    }
}
