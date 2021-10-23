
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ChoicePanel : MonoBehaviour
{
    [SerializeField] private Sprite normalBackImage;
    [SerializeField] private Sprite biggerBackImage;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHenry;
    public TextMeshProUGUI textPeople;
    public TextMeshProUGUI textReligion;
    private Image religion;
    private Image henry;
    private Image people;
    private Image panel;
    private int religionLevel = 0;
    private int henryLevel = 0;
    private int peopleLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Image>();
        text = transform.Find("text").GetComponent<TextMeshProUGUI>();
        henry = transform.Find("henry").GetComponent<Image>();
        people = transform.Find("people").GetComponent<Image>();
        religion = transform.Find("religion").GetComponent<Image>();
        textHenry = transform.Find("textHenry").GetComponent<TextMeshProUGUI>();
        textPeople = transform.Find("textPeople").GetComponent<TextMeshProUGUI>();
        textReligion = transform.Find("textReligion").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string str){
        text.SetText(str);
    }

    public void showBigger(){
        panel.sprite = biggerBackImage;
        if(henryLevel != 0) {
            henry.enabled = true;
            textHenry.enabled = true;
        }
        if(peopleLevel != 0) {
            people.enabled = true;
            textPeople.enabled = true;
        }
        if(religionLevel != 0) {
            religion.enabled = true;
            textReligion.enabled = true;
        }
    }

    public void showSmaller(){
        panel.sprite = normalBackImage;
        henry.enabled = false;
        people.enabled = false;
        religion.enabled = false;
        textHenry.enabled = false;
        textReligion.enabled = false;
        textPeople.enabled = false;
    }
    public void setHenry(int level){
        henryLevel = level;
        textHenry.SetText(level.ToString());
    }
    public void setReligion(int level){
        religionLevel = level;
        textReligion.SetText(level.ToString());
    }
    
    public void setPeople(int level){
        peopleLevel = level;
        textPeople.SetText(level.ToString());
    }
    
}
