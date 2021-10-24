
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
   public ChoiceCard endingHenriLovesYouAct2;
   public ChoiceCard endingHenriDoesntLoveYouAct2;
   public List<ChoiceCard> subDeckTourAct3;
   public List<ChoiceCard> subDeckProcesAct3;
   public List<ChoiceCard> subDeckVerdictAct3;
   public List<ChoiceCard> subDeckExecutionAct3;
   public List<ChoiceCard> subDeckFinalAct3;
   public Color32 titleColor;

}
