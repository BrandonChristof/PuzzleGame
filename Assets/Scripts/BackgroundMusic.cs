using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource audio_source;

    private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         audio_source = GetComponent<AudioSource>();
         audio_source.volume = 0.15f;
     }
 
     public void PlayMusic()
     {
         if (audio_source.isPlaying) return;
         audio_source.Play();
     }
 
     public void StopMusic()
     {
         audio_source.Stop();
     }

     public void MusicOnOff(){
        if (audio_source.volume != 0f){
            audio_source.volume = 0f;
        }
        else{
            audio_source.volume = 0.15f;
        }
     }
}
