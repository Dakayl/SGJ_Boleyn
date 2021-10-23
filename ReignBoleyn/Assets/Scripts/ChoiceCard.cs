
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceCard", menuName = "ScriptableObjects/ChoiceCard", order = 1)]

public class ChoiceCard:ScriptableObject
{
    public string title;
    public string description;
    public string textChoiceLeft;
    public string textChoiceRight;
    public Era changeEraWhenDiscovered;
    public AudioClip playWhenDiscovered;

    //Gestion des cartes - Gauche
    public ChoiceCard addNextWhenSwipeLeft;
    public ChoiceCard addLittleLatersWhenSwipeLeft;
    public ChoiceCard addRandomWhenSwipeLeft;
    public ChoiceCard addLastWhenSwipeLeft;
    public AudioClip playWhenSwipedLeft;

    //Gestion des Jauges - Gauche
    [Range(-100, 100)] public int addToHenryWhenSwipeLeft;
    [Range(-100, 100)] public int addToReligionWhenSwipeLeft;
    [Range(-100, 100)] public int addToPeopleWhenSwipeLeft;

    //Gestion des cartes - Droite
    public ChoiceCard addNextWhenSwipeRight;
    public ChoiceCard addLittleLatersWhenSwipeRight;
    public ChoiceCard addRandomWhenSwipeRight;
    public ChoiceCard addLastWhenSwipeRight;
    public AudioClip playWhenSwipedRight;

    //Gestion des Jauges - Droite
    [Range(-100, 100)] public int addToHenryWhenSwipeRight;
    [Range(-100, 100)] public int addToReligionWhenSwipeRight;
    [Range(-100, 100)] public int addToPeopleWhenSwipeRight;
}
