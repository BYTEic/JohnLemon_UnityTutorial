using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    
    Animator m_Animator;
    Rigidbody m_RigidBody;

    public float turnSpeed = 20f;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_Movement.Normalize();

        bool HasHorizontalInput = !Mathf.Approximately(m_Movement.x, 0f);
        bool HasVerticalInput = !Mathf.Approximately(m_Movement.z, 0f);
        bool isWalking = HasHorizontalInput || HasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

    }

    void OnAnimatorMove()
    {
        m_RigidBody.MovePosition(m_RigidBody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_RigidBody.MoveRotation(m_Rotation);

    }
}
