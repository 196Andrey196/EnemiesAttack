using UnityEngine;
using UnityEngine.UI;

public class EnemyHelthBar : MonoBehaviour
{
    [SerializeField] private Image _playerHelthBar;
    [SerializeField] private Enemy _enemyInfo;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = _enemyInfo.startHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (_enemyInfo.curentHealth != _playerHelthBar.fillAmount * _maxHealth)
        {
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        float currentHealth = _enemyInfo.curentHealth;
        _playerHelthBar.fillAmount = currentHealth / _maxHealth;
    }
}
