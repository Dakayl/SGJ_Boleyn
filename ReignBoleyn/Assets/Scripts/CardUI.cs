using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using TMPro;
public class CardUI:MonoBehaviour
{
    private TextMeshProUGUI choiceLeft;
    private TextMeshProUGUI choiceRight;
    private TextMeshProUGUI description;
    private TextMeshProUGUI title;
    private Canvas canvas;
    private Canvas cardCanvas;
    private ChoiceCard currentCard;

    protected void Awake()
    {
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        choiceLeft = canvas.transform.Find("choiceLeft").GetComponent<TextMeshProUGUI>();
        choiceRight = canvas.transform.Find("choiceRight").GetComponent<TextMeshProUGUI>();
        Debug.Log(choiceLeft);
        Debug.Log(choiceRight);

        cardCanvas = canvas.transform.Find("CardCanvas").GetComponent<Canvas>();
        description = cardCanvas.transform.Find("description").GetComponent<TextMeshProUGUI>();
        title = cardCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
 
        choiceLeft.enabled = false;
        choiceRight.enabled = false;
    }

    protected void Start(){
        CardDragDrop.OnDragCard += StartSwipe;
        CardDragDrop.OnDropCard += StopSwipe;
    }

    public void setCard(ChoiceCard card) {
        Debug.Log(card);
        currentCard = card;
        title.SetText("..."); 
        choiceLeft.SetText("..."); 
        choiceRight.SetText("...");
        description.SetText("..."); 

        if(currentCard.textChoiceLeft != null) {
           choiceLeft.SetText(currentCard.textChoiceLeft); 
        } 
        if(currentCard.textChoiceRight != null) {
           choiceRight.SetText(currentCard.textChoiceRight); 
        }
        if(currentCard.description != null) {
           description.SetText(currentCard.description); 
        }
        if(currentCard.title != null) {
           title.SetText(currentCard.title); 
        }
    }

    protected void StartSwipe(bool isMovingLeft, bool isSwiping){
        if(isMovingLeft){
            StartSwipeLeft();
        } else {
            StartSwipeRight();
        }
    }

    protected void StartSwipeLeft(){
        choiceLeft.enabled = true;
        choiceRight.enabled = false;
    }

    protected void StartSwipeRight(){
        choiceRight.enabled = true;
        choiceLeft.enabled = false;
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        choiceRight.enabled = false;
        choiceLeft.enabled = false;
    }
           
       
}
