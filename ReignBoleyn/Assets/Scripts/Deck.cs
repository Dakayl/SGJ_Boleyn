using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Deck:MonoBehaviour
{
    [SerializeField] private List<ChoiceCard> currentDeck;
   
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
       ChoiceCard card = currentDeck[0];
       currentDeck.Remove(card);
       return card;
       
   }
}
