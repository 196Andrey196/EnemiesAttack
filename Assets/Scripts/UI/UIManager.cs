using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _playerHelthBar;
    [SerializeField] private CharacterInfo _playerInfo;
    [SerializeField] private TextMeshProUGUI _dieEnemyCounter;
    [SerializeField] private GameManager _gameManager;

    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _playerInfo.startHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        _dieEnemyCounter.text = _gameManager.countEnemyDie.ToString();
        if (_playerInfo.curentHealth != _playerHelthBar.fillAmount * _maxHealth)
        {
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        float currentHealth = _playerInfo.curentHealth;
        _playerHelthBar.fillAmount = currentHealth / _maxHealth;
    }
}
