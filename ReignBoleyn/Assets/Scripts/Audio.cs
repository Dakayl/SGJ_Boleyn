using UnityEngine;
using System.Collections;

public class Audio:MonoBehaviour
{
    [Range(0, 1)] [SerializeField] public float musicVolume = 1.0f;
    [Range(0, 1)] [SerializeField] public float ambiantVolume = 1.0f;
    [Range(0, 1)] [SerializeField] public float effectVolume = 1.0f;
    [SerializeField] public float fadeDuration = 1.5f;
    private AudioSource musicAudio;
    private AudioSource ambiantAudio;
    private AudioSource effectAudio;
    private AudioClip nextMusic;
    private IEnumerator coroutineStop;
    private IEnumerator coroutineStart;

    void Awake() {
        musicAudio = gameObject.AddComponent<AudioSource>();
        musicAudio.loop = true;
        musicAudio.volume = musicVolume;
        ambiantAudio = gameObject.AddComponent<AudioSource>();
        effectAudio = gameObject.AddComponent<AudioSource>();
    }   
    protected void Start(){
    }   
    
    public IEnumerator StopFade()
    {
        float currentTime = 0;
        float start = musicAudio.volume;
        if(musicAudio.isPlaying) {
            while (currentTime < fadeDuration)
            {
                currentTime += Time.deltaTime;
                musicAudio.volume = Mathf.Lerp(start, 0, currentTime / fadeDuration);
                yield return null;
            }
            musicAudio.Stop();
        }        
        StartCoroutine(this.StartFade());
        yield break;
    }

    public IEnumerator StartFade()
    {
        float currentTime = 0;
        float end = musicVolume;
        musicAudio.clip = nextMusic;
        musicAudio.Play();
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            musicAudio.volume = Mathf.Lerp(0, end, currentTime / fadeDuration);
            yield return null;
        }
        yield break;
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
    public void playMusic(AudioClip music) {
        if(music != null) {
            nextMusic = music;
            StartCoroutine(this.StopFade());
        }
    }

}