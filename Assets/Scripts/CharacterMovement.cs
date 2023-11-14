using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform playerModel; // ������ � ����� ��� ���������� ��� ��������
    private Transform mainCamera;
    public Rigidbody rigidbody;
    //public Animator animator; // �������� ������� ������ ���� �� ����� ��������� (������� ������ ���� ���� ��������� �� ���������)
    public float speed = 3f;

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(v);
        //animator.SetFloat("Horizontal", h); //������� ������ ���� ���� ��������� �� ���������
        //animator.SetFloat("Vertical", v); //������� ������ ���� ���� ��������� �� ���������

        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0f;
        camR.y = 0f;

        Vector3 movingVector = h * camR.normalized + v * camF.normalized;
        if (!mainCamera.GetComponent<CameraMovement>().stickCamera) // ������ CameraMovement, ��� ����� �������� �������� ������ ������� �� ���� 3rd Person Camera Controller.
        {
            if (movingVector.magnitude >= 0.2f)
            {
                playerModel.rotation = Quaternion.LookRotation(camF, Vector3.up);
            }
        }

        rigidbody.velocity = movingVector * speed;
    }
}
