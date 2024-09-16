using Unity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
namespace Assets.Scripts.Controllers
{
    // Controlls movement and basic behaviour of the player
    public class PlayerController : MonoBehaviour
    {
        // Private fields
        private CharacterController characterController;
        private Animator animator;
        private float cameraRotation = 0;

        // Private fields, initialized from inspector
        [SerializeField]
        private Camera fpvCamera;
        [SerializeField]
        private InputActionReference moveInput;
        [SerializeField]
        private InputActionReference lookInput;

        // Public fields, may be modified from other scripts
        public float speed = 5;
        public float lookSensivity = 0.5f;

        public void Start()
        {
            // Caching components
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            HandleMovement();
            HandleLook();
        }

        // Movement logic using new input system
        private void HandleMovement()
        {
            var moveDirection = moveInput.action.ReadValue<Vector2>();

            // Toggling animations
            if (moveDirection != Vector2.zero) 
                animator.SetBool("IsRunning", true);
            else
                animator.SetBool("IsRunning", false);

            var direction = transform.right * moveDirection.x +
                transform.forward * moveDirection.y;

            characterController.SimpleMove(direction * speed);
        }

        // Looking logic using new input system
        private void HandleLook()
        {
            var lookDirection = lookInput.action.ReadValue<Vector2>();

            // Horisontal look movement
            if (lookDirection.x != 0)
            {
                transform.Rotate(Vector3.up * lookDirection.x * lookSensivity);
            }

            // Vertical look movement
            if (lookDirection.y != 0)
            {
                cameraRotation -= lookSensivity * lookDirection.y;

                // Clamping value to avoid unexpected camera behavour
                cameraRotation = Mathf.Clamp(cameraRotation, -90, 40);
                fpvCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);
            }
        }
    }
}
