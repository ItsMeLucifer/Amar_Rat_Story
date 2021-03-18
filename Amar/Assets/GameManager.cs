using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int TIME_LIMIT = 120; //seconds
    // Start is called before the first frame update
    [SerializeField] private GameObject amar;

    public enum _STATS

    {
        food, 
        speed, 
        strength, 
        health,
        freeSkillPoints,
        foodNeeded
    }


    public Dictionary<_STATS, int> stats = new Dictionary<_STATS, int>();


    
    public static GameManager Instance;

    
    
    
    private int currentDay = 1;

    [SerializeField] private GameObject timerUI, timerEndUI;
    private Text timerUI_text;
    [SerializeField] private int dailyTimeDecrease = 10;// seconds
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }


    //mute music

    private void Update()
    {
        if(stats[_STATS.health] <= 0)
            LoadEndScene();
    }

    // Update is called once per frame
    private void OnEnable()
    {

        foreach (_STATS _stat in Enum.GetValues(typeof(_STATS)))
        {
            stats.Add(_stat,0);
        }

        stats[_STATS.food] = 0;
        stats[_STATS.health] = 50;
        stats[_STATS.speed] = 10;
        stats[_STATS.strength] = 10;
        stats[_STATS.freeSkillPoints] = 0;
        stats[_STATS.foodNeeded] = 10;
        if (SceneManager.GetActiveScene().name == "Knoxville")
        {
            
            timerUI_text = timerUI.GetComponent<Text>();

            IfExploring();
        }
        


    }

    private void UpdateTimerUI(int seconds)
    {
        int minutes = (int)(seconds/60);
        seconds -= minutes * 60;
        String _minutes, _seconds;
        _minutes = minutes.ToString();
        if (_minutes.Length == 1)
            _minutes = "0" + _minutes;
        _seconds = seconds.ToString();
        if (_seconds.Length == 1)
            _seconds = "0" + _seconds;
        timerUI_text.text = _minutes+":"+_seconds;
    }
    

    private IEnumerator levelCountdown(int waitTime)
    {
        while (waitTime-- > 0)
        {
            yield return new WaitForSeconds(1);
            UpdateTimerUI(waitTime);
            
        }

        UpdateTimerUI(0);
        TimerEnd();
    }

    IEnumerator TimerEndMessage()
    {
        timerEndUI.SetActive(true);
        yield return new WaitForSeconds(5);
        timerEndUI.SetActive(false);
        SetFood(GetFood()/2);
        LoadSzczurzyDom();
    }
    private Scene lastScene;

    public void LoadSzczurzyDom()
    {
        StopCoroutine(levelCountdown(0));

        SaveLastScene();
        SceneManager.LoadScene("Szczurzy_Dom");
        
    }
    

    public void LoadSewers()
    {
        StopCoroutine(levelCountdown(0));
        SaveLastScene();
        SetSzczurMovement(true);
        SceneManager.LoadScene("Kanaly");
    }

    public void LoadBossFight()
    {
        StopCoroutine(levelCountdown(0));

        // SetSzczurMovement(false);
        SceneManager.LoadScene("BossFight");
    }

    public void LoadKnoxville()
    {
        StopCoroutine(levelCountdown(0));
        timerUI_text = timerUI.GetComponent<Text>();
        IfExploring();
        SaveLastScene();
        SceneManager.LoadScene("Knoxville");
        stats[_STATS.food] = 0;
        SetSzczurMovement(true);
        
    }
    
    
    
    void SaveLastScene()
    {
        lastScene = SceneManager.GetActiveScene();
        
    }

    void SetSzczurMovement(bool state)
    {
        if (!state)
        {
            amar.GetComponent<WalkingScript>().enabled = false;
            amar.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        amar.GetComponent<WalkingScript>().enabled = true;

    }
    private void TimerEnd()
    {
        Debug.Log("Koniec czasu");
        SetSzczurMovement(false);
        StopCoroutine(levelCountdown(0));
        StartCoroutine(TimerEndMessage());
        

    }
    private void IfExploring()
    {
        var levelTimeLimit = TIME_LIMIT - ((currentDay -1)* dailyTimeDecrease);
        if (levelTimeLimit < 30)
            levelTimeLimit = 30;
        UpdateTimerUI(levelTimeLimit);
        StartCoroutine(levelCountdown(levelTimeLimit));
    }
    public void AddFood(int food){
        stats[_STATS.food] += food;
    }

    public void SetFood(int food)
    {
        stats[_STATS.food] = food;

    }
    public void AddSkillPoints(int skillPoints){
        stats[_STATS.freeSkillPoints] += skillPoints;
    }
    public void AddHealth(int health){
        stats[_STATS.health] += health;
    }
    public void AddSpeed(int speed){
        stats[_STATS.speed] += speed;
    }
    public void AddStrength(int strength){
        stats[_STATS.strength] += strength;
    }
    public int GetSkillPoints(){
        return stats[_STATS.freeSkillPoints];
    }
    public int GetHealth(){
        return stats[_STATS.health];
    }
    public int GetSpeed(){
        return stats[_STATS.speed];
    }
    public int GetStrength(){
        return stats[_STATS.strength];
    }
    public int GetFood(){
        return stats[_STATS.food];
    }
    public int GetFoodNeeded(){
        return stats[_STATS.foodNeeded];
    }
    public void Quit(){
        Application.Quit();
    }
    public void LoadEndScene(){
        SceneManager.LoadScene("GameOver");
    }
}