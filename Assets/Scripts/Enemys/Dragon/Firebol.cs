using UnityEngine;

public class Firebol : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    public float moveSpeed { get { return _moveSpeed; } }
    [SerializeField] float _damageCost;
    public float damageCost { get { return _damageCost; } }
    [SerializeField] LayerMask _layerMaskForContact;
    [SerializeField] GameObject _explosionEfetcs;
    [SerializeField] private float _disableDurationCharacter;
    public float disableDurationCharacter { get { return _disableDurationCharacter; } }

    private void Update()
    {
        transform.position += transform.right * _moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_layerMaskForContact == (_layerMaskForContact | (1 << other.gameObject.layer)))
        {
            Instantiate(_explosionEfetcs, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
