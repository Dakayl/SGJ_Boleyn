
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ChoiceCard", menuName = "ScriptableObjects/Era", order = 2)]

public class Era:ScriptableObject
{
   public AudioClip relatedMusic;
   public int date;
   public string nameAct;
   public Sprite background;
   public Sprite cardBack;
   public Sprite deckBack;
   public List<ChoiceCard> newDeck;
   public bool shuffleDeck = true;
   public bool isFinal = false;

}
