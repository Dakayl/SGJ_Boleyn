using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;
public class CardUI:MonoBehaviour
{
    private TextMeshProUGUI choiceLeft;
    private TextMeshProUGUI choiceRight;
    private TextMeshProUGUI titleEra;
    private TextMeshProUGUI dateEra;
    private TextMeshProUGUI description;
    private TextMeshProUGUI title;
    private Canvas canvas;
    private Canvas cardCanvas;
    private ChoiceCard currentCard;
    [SerializeField] private Image henryLevel;
    [SerializeField] private Image peopleLevel;
    [SerializeField] private Image religionLevel;
    [SerializeField] private Image background;
    [SerializeField] private Image cardBack;
    [SerializeField] private Image deckBack;
    [SerializeField] private Image character;
    private Image backChoiceLeft;
    private Image backChoiceRight;
    private float maxValueHenry = 30;
    private float maxValuePeople = 30;
    private float maxValueReligion = 50;
    [SerializeField] private float beforeTitleFade = 2.0f;
    [SerializeField] private float titleFadeDuration = 4.0f;

    protected void Awake()
    {
        canvas = transform.Find("Canvas").GetComponent<Canvas>();
        choiceLeft = canvas.transform.Find("choiceLeft").GetComponent<TextMeshProUGUI>();
        choiceRight = canvas.transform.Find("choiceRight").GetComponent<TextMeshProUGUI>();
        backChoiceLeft = canvas.transform.Find("backChoiceLeft").GetComponent<Image>();
        backChoiceRight = canvas.transform.Find("backChoiceRight").GetComponent<Image>();
        dateEra = canvas.transform.Find("dateEra").GetComponent<TextMeshProUGUI>();
        titleEra = canvas.transform.Find("titleEra").GetComponent<TextMeshProUGUI>();
        cardCanvas = canvas.transform.Find("CardCanvas").GetComponent<Canvas>();
        description = cardCanvas.transform.Find("description").GetComponent<TextMeshProUGUI>();
        title = cardCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
        StopSwipe(false, false);
    }

    public void setMaxValue(float maxHenry, float maxPeople, float maxReligion ){
        maxValueHenry = maxHenry;
        maxValuePeople = maxPeople;
        maxValueReligion = maxReligion;
    }

    protected void Start(){
        CardDragDrop.OnDragCard += StartSwipe;
        CardDragDrop.OnDropCard += StopSwipe;
        Color tint = new Color32(0,90,135,100);
        henryLevel.color = tint;
        peopleLevel.color = tint;
        religionLevel.color = tint;
    }

    public void setCard(ChoiceCard card) {
        Debug.Log("New Card " + card.title);
        currentCard = card;
        title.SetText("..."); 
        choiceLeft.SetText("..."); 
        choiceRight.SetText("...");
        description.SetText("..."); 

        if(currentCard.textChoiceLeft != null) {
           choiceLeft.SetText(currentCard.textChoiceLeft); 
        } 
        if(currentCard.textChoiceRight != null) {
           choiceRight.SetText(currentCard.textChoiceRight); 
        }
        if(currentCard.description != null) {
           description.SetText(currentCard.description); 
        }
        if(currentCard.title != null) {
           title.SetText(currentCard.title); 
        }
        if(currentCard.characterImage != null) {
            character.enabled = true;
            setCharacter(currentCard.characterImage); 
        } else {
            character.enabled = false;
        }
    }

    protected void StartSwipe(bool isMovingLeft, bool isSwiping){
        if(isMovingLeft){
            StartSwipeLeft();
        } else {
            StartSwipeRight();
        }
    }

    public void setEra(Era currentEra) {
        if(currentEra.background != null){
            setBackground(currentEra.background);
        }
        if(currentEra.cardBack != null){
            setCardBackground(currentEra.cardBack);
        }
        if(currentEra.deckBack != null){
            setDeckBackground(currentEra.deckBack);
        }
        if(currentEra.date > 0){
            dateEra.SetText( currentEra.date.ToString() );
            dateEra.enabled = true;
        }
        if(currentEra.nameAct != null){
            titleEra.SetText( currentEra.nameAct );
            titleEra.enabled = true;
        }
        if(dateEra.enabled || titleEra.enabled) {
            Invoke("goFading", beforeTitleFade);
            
        }
    }

    public void goFading() {
        StartCoroutine(this.StartFade());
    }

    public IEnumerator StartFade()
    {
        float currentTime = 0;
        while (currentTime < titleFadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0 , currentTime / titleFadeDuration);
            titleEra.alpha = alpha;
            dateEra.alpha = alpha;
            yield return null;
        }
        titleEra.enabled = false;
        dateEra.enabled = false;
        yield break;
    }

    public void setBackground(Sprite newBackground) {
        background.sprite = newBackground;
    }

    public void setCardBackground(Sprite newCard) {
        cardBack.sprite = newCard;
    }
    public void setDeckBackground(Sprite newCard) {
        deckBack.sprite = newCard;
    }

    public void setCharacter(Sprite newCharacter) {
        character.sprite = newCharacter;
    }

    protected void StartSwipeLeft(){
        choiceLeft.enabled = true;
        choiceRight.enabled = false;
         backChoiceLeft.enabled = true;
        backChoiceRight.enabled = false;
    }

    protected void StartSwipeRight(){
        choiceRight.enabled = true;
        choiceLeft.enabled = false;
        backChoiceRight.enabled = true;
        backChoiceLeft.enabled = false;
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        choiceRight.enabled = false;
        choiceLeft.enabled = false;
        backChoiceLeft.enabled = false;
        backChoiceRight.enabled = false;
    }

    public void setHeightHenryLevel( float value) {
       float currentHeight = 5 + Mathf.Lerp(0, 160, value/maxValueHenry);
       henryLevel.rectTransform.sizeDelta = new Vector2(40, currentHeight);
    }

    public void setHeightPeopleLevel( float value) {
        float currentHeight = 5 + Mathf.Lerp(0, 160, value/maxValueReligion);
        peopleLevel.rectTransform.sizeDelta = new Vector2(40, currentHeight);
    }

    public void setHeightReligionLevel( float value) {
        float currentHeight = 5 + Mathf.Lerp(0, 160, value/maxValuePeople);
        religionLevel.rectTransform.sizeDelta = new Vector2(40, currentHeight);
    }
           
       
}
