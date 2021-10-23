
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardDragDrop:MonoBehaviour, IPointerUpHandler, IPointerDownHandler 
{
    private bool isDragged = false;
    private bool isDraggable = false;
    public delegate void DragHandler(bool isMovingLeft, bool isSwiping);
    public static event DragHandler OnDragCard;
    public delegate void DropHandler(bool isMovingLeft, bool isSwiping);
    public static event DropHandler OnDropCard;
    private Vector3 startMousePosition;
    private Vector3 startCardPosition;
    private Quaternion startCardRotation;
    private bool isMovingLeft;
    private bool isSwiping;
    [SerializeField] private float cardFadeDuration = 2.0f;
    [SerializeField] private Image cardBack;
    [SerializeField] private Image character;
    private Color32 cleanColor = new Color32(255,255,255,255);
    private Color32 blackColor = new Color32(0,0,0,255);
    private Color32 emptyColor = new Color32(0,0,0,0);
    private TextMeshProUGUI description;
    private TextMeshProUGUI title;
    public void Start(){

    }

    public void Awake(){
        startCardPosition = transform.position;
        startCardRotation = transform.rotation;
        description = transform.Find("description").GetComponent<TextMeshProUGUI>();
        title = transform.Find("title").GetComponent<TextMeshProUGUI>();
        isDraggable = true;
    }

    public void OnPointerDown (PointerEventData eventData) 
    {
       if(!isDraggable) {
            return;
       }
       startMousePosition = Input.mousePosition;
       isDragged = true;
    }
 
    public void OnPointerUp (PointerEventData eventData) 
    {
        if(!isDragged) {
            return;
        }        
        if(OnDropCard != null) {
            OnDropCard(isMovingLeft, isSwiping);
        }
        if(isSwiping) {
            StartCoroutine(this.CardFade(isMovingLeft));
        } else {
            transform.position = startCardPosition;
            transform.rotation =  startCardRotation;
        }
        isDragged = false;
        
    }

    public void reset() {
        transform.position = startCardPosition;
        transform.rotation =  startCardRotation;
        cardBack.color = cleanColor;
        character.color = cleanColor;
        description.color = blackColor;
        title.color = blackColor;
        cardBack.enabled = true;
        character.enabled = false;
        description.enabled = true;
        title.enabled = true;     
        isDraggable = true;
    }

    void Update()
    {
        if (isDragged)
        {
            float x = Input.mousePosition.x - startMousePosition.x;
            isMovingLeft = (x < 0);
            isSwiping = Mathf.Abs(x) > 190;
            if(x > 200) {
                x = 200;
            }
            if(x <- 200) {
                x =- 200;
            }
            Vector3 distance = new Vector3(x, 0, 0);
            transform.position = startCardPosition + distance;

            float angle = Mathf.Lerp(0, 50, Mathf.Abs(distance.x)/200);
            if(distance.x <0) {
                angle = - angle;
            }
            transform.rotation =  startCardRotation * Quaternion.Euler(0, 0, - angle);
            if(OnDragCard != null) {
                OnDragCard(isMovingLeft, isSwiping);
            }
            
        }    
    }

     public IEnumerator CardFade(bool isLeft)
    {
        float currentTime = 0;
        isDraggable = false;
        Vector3 startPosition = transform.position;
        Vector3 endPosition;
        if(isLeft){
            endPosition = startPosition - new Vector3(400, 200, 0);
        } else {
            endPosition = startPosition - new Vector3(-400, 200, 0);
        }
        while (currentTime < cardFadeDuration)
        {
            currentTime += Time.deltaTime;
            float angle = Mathf.Lerp(51, 120, currentTime / cardFadeDuration);
            if(isLeft) {
                angle = - angle;
            }
            Color32 color = Color32.Lerp(cleanColor, emptyColor , currentTime / cardFadeDuration);
            Color32 textColor = Color32.Lerp(blackColor, emptyColor , currentTime / cardFadeDuration);
            Vector3 position = Vector3.Lerp(startPosition, endPosition , currentTime / cardFadeDuration);
            description.color = textColor;
            title.color = textColor;
            transform.position = position;
            cardBack.color = color;
            character.color = color;
            transform.rotation =  startCardRotation * Quaternion.Euler(0, 0, - angle);
            yield return null;
        }
        description.enabled = false;
        title.enabled = false;
        character.enabled = false;
        cardBack.enabled = false;
        Invoke("reset", 0.5f);
        yield break;
    }

       
}
