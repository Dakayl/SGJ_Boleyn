using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game:MonoBehaviour
{
    private ChoiceCard currentCard;
    [SerializeField] private Era currentEra;
    private Era nextEra;
    [SerializeField] private float levelHenry = 0;
    [SerializeField] private float levelPeople = 0;
    [SerializeField] private float levelReligion = 0;
    [SerializeField] private float maxValueHenry = 30;
    [SerializeField] private float maxValuePeople = 30;
    [SerializeField] private float maxValueReligion = 30;
    [SerializeField] private Deck deckMgt;
    [SerializeField] private CardUI cardInterfaceMgt;
    [SerializeField] private Audio audioMgt;
    [SerializeField] private float delayNewCard = 1.5f;
    
    protected void Awake(){
        
        CardDragDrop.OnDropCard += StopSwipe;
    }
    protected void Start(){
        cardInterfaceMgt.setMaxValue(maxValueHenry, maxValuePeople, maxValueReligion);
        cardInterfaceMgt.setHeightHenryLevel(levelHenry);
        cardInterfaceMgt.setHeightPeopleLevel(levelPeople);
        cardInterfaceMgt.setHeightReligionLevel(levelReligion);
        Invoke("beginGame", 0.1f);
    }

    protected void beginGame(){
        changeEra(currentEra);
        cardInterfaceMgt.prepateTitleFading();
        newCard();
        cardInterfaceMgt.ShowPanels();
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
        }
    }

    protected void changeEra(Era era){

        if(era == null) {
            return;
        }
        buildDeckAct3(era);    
        currentEra = era;
        if(currentEra.newDeck != null
        && currentEra.newDeck.Count > 0) {            
            deckMgt.changeDeck(currentEra.newDeck, currentEra.shuffleDeck);
            if(currentEra.addCardAt23 != null) {
                deckMgt.addCardbtwn23(currentEra.addCardAt23);
            }
        }
        if(currentEra.relatedMusic != null) {
           audioMgt.musicVolume = currentEra.volume;
           audioMgt.playMusic(currentEra.relatedMusic);
        }
        cardInterfaceMgt.setEra(currentEra);
    }

    protected void buildDeckAct3(Era era){
        List<ChoiceCard> newDeck = new List<ChoiceCard>();
        if(era.subDeckTourAct3 != null 
        && era.subDeckTourAct3.Count > 0) {
            List<ChoiceCard> tourAct3 = new List<ChoiceCard>(era.subDeckTourAct3);
            newDeck.Add(
                pickFrom(tourAct3)
            );
            newDeck.Add(
                pickFrom(tourAct3)
            );
            newDeck.Add(
                pickFrom(tourAct3)
            );
        }
        if(era.subDeckProcesAct3 != null 
        && era.subDeckProcesAct3.Count > 0) {
            List<ChoiceCard> procesAct3 = new List<ChoiceCard>(era.subDeckProcesAct3);
            newDeck.Add(
                pickFrom(procesAct3)
            );
           newDeck.Add(
                pickFrom(procesAct3)
            );
        }
        if(era.subDeckVerdictAct3 != null 
        && era.subDeckVerdictAct3.Count > 0) {
            newDeck.Add(
               era.subDeckVerdictAct3[0]
            );
        }
        if(era.subDeckExecutionAct3 != null 
        && era.subDeckExecutionAct3.Count > 0) {
            List<ChoiceCard> executionAct3 = new List<ChoiceCard>(era.subDeckExecutionAct3);
            newDeck.Add(
                pickFrom(executionAct3)
            );
            newDeck.Add(
                pickFrom(executionAct3)
            );
        }
        if(era.subDeckFinalAct3 != null 
        && era.subDeckExecutionAct3.Count > 0) {
            newDeck.Add(
               era.subDeckFinalAct3[0]
            );
        } 
        if(newDeck.Count > 5){
            era.newDeck = newDeck;
        }       
    }

    protected ChoiceCard pickFrom(List<ChoiceCard> deck) {
        int randomIndex = Random.Range(0, deck.Count);
        ChoiceCard card = deck[randomIndex];
        deck.Remove(card);
        return card;
    }

    protected void newCard() {
        if(currentCard != null
        && currentCard.act2SpecialCard) {
            if(levelHenry > 24) {
                currentCard = currentEra.endingHenriLovesYouAct2;
            } else {
                currentCard = currentEra.endingHenriDoesntLoveYouAct2;
            }
        } else {
            currentCard = deckMgt.getFirstCard();
        }
        
        if(currentCard == null && currentEra.isFinalEra) {
            Invoke("ending",1.1f);
        } 
        if(currentCard == null) {
            return;
        }
        cardInterfaceMgt.setCard(currentCard);
    }


    protected void playLeft() {     
        levelHenry += currentCard.addToHenryWhenSwipeLeft;
        levelPeople += currentCard.addToPeopleWhenSwipeLeft;
        levelReligion += currentCard.addToReligionWhenSwipeLeft;
        if(currentCard.playWhenSwipedLeft != null) {
            audioMgt.playEffect(currentCard.playWhenSwipedLeft);
        }
        if(currentCard.changeEraWhenSwipeLeft != null){
          goNext(currentCard.changeEraWhenSwipeLeft);
          return;
        }
        if(currentCard.addNextWhenSwipeLeft != null) {
            deckMgt.addCardAtFirst(currentCard.addNextWhenSwipeLeft);
        }
        if(currentCard.addLaterWhenSwipeLeft != null) {
            deckMgt.addCardbtwn23(currentCard.addLaterWhenSwipeLeft);
        }
        if(currentCard.addRandomWhenSwipeLeft != null) {
            deckMgt.addCardAtRandom(currentCard.addRandomWhenSwipeLeft);
        }
        if(currentCard.addLastWhenSwipeLeft != null) {
            deckMgt.addCard(currentCard.addLastWhenSwipeLeft);
        }       
        Invoke("newCard", delayNewCard);
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
        if(currentCard.playWhenSwipedRight != null) {
            audioMgt.playEffect(currentCard.playWhenSwipedRight);
        }
        if(currentCard.changeEraWhenSwipeRight != null){
          goNext(currentCard.changeEraWhenSwipeRight);
          return;
        }
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
       
        Invoke("newCard", delayNewCard);
    }

    protected void goNext(Era era){
        nextEra = era;
        Invoke("prepareNewEra", 1.0f);  
    }

    protected void prepareNewEra(){
        cardInterfaceMgt.prepareEra();
        Invoke("passToNewEra", 1.0f);
    }

    protected void passToNewEra(){
        
        changeEra(nextEra);
        nextEra = null;
        Invoke("newCard", delayNewCard);
    }

    protected void ending() {       
        /**
        Henri VIII	Religion	Peuple
        La fantasmée	25/30	25/30	25/30

        La mère	0/25	25/30	25/30
        La victime de cromwell	25/30	25/30	0/25
        La Reine	25/30	0/25	25/30

        La victime de cromwell	25/30	0/25	0/25
        La Sainte	0/25	25/30	0/25
        La généreuse	0/25	0/25	25/30
                    
       
        La lambda	10/25	10/25	10/25
        La putain	0/10	0/10	0/10
        **/
        if(levelReligion > 24 && levelPeople > 24 && levelHenry > 24) {
            GlobalParameters.ending = "fantasme";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }

        if(levelReligion > 24 && levelPeople > 24) {
            GlobalParameters.ending = "mere";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }
        if(levelReligion > 24 && levelHenry > 24) {
            GlobalParameters.ending = "victime";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }
        if(levelHenry > 24 && levelPeople > 24) {
             GlobalParameters.ending = "reine";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }

        if(levelHenry > 24) {
            GlobalParameters.ending = "victime";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }
        if(levelReligion > 24) {
            GlobalParameters.ending = "sainte";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }
        if(levelPeople > 24) {
            GlobalParameters.ending = "genereuse";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }

        if(levelPeople > 9 && levelReligion > 9 && levelHenry > 9 ) {
            GlobalParameters.ending = "lambda";
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            return;
        }
        GlobalParameters.ending = "putain";
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
        return;
        
        
    }
}