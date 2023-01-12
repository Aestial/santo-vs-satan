using UnityEngine;

namespace Santos
{
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] private float m_WalkSpeed = 4f;
        [SerializeField] private float m_RunSpeed = 8f;
        [SerializeField] private Animator m_Animator;
        private Rigidbody m_Rigidbody;
        private Transform m_Transform;
        private Vector2 m_CurrentDirection;
        private float m_CurrentSpeed;
        private bool m_IsAlive = true;
        private bool m_IsGrounded = true;
        private bool m_IsFacingBackwards = true;

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Transform = transform;
        }
        private void Update()
        {
            m_CurrentDirection = GetDirection();
            m_CurrentSpeed = GetRunning() ? m_RunSpeed : m_WalkSpeed;
            var isAttacking = GetPrimaryAction();
            if (isAttacking)
                Attack();
        }
        private void FixedUpdate()
        {
            Move(m_CurrentDirection, m_CurrentSpeed);
        }

        public virtual void Attack()
        {
            m_Animator.SetTrigger("Attack");
        }

        private void Move(Vector2 direction, float speed)
        {
            // Transform Input direction Vector2 to movement Vector3
            var planeDirection = new Vector3(direction.x, 0f, direction.y);
            planeDirection.Normalize();
            // Get movement vector
            var movement = planeDirection * speed;
            // Update components
            m_Transform.Translate(movement * Time.fixedDeltaTime);
            m_Animator.SetFloat("Speed", movement.magnitude / m_WalkSpeed);
            // Flip Sprites in Animator
            if (movement != Vector3.zero && m_IsGrounded)
            {
                if (movement.x != 0)
                    m_IsFacingBackwards = movement.x < 0;
                FlipSprite(m_IsFacingBackwards);
            }
        }

        private void FlipSprite(bool isFacingBackwards)
        {
            Debug.Log(isFacingBackwards);
            if (isFacingBackwards)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        protected abstract Vector2 GetDirection();
        protected abstract bool GetRunning();
        protected abstract bool GetPrimaryAction();
        protected abstract bool GetSecondaryAction();
    }

}
