
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceCard", menuName = "ScriptableObjects/ChoiceCard", order = 1)]

public class ChoiceCard:ScriptableObject
{
    public string title;
    public string description;
    public Sprite characterImage;
    public string textChoiceLeft;
    public string textChoiceRight;
    public AudioClip playWhenDiscovered;

    //Gestion des cartes - Gauche
    public ChoiceCard addNextWhenSwipeLeft;
    public ChoiceCard addLaterWhenSwipeLeft;
    public ChoiceCard addRandomWhenSwipeLeft;
    public ChoiceCard addLastWhenSwipeLeft;
    public AudioClip playWhenSwipedLeft;
    public Era changeEraWhenSwipeLeft;

    //Gestion des Jauges - Gauche
    [Range(-100, 100)] public int addToHenryWhenSwipeLeft;
    [Range(-100, 100)] public int addToReligionWhenSwipeLeft;
    [Range(-100, 100)] public int addToPeopleWhenSwipeLeft;

    //Gestion des cartes - Droite
    public ChoiceCard addNextWhenSwipeRight;
    public ChoiceCard addLaterWhenSwipeRight;
    public ChoiceCard addRandomWhenSwipeRight;
    public ChoiceCard addLastWhenSwipeRight;
    public AudioClip playWhenSwipedRight;
    public Era changeEraWhenSwipeRight;


    //Gestion des Jauges - Droite
    [Range(-100, 100)] public int addToHenryWhenSwipeRight;
    [Range(-100, 100)] public int addToReligionWhenSwipeRight;
    [Range(-100, 100)] public int addToPeopleWhenSwipeRight;
}
