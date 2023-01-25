using UnityEngine;
using UnityEngine.Serialization;

namespace Actor
{
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float runSpeed = 8f;
        [FormerlySerializedAs("m_Animator")] [SerializeField] private Animator animator;
        private Rigidbody _rigidbody;
        private new Transform _transform;
        private Vector2 _currentDirection;
        private float _currentSpeed;
        private bool _isAlive = true;
        private bool _isGrounded = true;
        private bool _isFacingBackwards = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }
        private void Update()
        {
            _currentDirection = GetDirection();
            _currentSpeed = GetRunning() ? runSpeed : walkSpeed;
            var isAttacking = GetPrimaryAction();
            if (isAttacking)
                Attack();
        }
        private void FixedUpdate()
        {
            Move(_currentDirection, _currentSpeed);
        }

        protected virtual void Attack()
        {
            animator.SetTrigger("Attack");
        }

        private void Move(Vector2 direction, float speed)
        {
            // Transform Input direction Vector2 to movement Vector3
            var movement = new Vector3(direction.x, 0f, direction.y);
            movement.Normalize();
            // Get movement vector
            var translation = movement * (speed * Time.fixedDeltaTime);
            // Update components
            _transform.Translate(translation);
            animator.SetFloat("Speed", translation.magnitude / walkSpeed);
            // Flip Sprites in Animator
            if (translation == Vector3.zero || !_isGrounded) return;
            if (translation.x != 0)
                _isFacingBackwards = translation.x < 0;
            FlipSprite(_isFacingBackwards);
        }

        private void FlipSprite(bool isFacingBackwards)
        {
            _transform.localScale = isFacingBackwards ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }

        protected abstract Vector2 GetDirection();
        protected abstract bool GetRunning();
        protected abstract bool GetPrimaryAction();
        protected abstract bool GetSecondaryAction();
    }
}
