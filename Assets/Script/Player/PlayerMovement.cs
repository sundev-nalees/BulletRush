using UnityEngine;

namespace BulletRush
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float playerSpeed=5f;

        private float horizontal;
        private float vertical;
        
        
        void Update()
        {
            MovementControl();
        
        }

        private void MovementControl()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = transform.forward*vertical+transform.right*horizontal;

            if (direction.magnitude >= 0.1f)
            {
                characterController.Move(direction * playerSpeed * Time.deltaTime);
            }
        }
    }
}
