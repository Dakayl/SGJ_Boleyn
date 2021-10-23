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
   public void addCardAtEnd(ChoiceCard card) {
   }

   //Ajouter une carte aléatoirement
   public void addCardAtRandom(ChoiceCard card) {
   }

   //Prendre la première carte
   public ChoiceCard getFirstCard() {
       
   }


}
