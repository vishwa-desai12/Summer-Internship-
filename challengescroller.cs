using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challengescroller : MonoBehaviour
{
    public GameObject[] challenges;
    public float scrollSpeed = 10f;
    public Transform challengeSpawnPoint;
    public float counter = 0f;
    bool isGameover=false;
    void Start()
    {
        GenerateChallenges();
    }

    void GenerateChallenges()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0,challenges.Length)],challengeSpawnPoint.position,Quaternion.identity);
        newChallenge.transform.parent = transform;
        counter = 2f;
    }
    void Update()
    {
        if(isGameover) return;
        if(counter <= 0)
        {
            
            GenerateChallenges();
        }
        else
        {
            counter -=Time.deltaTime;
        }

        GameObject CurrentChild;
        for(int i=0;i<transform.childCount;i++)
       {
        CurrentChild = transform.GetChild(i).gameObject;
        ScrollChallenges(CurrentChild);

        if(CurrentChild.transform.position.x <= -20f)
        {
            
            Destroy(CurrentChild);
        }
       }
    }
    void ScrollChallenges(GameObject currentChallenges)
    {
       
        currentChallenges.transform.position += Vector3.left * scrollSpeed * Time.deltaTime; 
    }

public void Gameover(){
    isGameover = true;
}

}
