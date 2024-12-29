using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu>
{
    public void PressStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void PressMenuButton()
    {
        Debug.Log("Not Finished");
    }

    public void PressCreditsButton()
    {
        Debug.Log("Not Finished");
    }

   
}
