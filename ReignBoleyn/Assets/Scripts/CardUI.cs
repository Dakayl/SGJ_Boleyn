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

    protected void Start()
    {
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        choiceLeft = canvas.transform.Find("choiceLeft").gameObject.GetComponent<TextMeshProUGUI>();
        choiceRight = canvas.transform.Find("choiceRight").gameObject.GetComponent<TextMeshProUGUI>();

        cardCanvas = canvas.transform.Find("CardCanvas").GetComponent<Canvas>();
        description = cardCanvas.transform.Find("description").gameObject.GetComponent<TextMeshProUGUI>();
        title = cardCanvas.transform.Find("title").gameObject.GetComponent<TextMeshProUGUI>();

        choiceLeft.enabled = false;
        choiceRight.enabled = false;
    }

    protected void Awake(){
        CardDragDrop.OnDragCard += StartSwipe;
        CardDragDrop.OnDropCard += StopSwipe;
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
