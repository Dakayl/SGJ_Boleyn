using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private Audio audioMgt;
    [SerializeField] private AudioClip relatedMusic;
    [Range(0, 1.0f)] public float volume = 1.0f;

    void Awake(){
        audioMgt = GlobalParameters.getAudio();
        if(audioMgt == null){
            audioMgt = gameObject.AddComponent(typeof(Audio)) as Audio;
            GlobalParameters.setAudio(audioMgt);
        }
    }

    void Start()
    {
        
        if(relatedMusic != null) {
           audioMgt.musicVolume = volume;
           audioMgt.playMusic(relatedMusic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
        }
    }
}
