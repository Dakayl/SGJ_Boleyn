using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{
    private Canvas canvas;
    private TextMeshProUGUI description;
    private TextMeshProUGUI titre;
    private Image fond;
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
        fond = canvas.transform.Find("Fond").GetComponent<Image>();
        switch(GlobalParameters.ending){
            case "fantasme":
                titre.SetText("La Fantasmée");
                fond.sprite = imageFantasme;
                break;
            case "mere":
                titre.SetText("La Mère");
                fond.sprite = imageMere;
                break;
            case "victime":
                titre.SetText("La Victime");
                fond.sprite = imageVictime;
                break;
            case "reine":
                titre.SetText("La Reine");
                fond.sprite = imageReine;
                break;
            case "sainte":
                titre.SetText("La Sainte");
                fond.sprite = imageSainte;
                break;
            case "genereuse":
                titre.SetText("La Généreuse");
                fond.sprite = imageGenereuse;
                break;
            case "lambda":
                titre.SetText("La reine lambda");
                fond.sprite = imageLambda;
                break;
            default:
            case "putain":
                titre.SetText("La Catain");
                fond.sprite = imagePutain;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
