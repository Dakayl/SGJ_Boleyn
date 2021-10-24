using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionScript : MonoBehaviour
{
    private Audio audioMgt;
    [SerializeField] private AudioClip soundToPlay;
    [Range(0, 1.0f)] public float volume = 1.0f;
    // Start is called before the first frame update

    void Awake() {
        audioMgt = GlobalParameters.getAudio();
        if(audioMgt == null){
            audioMgt = gameObject.AddComponent(typeof(Audio)) as Audio;
            GlobalParameters.setAudio(audioMgt);
        }
    }

    void Start()
    {
        audioMgt.stopMusic();
        if(soundToPlay != null) {
           audioMgt.musicVolume = volume;
           audioMgt.playAmbiant(soundToPlay);
        }
        Invoke("leave", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void leave(){
         SceneManager.LoadScene("Ending", LoadSceneMode.Single);
    }
}
