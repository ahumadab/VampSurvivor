using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        Rigidbody2D rigidbody2D;
        [HideInInspector] public Vector3 movementVector;
        [SerializeField] float speed = 10f;
        [HideInInspector] public float lastHorizontalVector;
        [HideInInspector] public float lastVerticalVector;

        Animate animate;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            movementVector = new Vector3();
            animate = GetComponent<Animate>();
        }
        void Start()
        {
            lastHorizontalVector = -1f;
            lastVerticalVector = 1f;
        }

        void Update()
        {
            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");
            movementVector *= speed;

            if (movementVector.x != 0)
            {
                lastHorizontalVector = movementVector.x;
            }
            if (movementVector.y != 0)
            {
                lastVerticalVector = movementVector.y;
            }

            animate.horizontal = movementVector.x;

            rigidbody2D.velocity = movementVector;
        }
    }
}
