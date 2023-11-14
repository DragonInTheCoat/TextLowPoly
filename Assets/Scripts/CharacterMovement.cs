using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform playerModel; // объект в юнити где расположен ваш персонаж
    private Transform mainCamera;
    public Rigidbody rigidbody;
    //public Animator animator; // аниматор который должен быть на вашем персонаже (Удалите строку если нету аниматора на персонаже)
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
        //animator.SetFloat("Horizontal", h); //Удалите строку если нету аниматора на персонаже
        //animator.SetFloat("Vertical", v); //Удалите строку если нету аниматора на персонаже

        Vector3 camF = mainCamera.forward;
        Vector3 camR = mainCamera.right;
        camF.y = 0f;
        camR.y = 0f;

        Vector3 movingVector = h * camR.normalized + v * camF.normalized;
        if (!mainCamera.GetComponent<CameraMovement>().stickCamera) // Вместо CameraMovement, вам нужно вставить название класса которое вы дали 3rd Person Camera Controller.
        {
            if (movingVector.magnitude >= 0.2f)
            {
                playerModel.rotation = Quaternion.LookRotation(camF, Vector3.up);
            }
        }

        rigidbody.velocity = movingVector * speed;
    }
}
