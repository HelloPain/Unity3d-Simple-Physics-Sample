using System.Collections;
using UnityEngine;

public class MonitorPlayer : MonoBehaviour
{
    [SerializeField] private float m_TurnSpeed = 3f;
    [SerializeField] private int m_DelayTime = 3;
    [SerializeField] private Vector3 m_PosBias = new Vector3(0, 2, 0); //玩家位置偏移
    [SerializeField] private Transform m_Monitor;
    private Transform m_Target;
    private Quaternion m_InitRotation;

    private void Awake()
    {
        m_InitRotation = m_Monitor.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (m_Target == null)
        {
            m_Target = other.transform;
            StartCoroutine(FollowPlayer());
        }
    }

    void OnTriggerExit(Collider other)
    {
        m_Target = null;
    }

    private IEnumerator FollowPlayer()
    {
        //Found Player and Watch Player
        yield return new WaitForSeconds(m_DelayTime);
        while (m_Target != null)
        {
            Vector3 targetPosition = m_Target.position + m_PosBias;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - m_Monitor.position);
            Quaternion angles = Quaternion.Slerp(m_Monitor.rotation, targetRotation,
                Time.deltaTime * m_TurnSpeed);
            m_Monitor.transform.rotation = angles;
            yield return null;
        }
        
        //Return back
        yield return new WaitForSeconds(m_DelayTime);
        while (m_Monitor.rotation != m_InitRotation)
        {
            m_Monitor.rotation = Quaternion.Slerp(m_Monitor.rotation, m_InitRotation,
                Time.deltaTime * m_TurnSpeed);
            yield return null;
        }
    }

// private async Task FollowPlayer()
    // {
    //     //Found Player and Watch Player
    //     await Task.Delay(m_DelayTime);
    //     while (m_Target != null)
    //     {
    //         Vector3 targetPosition = m_Target.position + m_PosBias;
    //         Quaternion targetRotation = Quaternion.LookRotation(targetPosition - m_Monitor.position);
    //         Quaternion angles = Quaternion.Slerp(m_Monitor.rotation, targetRotation,
    //             Time.deltaTime * m_TurnSpeed);
    //         m_Monitor.transform.rotation = angles;
    //         await Task.Yield();
    //     }
    //
    //     //Return back
    //     await Task.Delay(m_DelayTime);
    //     while (m_Monitor.rotation != m_InitRotation)
    //     {
    //         m_Monitor.rotation = Quaternion.Slerp(m_Monitor.rotation, m_InitRotation,
    //             Time.deltaTime * m_TurnSpeed);
    //         await Task.Yield();
    //     }
    // }
}