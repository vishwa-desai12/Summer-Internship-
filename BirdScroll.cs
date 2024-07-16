using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScroll : MonoBehaviour
{
    public GameObject[] Birds;
    public float scrollSpeed = 10f;
    public Transform BirdSpawnPoint;
    public float counter = 2f;
    bool isGameover=false;
    void Start()
    {
        GenerateChallenges();
    }

    void GenerateChallenges()
    {
        GameObject newChallenge = Instantiate(Birds[Random.Range(0,Birds.Length)],BirdSpawnPoint.position,Quaternion.identity);
        newChallenge.transform.parent = transform;
        counter = 4f;
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


