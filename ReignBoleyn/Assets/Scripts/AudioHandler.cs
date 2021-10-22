using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour
{

    [Range(0, 1)] [SerializeField] float musicVolume = 1.0f;
    [Range(0, 1)] [SerializeField] float ambiantVolume = 1.0f;
    [Range(0, 1)] [SerializeField] float effectVolume = 1.0f;

    private AudioSource musicAudio;
    private AudioSource ambiantAudio;
    private AudioSource effectAudio;

    public void playMusic(AudioClip music){
        if(music != null){
            musicAudio.PlayOneShot(music, musicVolume);
        }
    }

    public void playAmbiant(AudioClip ambiant){
        if(ambiant != null){
            ambiantAudio.PlayOneShot(ambiant, ambiantVolume);
        }    
    }

    public void playEffect(AudioClip effect){
        if(effect != null){
            effectAudio.PlayOneShot(effect, effectVolume);
        }
        
    }

}