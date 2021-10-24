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
    private Audio audioMgt;
    [SerializeField] private AudioClip relatedMusic;
    [Range(0, 1.0f)] public float volume = 1.0f;

    // Start is called before the first frame update
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
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        titre = canvas.transform.Find("Titre").GetComponent<TextMeshProUGUI>();
        description = canvas.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        fond = canvas.transform.Find("Fond").GetComponent<Image>();
        switch(GlobalParameters.ending){
            case "fantasme":
                titre.SetText("La Fantasmée");
                fond.sprite = imageFantasme;
                description.SetText("Cette fin n'est normalement pas accessible :)");
                break;
            case "mere":
                titre.SetText("La Mère");
                fond.sprite = imageMere;
                description.SetText("Quoi que vous ayez fait, c’est avant tout votre amour pour Élisabeth, votre seule enfant vivante, qui vous a guidée. Vous avez veillé sur elle, vous l’avez aimée de tout votre cœur, comme vous avez veillé sur le peuple. C’est cette image de mère aimante que le monde gardera de vous, et c’est, à peu de chose près, ainsi que vous a représentée la série <i>The Tudors</i> de Michael Hirst.");
                break;
            case "victime":
                titre.SetText("La Victime");
                fond.sprite = imageVictime;
                description.SetText("Le roi vous aimait tant, et vous auriez bien fini, un jour, par lui donner ce fils tant désiré ! Alors, qu’est-ce qui a pu mal se passer ? La réponse est simple : Cromwell, avec qui vous aviez pourtant travaillé afin de promouvoir la Réforme, a fini par vous percevoir comme un danger, et vous a fait éliminer. Ces accusations ridicules, fondées sur des mensonges, se sont retrouvées comme des vérités absolues devant les yeux du roi, qui n’a eu d’autre choix que d’ordonner votre procès. C’est en tout cas la version que défend, à peu de choses près, l’historien Eric Ives. Cependant, vous aurez votre revanche, quand Cromwell vous suivra quelques années plus tard sur l'échafaud.");
                break;
            case "reine":
                titre.SetText("La Reine");
                description.SetText("Avec un “R” majuscule. Si votre naissance ne laissait pas deviner ce que vous alliez devenir, vous vous êtes cependant comportée comme l’incarnation de la royauté. Aux côtés du roi, comme auprès du peuple, vous avez toujours fait preuve de générosité, d’amour et de grandeur. Si vous n’avez pas donné à la dynastie l’héritier tant désiré, et êtes peut-être morte pour cela, vous avez cependant offert à l’Angleterre sa plus grande reine, et Élisabeth, la dernière des Tudors, laissera un souvenir plus fort que n’importe lequel de ses prédécesseurs. C’est peut-être bien ainsi que vous décrit le film <i>Anne des mille jours</i>.");
                fond.sprite = imageReine;
                break;
            case "sainte":
                titre.SetText("La Sainte");
                fond.sprite = imageSainte;
                description.SetText("Votre foi, et votre soutien à la réforme, c'est vraiment cela que le monde retiendra de vous. Vous êtes la mère de celle qui installera définitivement la religion protestante en Angleterre. Tout au long de votre vie, aux côtés du roi, vous avez œuvré pour la diffusion de l’évangélisme, et protégé ceux qui croyaient comme vous, parfois au risque de votre propre sécurité. Pour les Anglais des siècles suivants, il n’y a aucun doute, vous êtes une sainte, et le théologien John Foxe ne manquera pas de raconter votre martyre dans son livre <i>Actes et monuments de l’Église.</i>");
                break;
            case "genereuse":
                titre.SetText("La Généreuse");
                fond.sprite = imageGenereuse;
                description.SetText("Le peuple vous aime, car vous avez fait beaucoup pour lui. Plus en tout cas que la reine précédente. Cela ne vous aura hélas pas sauvée d’un destin tragique, mais du moins resterez-vous dans les mémoires comme une reine généreuse.");
                break;
            case "lambda":
                titre.SetText("Juste une fille");
                fond.sprite = imageLambda;
                description.SetText("Finalement, votre malheur fut le résultat de fâcheux concours de circonstance. Vous étiez plutôt partie pour croquer la vie à pleine dents, vous amuser, mais le destin et le roi en auront décidé autrement. Vous étiez une jeune femme sans très grande ambition, ce qui était tout à fait votre droit, mais on vous a poussée vers une vie trop grande pour vous. La faute à pas de chance. C’est ainsi que vous apparaissez dans la comédie musicale <i>Six</i> de Lucy Moss et Toby Marlow.");
                break;
            default:
            case "putain":
                titre.SetText("La Catain");
                fond.sprite = imagePutain;
                description.SetText("Vous avez manipulé le roi pour qu’il vous épouse, et vous fasse monter sur le trône. Que ce soit par soif de pouvoir, ou pour élever votre famille, vous avez dans tous les cas joué un jeu malhonnête. Quand, enfin reine, vous avez non seulement refusé de donner un fils au roi, mais en plus vous l’avez odieusement trompé, vous avez alors au final bien mérité ce qui vous est arrivé, ou du moins avez vous subi un procès tout à fait juste et équitable. Vous êtes coupable, et c’est là ce qu’on retiendra de vous, une version à peu de choses près aujourd’hui défendue par l’historien G. W. Bernard, et assez bien illustrée dans l’œuvre <i>Deux sœurs pour un roi</i>, de Philippa Gregory.");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
