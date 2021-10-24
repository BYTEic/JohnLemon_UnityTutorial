using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 m_Movement;
    Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Verical"));
        m_Movement.Normalize();

        bool HasHorizontalInput = !Mathf.Approximately(m_Movement.x, 0f);
        bool HasVerticalInput = !Mathf.Approximately(m_Movement.y, 0f);
        bool isWalking = HasHorizontalInput || HasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);
        
    }
}
