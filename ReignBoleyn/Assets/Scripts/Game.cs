using UnityEngine;
using System.Collections;

public class Game:MonoBehaviour
{
    private ChoiceCard currentCard;
    [SerializeField] private Era currentEra;
    [SerializeField] private float levelHenry = 0;
    [SerializeField] private float levelPeople = 0;
    [SerializeField] private float levelReligion = 0;
    [SerializeField] private float maxValueHenry = 30;
    [SerializeField] private float maxValuePeople = 30;
    [SerializeField] private float maxValueReligion = 30;
    [SerializeField] private Deck deckMgt;
    [SerializeField] private CardUI cardInterfaceMgt;
    [SerializeField] private Audio audioMgt;
    [SerializeField] private float delayNewCard;

    
    protected void Awake(){
        
        CardDragDrop.OnDropCard += StopSwipe;
    }
    protected void Start(){
        cardInterfaceMgt.setMaxValue(maxValueHenry, maxValuePeople, maxValueReligion);
        Invoke("getEra", 0.1f);
        cardInterfaceMgt.setHeightHenryLevel(levelHenry);
        cardInterfaceMgt.setHeightPeopleLevel(levelPeople);
        cardInterfaceMgt.setHeightReligionLevel(levelReligion);
    }

    protected void getEra(){
        changeEra(currentEra);
        newCard();
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        if(isSwiping){
            if(currentCard == null) {
                return;
            }   
            if(isMovingLeft) {
                playLeft();
            } else {
                playRight();
            }
            fixLevels();
            Invoke("newCard",delayNewCard);
        }
    }

    protected void changeEra(Era era){
        if(era == null) {
            return;
        }
        currentEra = era;      
        if(currentEra.newDeck != null
        && currentEra.newDeck.Count > 0) {            
            deckMgt.changeDeck(currentEra.newDeck, currentEra.shuffleDeck);
        }
        if(currentEra.relatedMusic != null) {
           audioMgt.playMusic(currentEra.relatedMusic);
        }
        
        cardInterfaceMgt.setEra(currentEra);
    }

    protected void newCard() {
    
        currentCard = deckMgt.getFirstCard();
        if(currentCard == null) {
            return;
        } 
        if(currentCard.playWhenDiscovered != null) {
            audioMgt.playEffect(currentCard.playWhenDiscovered);
        }
     

        cardInterfaceMgt.setCard(currentCard);
    }

    protected void playLeft() {     
        levelHenry += currentCard.addToHenryWhenSwipeLeft;
        levelPeople += currentCard.addToPeopleWhenSwipeLeft;
        levelReligion += currentCard.addToReligionWhenSwipeLeft;
        if(currentCard.addNextWhenSwipeLeft != null) {
            deckMgt.addCardAtFirst(currentCard.addNextWhenSwipeLeft);
        }
        if(currentCard.addLaterWhenSwipeLeft != null) {
             deckMgt.addCardbtwn23(currentCard.addNextWhenSwipeLeft);
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

    protected void fixLevels(){
        if(levelHenry < 0) levelHenry = 0;
        if(levelPeople < 0) levelPeople = 0;
        if(levelReligion < 0) levelReligion = 0;
        if(levelHenry > maxValueHenry) levelHenry = maxValueHenry;
        if(levelPeople > maxValuePeople) levelPeople = maxValuePeople;
        if(levelReligion > maxValueReligion) levelReligion = maxValueReligion;

        cardInterfaceMgt.setHeightHenryLevel(levelHenry);
        cardInterfaceMgt.setHeightPeopleLevel(levelPeople);
        cardInterfaceMgt.setHeightReligionLevel(levelReligion);
    }

    protected void playRight() {
        levelHenry += currentCard.addToHenryWhenSwipeRight;
        levelPeople += currentCard.addToPeopleWhenSwipeRight;
        levelReligion += currentCard.addToReligionWhenSwipeRight;
        if(currentCard.addNextWhenSwipeRight != null) {
            deckMgt.addCardAtFirst(currentCard.addNextWhenSwipeRight);
        }
        if(currentCard.addLaterWhenSwipeRight != null) {
             deckMgt.addCardbtwn23(currentCard.addLaterWhenSwipeRight);
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