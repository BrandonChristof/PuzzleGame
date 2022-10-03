using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public static int ad_freq = 10;
    public static int ad_tracker = ad_freq;
    public static int load_level;
    public int lvl;

    public static int GetLevel() { return load_level; }
    public static void SetLevel(int l) { load_level=l; }
    
    public void StartPuzzle(){
        load_level = lvl;
        LevelSelect.SetLevel(lvl);
        SceneManager.LoadScene(2);
    }
}
