using UnityEngine;
using UnityEngine.SceneManagement;

public class forOpening : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void startScreen()
    {
        SceneManager.LoadScene(0);
    }
    
}
