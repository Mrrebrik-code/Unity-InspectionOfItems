using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
    [SerializeField] private Camera CameraFPC;
    private CharacterController firstPersonController;

    private float xMov, zMov; //Прием кординат перемещения
    private Vector3 moveDirection;

    //Скорость перемещения
    [SerializeField] float speedMove = 3f;
    [SerializeField] float speedRun = 8f;
    private float speedCurrent;

    [SerializeField] float gravity; //Гравитация

    //Максимальная и минимальная высота при приседании(Стоячее и сидячее положение)
    [SerializeField] float minCrouch;
    [SerializeField] float maxCrouch;
    [SerializeField] bool isCrouch = false;


    private float xRot, yRot;
    private float xRotCurrent, yRotCurrent;
    private float currentVelosityX, currentVelosityY;

    [SerializeField] private float sensetive = 3f;
    [SerializeField] private float smoothTime = 0.1f;

    private void Start()
    {
        firstPersonController = GetComponent<CharacterController>();
        speedCurrent = speedMove;
        
    }

    private void FixedUpdate()
    {
        MovingFPC();
        RotationFPC();
    }


    private void MovingFPC()
    {
        xMov = Input.GetAxis("Horizontal");
        zMov = Input.GetAxis("Vertical");

        if (firstPersonController.isGrounded)
        {
            moveDirection = new Vector3(xMov, 0f, zMov);
            moveDirection = transform.TransformDirection(moveDirection);

            //Бег
            if (Input.GetKey(KeyCode.LeftShift)) speedCurrent = speedRun; //Вынести в инспектор
            else speedCurrent = speedMove;
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) speedCurrent = speedMove + 2f; //Вынести в инспектор

            //Приседание
            if (Input.GetKey(KeyCode.LeftControl)) firstPersonController.height = minCrouch;//Вынести в инспектор
            else firstPersonController.height = maxCrouch;
        }

        moveDirection.y -= gravity; //Гравитация персонажа

        firstPersonController.Move(moveDirection * speedCurrent * Time.fixedDeltaTime); //Перемещение персонажа

    }
    private void RotationFPC()
    {
        xRot += Input.GetAxis("Mouse X") * sensetive;
        yRot += Input.GetAxis("Mouse Y") * sensetive;
        yRot = Mathf.Clamp(yRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);

        CameraFPC.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
    }
}
