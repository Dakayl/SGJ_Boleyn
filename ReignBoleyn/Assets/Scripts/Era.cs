
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ChoiceCard", menuName = "ScriptableObjects/Era", order = 2)]

public class Era:ScriptableObject
{
   public AudioClip relatedMusic;
   public int Date;
   public string nameAct;
   public Sprite background;
   public List<ChoiceCard> newDeck;

}
