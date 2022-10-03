using UnityEngine.UI;
using UnityEngine;

public class PercentScript : MonoBehaviour
{
    public Text percent_text;

    void Start(){

        UserData data = SaveSystem.LoadData();
        if (data == null){
            data = new UserData();
        }
        SaveSystem.SaveGame(data);
        int total = 0;
        for (int i = 0; i < 60; i++) {
            int rank = data.user_data[i, 1];
            if (rank == 2){
                total = total + 2;
            }
            else if(rank == 1){
                total++;
            }
        }
        float percent = (total/120f)*100f;
        percent_text.GetComponent<Text>().text = percent.ToString("F2") + "%";
    }
}
