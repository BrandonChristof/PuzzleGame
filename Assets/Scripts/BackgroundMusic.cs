using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public static bool first_startup = true;
    public static bool sound_effects = true;
    public static AudioSource audio_source;
    public GameObject sound_button;
    public Color on_color = new Color(0.17f, 0.82f, 0.14f);
    public Color on_text_color = new Color(0f, 0.35f, 0.03f, 0.91f);
    public Color off_color = new Color(0.82f, 0.17f, 0.14f, 0.91f);
    public Color off_text_color = new Color(0.35f, 0f, 0.03f, 0.91f);

    private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         //audio_source = GetComponent<AudioSource>();
        
        if (first_startup){
            audio_source = GetComponent<AudioSource>();
            audio_source.volume = 0.1f;
            PlayMusic();
            first_startup = false;
        }
        if (audio_source.volume != 0f){
            sound_button.GetComponent<Image>().color = Color.green;
        }
        else{
            sound_button.GetComponent<Image>().color = Color.red;
        }
     }
 
     public void PlayMusic()
     {
        sound_button.GetComponent<Image>().color = Color.green;
        if (audio_source.isPlaying) return;
        audio_source.Play();
     }
 
     public void StopMusic()
     {
        sound_button.GetComponent<Image>().color = Color.red;
        audio_source.Stop();
        sound_effects = false;
     }

     public void MusicOnOff(){
        if (audio_source.volume != 0f){
            sound_button.GetComponent<Image>().color = Color.red;
            audio_source.volume = 0f;
            sound_effects = false;
        }
        else{
            sound_button.GetComponent<Image>().color = Color.green;
            audio_source.volume = 0.1f;
            sound_effects = true;
        }
     }
}
