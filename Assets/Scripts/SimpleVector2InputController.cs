using UnityEngine;

public class SimpleVector2InputController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 1f;
    private float m_InputX, m_InputY;
    private Vector2 m_MoveDir;
    private void Update()
    {
        MovePosition();
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(m_MoveDir * m_Speed * Time.deltaTime);
    }

    private void MovePosition()
    {
        m_InputX = Input.GetAxisRaw("Horizontal");
        m_InputY = Input.GetAxisRaw("Vertical");
        if (m_InputX != 0 && m_InputY != 0)
        {
            m_InputX *= 0.72f;
            m_InputY *= 0.72f;
        }
        m_MoveDir = new Vector2(m_InputX, m_InputY);
    }
}
