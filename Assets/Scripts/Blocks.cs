using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blocks : MonoBehaviour
{
    public float size;
    public void Play()
    {
    SceneManager.LoadScene("2D_Runner");  
    }
    public void MainManu()
    {
        SceneManager.LoadScene("2D_Manu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("2D_Runner");
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update

}
