using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
   public GameObject gameoverpannel; 

   void ShowOverPannel()
   {
gameoverpannel.SetActive(true);
   }

   public void GameOver()
   {
    ShowOverPannel();
   }

   public void Restart()
   {
SceneManager.LoadScene("SampleScene");
   }
}
