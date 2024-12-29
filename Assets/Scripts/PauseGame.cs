using UnityEngine;

public class PauseGame : MonoBehaviour
{
     public GameObject _musicManager;
    private void Awake()
    {
        
    }
    public void PressPauseGameButton()
    {
        Time.timeScale = 0;
        _musicManager.GetComponent<AudioSource>().Stop();
    }

    public void PressPlayGameButton() 
    {
        Time.timeScale = 1;
        _musicManager.GetComponent<AudioSource>().Play();
    }
}
