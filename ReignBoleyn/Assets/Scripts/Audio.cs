using UnityEngine;
using System.Collections;

public class Audio:MonoBehaviour
{
    [Range(0, 1)] [SerializeField] public float musicVolume = 1.0f;
    [Range(0, 1)] [SerializeField] public float ambiantVolume = 1.0f;
    [Range(0, 1)] [SerializeField] public float effectVolume = 1.0f;
    private AudioSource musicAudio;
    private AudioSource ambiantAudio;
    private AudioSource effectAudio;


    void Awake() {
        AudioSource musicAudio = gameObject.AddComponent<AudioSource>();
        musicAudio.loop = true;
        musicAudio.volume = musicVolume;


        AudioSource ambiantAudio = gameObject.AddComponent<AudioSource>();
        AudioSource effectAudio = gameObject.AddComponent<AudioSource>();
    }

    public void playMusic(AudioClip music) {
        if(music != null) {
            //if(musicAudio.isPlaying) {
            //    musicAudio.Stop();
            //}
  
            musicAudio.Play();
        }
    }

    public void playAmbiant(AudioClip ambiant) {
        if(ambiant != null) {
            ambiantAudio.PlayOneShot(ambiant, ambiantVolume);
        }    
    }

    public void playEffect(AudioClip effect) {
        if(effect != null) {
            effectAudio.PlayOneShot(effect, effectVolume);
        }
        
    }
}