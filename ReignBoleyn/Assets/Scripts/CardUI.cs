using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;
public class CardUI:MonoBehaviour
{
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
    [SerializeField] private ChoicePanel leftPanel;
    [SerializeField] private ChoicePanel rightPanel;
    private float maxValueHenry = 30;
    private float maxValuePeople = 30;
    private float maxValueReligion = 50;
    [SerializeField] private float beforeTitleFade = 1.5f;
    [SerializeField] private float titleFadeDuration = 4.0f;
    private Color32 cleanColor = new Color32(255,255,255,255);
    private Color32 blackColor = new Color32(0,0,0,255);
    private Color32 emptyColor = new Color32(0,0,0,0);
    [SerializeField] private float bgFadeDuration = 0.9f;
    private bool hasDisabledBg = false;
    [SerializeField] private AudioClip cardSound;
    private Audio audioMgt;


    protected void Awake()
    {
        canvas = transform.Find("Canvas").GetComponent<Canvas>();

        titleEra = canvas.transform.Find("titleEra").GetComponent<TextMeshProUGUI>();
        dateEra = canvas.transform.Find("dateEra").GetComponent<TextMeshProUGUI>();
        cardCanvas = canvas.transform.Find("CardCanvas").GetComponent<Canvas>();
        description = cardCanvas.transform.Find("description").GetComponent<TextMeshProUGUI>();
        title = cardCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
        audioMgt = GlobalParameters.getAudio();
        if(audioMgt == null){
            audioMgt = gameObject.AddComponent(typeof(Audio)) as Audio;
            GlobalParameters.setAudio(audioMgt);
        }
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
        CardDragDrop.OnReadyToAct += ShowPanels;
        Color tint = new Color32(0,90,135,100);
        henryLevel.color = tint;
        peopleLevel.color = tint;
        religionLevel.color = tint;
    }

    public void setCard(ChoiceCard card) {
        currentCard = card;
        
    }

    public void ShowPanels(){
        audioMgt.playEffect(cardSound);
        resetPanels();        
        resetSituation();     
    }
    
   

    protected void playDiscoverSound(){
        if(currentCard.playWhenDiscovered != null) {
            audioMgt.playEffect(currentCard.playWhenDiscovered);
        }
    }

    public void resetSituation() {
        if(currentCard.textChoiceLeft != null) {
           leftPanel.SetText(currentCard.textChoiceLeft); 
        } 
        if(currentCard.textChoiceRight != null) {
           rightPanel.SetText(currentCard.textChoiceRight); 
        }
        if(currentCard.description != null) {
           description.SetText(currentCard.description); 
        }
        if(currentCard.title != null) {
           title.SetText(currentCard.title); 
        }
        if(currentCard.characterImage != null) {          
            setCharacter(currentCard.characterImage); 
        }       
        leftPanel.setHenry(currentCard.addToHenryWhenSwipeLeft);
        leftPanel.setPeople(currentCard.addToPeopleWhenSwipeLeft);
        leftPanel.setReligion(currentCard.addToReligionWhenSwipeLeft);
        rightPanel.setHenry(currentCard.addToHenryWhenSwipeRight);
        rightPanel.setPeople(currentCard.addToPeopleWhenSwipeRight);
        rightPanel.setReligion(currentCard.addToReligionWhenSwipeRight);
    }

     protected void resetPanels(){
        rightPanel.forceSmaller();
        leftPanel.forceSmaller();
        rightPanel.renable();
        leftPanel.renable();
    }

    protected void StartSwipe(bool isMovingLeft, bool isSwiping){
        if(isMovingLeft){
            rightPanel.showSmaller();
        } else {
            leftPanel.showSmaller();
        }
        if(isSwiping) {
            if(isMovingLeft) {
                leftPanel.showBigger();  
            } else {
                rightPanel.showBigger();
            }
            
        }
    }
    public void prepareEra() {
        dateEra.enabled = false;
        titleEra.enabled = false;
        deckBack.enabled = false;
        rightPanel.enabled = false;  
        rightPanel.fullDisable();
        leftPanel.enabled = false; 
        leftPanel.fullDisable();
        hasDisabledBg = true;
        StartCoroutine(this.StartFadeBg());
    }

    public void setEra(Era currentEra) {
        
        if(currentEra.background != null){
            setBackground(currentEra.background);
        }
        if(hasDisabledBg) {
            StartCoroutine(this.EndFadeBg());
        }
    
        if(currentEra.cardBack != null){
            setCardBackground(currentEra.cardBack);
        }
        if(currentEra.deckBack != null){
            setDeckBackground(currentEra.deckBack);
        }
        if(currentEra.date > 0){
            dateEra.SetText( currentEra.date.ToString() );
            dateEra.color = currentEra.titleColor;
        }
        if(currentEra.nameAct != null){
            titleEra.SetText( currentEra.nameAct );
            titleEra.color = currentEra.titleColor;
        }
    }

    public void goTitleFading() {
        StartCoroutine(this.StartFadeTitle());
    }

    public IEnumerator StartFadeTitle()
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

     public void prepateTitleFading(){
        titleEra.alpha = 1.0f;
        dateEra.alpha = 1.0f;
        Invoke("goTitleFading", beforeTitleFade); 
    }

    public IEnumerator StartFadeBg()
    {
        float currentTime = 0;
        while (currentTime < bgFadeDuration)
        {
            currentTime += Time.deltaTime;
            Color32 color = Color32.Lerp(cleanColor, emptyColor , currentTime /  bgFadeDuration);
            background.color = color;
            yield return null;
        }
        titleEra.enabled = false;
        dateEra.enabled = false;
        yield break;
    }

    public IEnumerator EndFadeBg()
    {
        float currentTime = 0;
        while (currentTime < bgFadeDuration)
        {
            currentTime += Time.deltaTime;
            Color32 color = Color32.Lerp(emptyColor, cleanColor , currentTime /  bgFadeDuration);
            background.color = color;
            yield return null;
        }
        
        deckBack.enabled = true;
        titleEra.enabled = true;
        dateEra.enabled = true;
        resetPanels();
        prepateTitleFading();
        yield break;
    }

    public void setBackground(Sprite newBackground) {
        background.sprite = newBackground;
    }

    public void setCardBackground(Sprite newCardBack) {
        cardBack.sprite = newCardBack;
        
    }
    public void setDeckBackground(Sprite newDeckBack) {
        deckBack.sprite = newDeckBack;
    }

    public void setCharacter(Sprite newCharacter) {
        character.sprite = newCharacter;
    }

    protected void StopSwipe(bool isMovingLeft, bool isSwiping){
        if(isSwiping){
            if(isMovingLeft) {
                rightPanel.enabled = false;  
            } else {
                leftPanel.enabled = false;
            }
            
        }
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
