using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public Text title;
    public Text best_value;
    public Text optimal_value;

    public Text num_moves_text;
    public LevelController level_controller;

    public void Start(){
        UserData data = SaveSystem.LoadData();
        int level = level_controller.data.GetComponent<LevelData>().level;

        title.GetComponent<Text>().text = "Level " + level.ToString();
        optimal_value.GetComponent<Text>().text = level_controller.data.GetComponent<LevelData>().star_moves.ToString();

        best_value.GetComponent<Text>().text = data.user_data[level-1, 0].ToString();
    }
    
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void ResetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Update(){
        num_moves_text.GetComponent<Text>().text = level_controller.num_moves.ToString();
    }
}
