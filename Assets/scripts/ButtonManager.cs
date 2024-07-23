using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
     public GameObject CanavasPlay;
     public GameObject MainCanvas;

    //mainMenu
   public void Play(){
        CanavasPlay.SetActive(true);
        MainCanvas.SetActive(false);
   }
   public void PlayVsAI(){
        PlayerPrefs.SetInt("IsAI", 1);

        SceneManager.LoadScene("GameVsPlayer");
   }
   public void PlayVsPlayer(){
        PlayerPrefs.SetInt("IsAI", 0);
        SceneManager.LoadScene("GameVsPlayer");
   }

   public void Back(){
        CanavasPlay.SetActive(false);
        MainCanvas.SetActive(true);
   }
   public void Options(){
        SceneManager.LoadScene("MainMenu");
   }

   public void Exit(){
        Application.Quit();
   }

    //Options


}
