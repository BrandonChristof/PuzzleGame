using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    

    public int lvl;
    
    public void StartPuzzle(){
        SceneManager.LoadScene(lvl);
    }
}
