using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour{
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI MaxXpText;
    public Slider XpBar;

    public AnimationCurve XpRequaird;
    public AnimationCurve XpModifier;

    int level;
    int xp;
    float time;

    int xpMultiplier;
    int xpNeeded;

    void Start(){
        xpNeeded = (int)XpRequaird.Evaluate(level);
        xpMultiplier = (int)XpModifier.Evaluate(level);
        XpBar.maxValue = xpNeeded;
        MaxXpText.text = xpNeeded.ToString();
    }

    void Update(){
        time += Time.deltaTime;                                   
        if(time < 1) return;
        time = 0;    

        var orbExp = Random.Range(1,5); 
    
        AddExp(orbExp);                      
    }

    void AddExp(int amount){
        xp += amount * xpMultiplier;
        if(xp >= xpNeeded){
            LevelUp();
        }
        XpBar.value = xp;   
    }

    void LevelUp(){
        xp -= xpNeeded;
        xpNeeded = (int)XpRequaird.Evaluate(level);
        xpMultiplier = (int)XpModifier.Evaluate(level);
        XpBar.maxValue = xpNeeded;
        level++;

        LevelText.text = level.ToString();          // Just for text
        MaxXpText.text = xpNeeded.ToString();       //

        // Somthing
    }
}
