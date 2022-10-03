using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(1); 
    }

    public void Back(){
        SceneManager.LoadScene(0); 
    }
}
