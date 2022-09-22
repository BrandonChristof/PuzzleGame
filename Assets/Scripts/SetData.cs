using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetData : MonoBehaviour
{
    public GameObject scroller;
    public static float scroll_position = 99999f;
    //public static int GetScrollPosition() { return load_level; }
    //public static void SetScrollPosition(int l) { load_level=l; }


    public Sprite[] button = new Sprite[3];
    public GameObject butt;
    public Transform canvas;
    public Text completed_text;
    public Text star_text;

    void Start(){

        Application.targetFrameRate = 60;
        
        //RESET GAME
        //ResetGame();
        int y = 0;
        int counter = 0;
        float w = Screen.width;
        float h = Screen.height;
        float ratio = (w/h);
        Debug.Log(ratio);
        if (ratio > 0.7f){
            ratio = 1.75f;
        }
        else if (ratio > 0.5f){
            ratio = 1.5f;
        }
        else{
            ratio = 1.25f;
        }

        
        GameObject temp_button = (GameObject)Instantiate(butt, new Vector3(0, -19*ratio+3f, 0f), Quaternion.identity, canvas);
        RectTransform button_rt = temp_button.GetComponent (typeof (RectTransform)) as RectTransform;
        RectTransform rt = scroller.GetComponent (typeof (RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(950, -button_rt.localPosition.y+200f);
        Destroy(temp_button);
        
        for (int row=0; row < 20; row++){
            for (int col=1; col <= 3; col++){
                //GameObject lvl_butt = (GameObject)Instantiate(butt, new Vector3((col-2)*1.35f, -row*1.5f+3.35f, 0f), Quaternion.identity, canvas);
                GameObject lvl_butt = (GameObject)Instantiate(butt, new Vector3((col-2)*ratio, -row*ratio+3f, 0f), Quaternion.identity, canvas);
                //GameObject lvl_butt = (GameObject)Instantiate(butt, new Vector3((col-2), -row+3.35f, 0f), Quaternion.identity, canvas);
                counter++;
                lvl_butt.transform.GetChild(0).gameObject.GetComponent<Text>().text = counter.ToString();
                lvl_butt.GetComponent<LevelSelect>().lvl = counter;
                lvl_butt.tag = "level_button";
            }
        }

        
        
        
        UserData data = SaveSystem.LoadData();
        GameObject[] levels = GameObject.FindGameObjectsWithTag("level_button");

        int total_completed = 0;
        int total_stars = 0;

        
        foreach (GameObject level in levels) {
            int rank = data.user_data[level.GetComponent<LevelSelect>().lvl-1, 1];
            if (rank == 2){
                total_stars++;
                total_completed++;
                level.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
            }
            else if(rank == 1){
                total_completed++;
                level.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
            }
            level.transform.GetChild(0).gameObject.GetComponent<Text>().text = level.GetComponent<LevelSelect>().lvl.ToString();
            level.gameObject.GetComponent<Image>().sprite = button[rank];
        }
        
        completed_text.GetComponent<Text>().text = total_completed.ToString();
        star_text.GetComponent<Text>().text = total_stars.ToString();

        if (scroll_position!=99999f){
            scroller.transform.position = new Vector3(scroller.transform.position.x, scroll_position, scroller.transform.position.z);
        }
    }

    public void ResetGame(){
        UserData reset = new UserData();
        SaveSystem.SaveGame(reset);
    }

    void Update(){
        scroll_position = scroller.transform.position.y;
    }
}
