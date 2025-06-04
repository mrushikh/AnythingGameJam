using UnityEngine;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    public int health;
    public Slider Slider2;
    private float maxVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxVal = health;
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

    }
}
