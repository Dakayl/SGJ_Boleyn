
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDragDrop:MonoBehaviour, IPointerUpHandler, IPointerDownHandler 
{
    private bool isDragged = false;
    public delegate void DragHandler(bool isMovingLeft, bool isSwiping);
    public static event DragHandler OnDragCard;
    public delegate void DropHandler(bool isMovingLeft, bool isSwiping);
    public static event DropHandler OnDropCard;
    private Vector3 startMousePosition;
    private Vector3 startCardPosition;
    private Quaternion startCardRotation;
    private bool isMovingLeft;
    private bool isSwiping;
    public GameObject eventPrefab;

    public void Start(){

    }

    public void Awake(){
        startCardPosition = transform.position;
        startCardRotation = transform.rotation;
    }

    public void OnPointerDown (PointerEventData eventData) 
    {
       Debug.Log("Clicking Card");
       startMousePosition = Input.mousePosition;
       isDragged = true;
    }
 
    public void OnPointerUp (PointerEventData eventData) 
    {
        Debug.Log("Releasing Card");
        if(OnDropCard != null) {
            OnDropCard(isMovingLeft, isSwiping);
        }
        isDragged = false;
        transform.position = startCardPosition;
        transform.rotation =  startCardRotation;
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
       
}
