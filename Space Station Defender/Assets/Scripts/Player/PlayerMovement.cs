using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraOffset;
     
    private float moveX;
    private float moveZ;
    private float playerSpeed = 5;
    private float gravity = -9.81f;
    private CharacterController playerController;
    private Camera playerCamera;

    private void Start()
    {
        playerController = gameObject.GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }
    void Update()
    {
        PlayerMove();
        PlayerRotation();
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        playerCamera.transform.position = transform.position + cameraOffset;
    }

    private void PlayerRotation()
    {
        Vector3 rotatePoint = playerCamera.GetComponent<RotatePoint>().PointToPass;
        Vector3 playerDiraction = (rotatePoint - transform.position).normalized;
        playerDiraction.y = 0f;
        if (playerDiraction != new Vector3(0, 0, 0))
        {
            transform.rotation = Quaternion.LookRotation(playerDiraction);
        }
    }

    private void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        playerController.Move(new Vector3(moveX * playerSpeed * Time.deltaTime, gravity * Time.deltaTime, moveZ * playerSpeed * Time.deltaTime));
    }
}
