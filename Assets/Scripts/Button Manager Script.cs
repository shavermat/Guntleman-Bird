using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void PlayButton()
    {
        
    SceneManager.LoadScene(1);

    
    }

    public void BackMenuButton()
    {
        
    SceneManager.LoadScene(0);

    
    }

 public void ExitButton()
    {
        
    Application.Quit();
  Debug.Log("Выход из игры");
    
    }


}
