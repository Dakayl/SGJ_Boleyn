using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{
    private Canvas canvas;
    private TextMeshProUGUI description;
    private TextMeshProUGUI titre;
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
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        titre = canvas.transform.Find("Titre").GetComponent<TextMeshProUGUI>();
        description = canvas.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        switch(GlobalParameters.ending){
            case "fantasme":
                titre.SetText("La Fantasmée");
                break;
            case "mere":
                titre.SetText("La Mère");
                break;
            case "victime":
                titre.SetText("La Victime");
                break;
            case "reine":
                titre.SetText("La Victime");
                break;
            case "sainte":
                titre.SetText("La Sainte");
                break;
            case "genereuse":
                titre.SetText("La Généreuse");
                break;
            case "lambda":
                titre.SetText("La reine lambda");
                break;
            default:
            case "putain":
                titre.SetText("La Putain");
                break;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
