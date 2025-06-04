using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera Camera;
    private Rigidbody2D rb;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos=Camera.ScreenToWorldPoint(Input.mousePosition);

        //bulletet script
        Vector3 rotation1 = transform.position - mousePos;
        Vector3 direction = mousePos - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot1 = Mathf.Atan2(rotation1.y, rotation1.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot1 + 90);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (rb.position.x>15||rb.position.x<-15||rb.position.y>10||rb.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
