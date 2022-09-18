using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public Text title;
    public Text best_value;
    public Text optimal_value_text;

    public Text num_moves_text;
    public LevelController level_controller;

    public int curr_level;

    private void Awake(){
        curr_level = LevelSelect.GetLevel();
        Debug.Log(curr_level);
    }

    public void Start(){
        UserData data = SaveSystem.LoadData();
        //int level = SceneManager.GetActiveScene().buildIndex;

        title.GetComponent<Text>().text = "Level " + curr_level.ToString();
        optimal_value_text.GetComponent<Text>().text = Levels.levels[curr_level-1][0, 0].ToString();
        best_value.GetComponent<Text>().text = data.user_data[curr_level-1, 0].ToString();
    }
    
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void ResetLevel(){
        SceneManager.LoadScene(1);
    }

    public void NextLevel(){
        LevelSelect.SetLevel(curr_level+1);
        SceneManager.LoadScene(1);
    }

    public void Update(){
        num_moves_text.GetComponent<Text>().text = level_controller.num_moves.ToString();
    }
}
