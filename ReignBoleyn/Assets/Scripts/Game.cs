using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour
{
    private ChoiceCard currentCard;
    
    protected void Awake(){
        CardDragDrop.OnDropCard += StopSwipe;
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        if(isSwiping){
            if(isMovingLeft) {
                playLeft();
            } else {
                playRight();
            }
        }
    }

    protected void playLeft() {

    }

    protected void playRight() {
        
    }
}