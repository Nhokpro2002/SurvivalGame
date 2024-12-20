
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text currentScore;

    public void replayGame()
    {
        SceneManager.LoadScene(1);
    }   


    
}
