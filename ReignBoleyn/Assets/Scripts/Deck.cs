using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck:MonoBehaviour
{
    [SerializeField] private List<ChoiceCard> deck;

    public void add(ChoiceCard newCard) {
        deck.Add(newCard);
    }

    public ChoiceCard getFirst() {
        return deck[0];
    }
}