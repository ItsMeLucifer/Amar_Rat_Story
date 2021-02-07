using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestChecker : MonoBehaviour
{
    public int foodMaximum = 3;
    public int skillPointPropability = 10;
    public GameObject userInterface;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.transform.tag == "Quest"){
            gameManager.GetComponent<GameManager>().AddFood(Random.Range(0,foodMaximum));
            if(Random.Range(0,skillPointPropability) == 5){
                gameManager.GetComponent<GameManager>().AddSkillPoints(1);
            }
            Destroy(col.transform.parent.gameObject);
        if(!GameObject.FindWithTag("Quest") && (userInterface.GetComponent<UI>().Food != userInterface.GetComponent<UI>().FoodNeeded)){
            GameObject.Find("Domy").GetComponent<QuestsScript>().SpawnQuests();
        }
        }
        
    }
}
