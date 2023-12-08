using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerAction _player;
    [SerializeField] public int _countEnemyDie;
    [SerializeField] private GameObject _gameOverMenu;
    public int countEnemyDie { get { return _countEnemyDie; } }
    public static Action gameOver;
    public static Action addCountDieEnemy;
    private void OnEnable()
    {
        addCountDieEnemy += AddEnemy;
        gameOver += GameOver;
    }
    private void OnDisable()
    {
        addCountDieEnemy -= AddEnemy;
        gameOver -= GameOver;
    }

    private void AddEnemy()
    {
        _countEnemyDie++;
    }

    void Start()
    {
        _countEnemyDie = 0;
    }

    private void GameOver()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
