using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] protected float _startHealth;
    public float startHealth { get { return _startHealth; } }
    [SerializeField] protected float _curentHealth;
    public float curentHealth
    {
        get { return _curentHealth; }
        set
        {
             if (_curentHealth > 0)
            {
                _curentHealth = value;
            }
        }
    }
    [SerializeField] protected float _disableDuration = 0;
    public virtual void Die() { }

}
