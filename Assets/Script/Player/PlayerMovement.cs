using UnityEngine;

namespace BulletRush
{
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField] private float playerSpeed=0.1f;
        [SerializeField] private float mouseSensitivity=.5f;
        

        private float horizontal;
        private float vertical;
        private Vector2 turn;

    
        void Update()
        {
            MovementControl();
            PlayerRotation();
        }

        private void MovementControl()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal,0.0f, vertical)*playerSpeed*Time.deltaTime;
            transform.Translate(direction);
        }

        private void PlayerRotation()
        {
            turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        }
    }
}
