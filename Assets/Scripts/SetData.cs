using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetData : MonoBehaviour
{

    public Sprite[] icon = new Sprite[3];
    public Sprite[] button = new Sprite[3];
    public Text completed_text;
    public Text star_text;

    void Start(){

        //RESET GAME
        //ResetGame();
        
        UserData data = SaveSystem.LoadData();
        GameObject[] levels = GameObject.FindGameObjectsWithTag("level_button");

        int total_completed = 0;
        int total_stars = 0;

        foreach (GameObject level in levels) {
            int rank = data.user_data[level.GetComponent<LevelSelect>().lvl-1, 1];
            if (rank == 2){
                total_stars++;
                total_completed++;
            }
            else if(rank == 1){
                total_completed++;
            }
            level.transform.GetChild(0).gameObject.GetComponent<Text>().text = level.GetComponent<LevelSelect>().lvl.ToString();
            level.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = icon[rank];
            level.gameObject.GetComponent<Image>().sprite = button[rank];
        }
        
        completed_text.GetComponent<Text>().text = total_completed.ToString();
        star_text.GetComponent<Text>().text = total_stars.ToString();
    }

    public void ResetGame(){
        UserData reset = new UserData();
        SaveSystem.SaveGame(reset);
    }

}
