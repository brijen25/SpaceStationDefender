using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private RotatePoint m_RotatePoint;
    //[SerializeField] private InputController m_InputAction;
     
    private float m_MoveX;
    private float m_MoveZ;
    private float m_PlayerSpeed = 5;
    private CharacterController m_PlayerController;

    private float GRAVITY = -9.81f;

    private void Start()
    {
        m_PlayerController = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerRotation();
    }
    private void PlayerRotation()
    {
        Vector3 l_rotatePoint = m_RotatePoint.PointToPass;
        Vector3 l_playerDiraction = (l_rotatePoint - transform.position).normalized;
        l_playerDiraction.y = 0f;
        if (l_playerDiraction != new Vector3(0, 0, 0))
        {
            transform.rotation = Quaternion.LookRotation(l_playerDiraction);
        }
    }
    public void Fire()
    {
        Debug.Log("Fire!");
    }

    private void PlayerMove()
    {
        m_MoveX = Input.GetAxis("Horizontal");
        m_MoveZ = Input.GetAxis("Vertical");
        m_PlayerController.Move(new Vector3(m_MoveX * m_PlayerSpeed * Time.deltaTime, GRAVITY * Time.deltaTime, m_MoveZ * m_PlayerSpeed * Time.deltaTime));
    }
}
