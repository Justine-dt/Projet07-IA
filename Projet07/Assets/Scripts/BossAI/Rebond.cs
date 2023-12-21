using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Cinemachine;

public class Rebond : MonoBehaviour
{
    public event Action OnReboundY;
    public event Action OnReboundX;

    [SerializeField] CinemachineVirtualCamera _cinemachine;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("UDWall"))
        {
            OnReboundY?.Invoke();
        }

        if (collision.collider.CompareTag("LRWall"))
        {
            OnReboundX?.Invoke();
        }

        StartCoroutine(ShakeScreen());
    }

    IEnumerator ShakeScreen()
    {
            _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1;
            yield return new WaitForSeconds(0.2f);
            _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }
}
