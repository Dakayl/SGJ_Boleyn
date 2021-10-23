
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceCard", menuName = "ScriptableObjects/ChoiceCard", order = 1)]

public class ChoiceCard:ScriptableObject
{
    public string title;
    public string description;
    public string textChoiceLeft;
    public string textChoiceRight;
    public ChoiceCard addNextWhenSwipeLeft;
    public ChoiceCard addNextWhenSwipeRight;
    public ChoiceCard addLastWhenSwipeLeft;
    public ChoiceCard addLastWhenSwipeRight;
    public AudioClip playWhenDiscovered;
    public AudioClip playWhenSwipedLeft;
    public AudioClip playWhenSwipedRight;

}
