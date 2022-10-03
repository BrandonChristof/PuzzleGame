using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using GoogleMobileAds.Api;

public class LevelUI : MonoBehaviour
{
    public Interstitial interstitial_obj;
    public Text title;
    public Text best_value;
    public Text optimal_value_text;

    public Text num_moves_text;
    public LevelController level_controller;

    public int curr_level;
    public Button reset_button;

    private void Awake(){
        curr_level = LevelSelect.GetLevel();
        Debug.Log(curr_level);
    }

    public void Start(){
        UserData data = SaveSystem.LoadData();
        reset_button.interactable = false;
        title.GetComponent<Text>().text = "Level " + curr_level.ToString();
        optimal_value_text.GetComponent<Text>().text = Levels.levels[curr_level-1][0, 0].ToString();
        best_value.GetComponent<Text>().text = data.user_data[curr_level-1, 0].ToString();
    }
    
    public void MainMenu(){
        if (LevelSelect.ad_tracker == 0){
            LevelSelect.ad_tracker = LevelSelect.ad_freq;
            interstitial_obj.ShowInterstitialAd();
            interstitial_obj.interstitial.OnAdClosed += interstitial_obj.HandleOnAdClosed_menu;
        }
        else{
            LevelSelect.ad_tracker -= 1;
            SceneManager.LoadScene(1);
        }
    }

    public void ResetLevel(){
        if (LevelSelect.ad_tracker == 0){
            LevelSelect.ad_tracker = LevelSelect.ad_freq;
            interstitial_obj.ShowInterstitialAd();
            interstitial_obj.interstitial.OnAdClosed += interstitial_obj.HandleOnAdClosed_reset;
        }
        else{
            LevelSelect.ad_tracker -= 1;
            SceneManager.LoadScene(2);
        }
    }

    public void NextLevel(){
        LevelSelect.SetLevel(curr_level+1);
        SceneManager.LoadScene(2);
    }

    public void Update(){
        num_moves_text.GetComponent<Text>().text = level_controller.num_moves.ToString();
        if (level_controller.num_moves > 0){
            reset_button.interactable = true;
        }
    }
}
