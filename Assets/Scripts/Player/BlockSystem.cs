using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    private AnimationSystem _animationSystem;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _animationSystem = new AnimationSystem(_animator);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Firebol"))
        {
            _animationSystem.CrossFadeAnimation("Blocked");
            float moveSpeed = collision.gameObject.GetComponent<Firebol>().moveSpeed;
            Vector3 newDirection = -collision.transform.right;

            collision.transform.right = newDirection;


        }
    }

}
