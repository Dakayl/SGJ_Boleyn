using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour
{
    private ChoiceCard currentCard;
    private Era currentEra;
    private int levelHenry = 0;
    private int levelPeuple = 0;
    private int levelReligion = 0;
    [SerializeField] private Deck deckMgt;
    [SerializeField] private CardUI cardMgt;
    [SerializeField] private Audio audioMgt;
    [SerializeField] private float delayNewCard;
    protected void Awake(){
        CardDragDrop.OnDropCard += StopSwipe;
        newCard();
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        if(isSwiping){
            if(isMovingLeft) {
                playLeft();
            } else {
                playRight();
            }
            Invoke("newCard",delayNewCard);
        }
    }

    protected void changeEra(Era era){
        currentEra = era;
        if(era.relatedMusic != null) {
           audioMgt.playMusic(era.relatedMusic);
        }
        if(era.newDeck != null && era.newDeck.Count > 0) {
            deckMgt.changeDeck(era.newDeck);
        }
    }

    protected void newCard() {
        currentCard = deckMgt.getFirstCard();
        Debug.Log(currentCard);
        if(currentCard == null) {
            return;
        }
        if(currentCard.changeEraWhenDiscovered != null) {
            changeEra(currentCard.changeEraWhenDiscovered);
        }
        if(currentCard.playWhenDiscovered != null) {
            audioMgt.playEffect(currentCard.playWhenDiscovered);
        }
        cardMgt.setCard(currentCard);
    }

    protected void playLeft() {
        levelHenry += currentCard.addToHenryWhenSwipeLeft;
        levelPeuple += currentCard.addToPeopleWhenSwipeLeft;
        levelReligion += currentCard.addToReligionWhenSwipeLeft;
        if(currentCard.addNextWhenSwipeLeft != null) {
            deckMgt.addCardAtFirst(currentCard.addNextWhenSwipeLeft);
        }
        if(currentCard.addRandomWhenSwipeLeft != null) {
            deckMgt.addCardAtRandom(currentCard.addRandomWhenSwipeLeft);
        }
        if(currentCard.addLastWhenSwipeLeft != null) {
            deckMgt.addCard(currentCard.addLastWhenSwipeLeft);
        }
        if(currentCard.playWhenSwipedLeft != null) {
            audioMgt.playEffect(currentCard.playWhenSwipedLeft);
        }
    }

    protected void playRight() {
        levelHenry += currentCard.addToHenryWhenSwipeRight;
        levelPeuple += currentCard.addToPeopleWhenSwipeRight;
        levelReligion += currentCard.addToReligionWhenSwipeRight;
        if(currentCard.addNextWhenSwipeRight != null) {
            deckMgt.addCardAtFirst(currentCard.addNextWhenSwipeRight);
        }
        if(currentCard.addRandomWhenSwipeRight != null) {
            deckMgt.addCardAtRandom(currentCard.addRandomWhenSwipeRight);
        }
        if(currentCard.addLastWhenSwipeRight != null) {
            deckMgt.addCard(currentCard.addLastWhenSwipeRight);
        }
        if(currentCard.playWhenSwipedRight != null) {
            audioMgt.playEffect(currentCard.playWhenSwipedRight);
        }
    }
}