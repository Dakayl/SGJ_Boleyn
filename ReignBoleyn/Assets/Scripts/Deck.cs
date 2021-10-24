using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Deck:MonoBehaviour
{
    private List<ChoiceCard> currentDeck;
    protected void Start(){
    }
    protected void Awake(){
        currentDeck = new List<ChoiceCard>();
    }

    protected void shuffleDeck(){
        for (int i = 0; i < currentDeck.Count; i++) {
            ChoiceCard temp = currentDeck[i];
            int randomIndex = Random.Range(i, currentDeck.Count);
            currentDeck[i] = currentDeck[randomIndex];
            currentDeck[randomIndex] = temp;
        }
    }

    public void changeDeck(List<ChoiceCard> newDeck, bool doShuffle) {
 
       currentDeck = new List<ChoiceCard>(newDeck);
       if(doShuffle) {
           shuffleDeck();
       }
    }
   
    //Ajouter une carte à la fin
    public void addCard(ChoiceCard card) {
       currentDeck.Add(card);
    }

    //Ajouter une carte au début
    public void addCardAtFirst(ChoiceCard card) {
        currentDeck.Insert(0, card);
    }

    //Ajouter une carte aléatoirement
    public void addCardAtRandom(ChoiceCard card) {
        int addCardAtRandom = Random.Range(0, currentDeck.Count);
        currentDeck.Insert(addCardAtRandom, card);
    }

    //Prendre la première carte
    public ChoiceCard getFirstCard() {
        if(currentDeck.Count < 1) {
            return null;
        }
        ChoiceCard card = currentDeck[0];
        currentDeck.Remove(card);
        return card;
    }

    // Ajouter une carte entre 2 et 3
    public void addCardbtwn23(ChoiceCard card) {
        if(currentDeck.Count > 2) {
            int AddCardbtwn23 = Random.Range(1, 2);
            currentDeck.Insert(AddCardbtwn23, card);
        } else {
            addCard(card);
        }
        
    }
}
