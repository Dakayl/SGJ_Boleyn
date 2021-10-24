using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private string titre;
    private string texte;
    [SerializeField] private Sprite imageFantasme;
    [SerializeField] private Sprite imageMere;
    [SerializeField] private Sprite imageVictime;
    [SerializeField] private Sprite imageReine;
    [SerializeField] private Sprite imageSainte;
    [SerializeField] private Sprite imageGenereuse;
    [SerializeField] private Sprite imageLambda;
    [SerializeField] private Sprite imagePutain;

    // Start is called before the first frame update
    void Start()
    {
        switch(GlobalParameters.ending){
            case "fantasme":
                break;
            case "mere":
                break;
            case "victime":
                break;
            case "reine":
                break;
            case "sainte":
                break;
            case "genereuse":
                break;
            case "lambda":
                break;
            default:
            case "putain":
                break;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
