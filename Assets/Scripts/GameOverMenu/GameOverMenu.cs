using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : Singleton<GameOverMenu>
{
    //public Text currentScore;
    private int _score = 0;

    public int Score 
    {
        get { return _score; } 
        set { _score = value; }
    }

    public void PressNewGameButton()
    {
        SceneManager.LoadScene(0);
    }  
    
    public void PressQuitButton()
    {
        Debug.Log("Not Finished");
    }

    private void Update()
    {
        //currentScore.text = "Score: " + _score.ToString();
        //Chuyển sence mất tham chiếu đến currentScore
        // Trong khi GameOverMenu không bị phá hủy, cần fix
    }

}
