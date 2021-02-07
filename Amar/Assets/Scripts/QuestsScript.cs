using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsScript : MonoBehaviour
{
    List<Vector2> positions = new List<Vector2>();
    List<GameObject> houses = new List<GameObject>();
    public GameObject questPrefab;

    [SerializeField] private int QuestsCount;
    void Start()
    {
        SpawnQuests();
    }
    public void SpawnQuests(){
        TakingPositions();
        for (int i = 0; i < QuestsCount; i++)
        {
            QuestsSpawner();
        }
    }
    void TakingPositions()
    {
        for(int i = 0; i< gameObject.transform.childCount; i++)
        {
            positions.Add(gameObject.transform.GetChild(i).position);
            houses.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void QuestsSpawner()
    {
        int rand = Random.Range(0, positions.Count);
        GameObject tempQuestGameObject = Instantiate(questPrefab);
        tempQuestGameObject.transform.position = positions[rand];
        if(houses[rand].transform.tag == "Right_Side_Houses"){
            tempQuestGameObject.transform.Rotate(0,0,-90,Space.Self);
            tempQuestGameObject.transform.position += new Vector3(-1.7f,0.7f,0);
        }
        if(houses[rand].transform.tag == "Left_Side_Houses"){
            tempQuestGameObject.transform.Rotate(0,0,90,Space.Self);
             tempQuestGameObject.transform.position += new Vector3(1.7f,0.7f,0);
        }
        if(houses[rand].transform.tag == "Bottom_Side_Houses"){
            tempQuestGameObject.transform.Rotate(0,0,-180,Space.Self);
            tempQuestGameObject.transform.position += new Vector3(0,1f,0);
        }
        positions.RemoveAt(rand);
        houses.RemoveAt(rand);
    }
}
