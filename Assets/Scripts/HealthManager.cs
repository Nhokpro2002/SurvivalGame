using UnityEngine;
//using UnityEngine.UI;

// Class use to manage Health Player
public class HealthManager : MonoBehaviour
{
    
    [SerializeField] private Transform _player;
    //[SerializeField] private float _currentHealth;
    //public Image healthBar;
    //public PlayerData playerData;
    ////[SerializeField] private float _maxHealth;

   //
    private void LateUpdate()
    {
        // Reset the rotation of the health bar to its initial value
        transform.position = _player.position + new Vector3(0, 0.1f, 0);
    }
}
