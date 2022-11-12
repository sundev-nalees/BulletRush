using UnityEngine;

namespace BulletRush
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float playerSpeed=5f;

        private float horizontal;
        private float vertical;
        private Vector3 direction;
        
        void Update()
        {
            MovementControl();
        
        }

        private void MovementControl()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                characterController.Move(direction * playerSpeed * Time.deltaTime);
            }
        }
    }
}
