using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0f, input.y);

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
