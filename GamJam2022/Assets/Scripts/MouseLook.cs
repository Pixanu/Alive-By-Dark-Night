using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//based on https://www.youtube.com/watch?v=_QajrabyTJc
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform hunterBody;
    public float xRotation = 0f;
    public float mouseX;
    public float mouseY;

    //For recoil
    float newRecoilAmountX;
    float newRecoilAmountY;
    public bool isShaking = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (isShaking)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            hunterBody.Rotate(Vector3.up * mouseX);

            float velocity = 0.3f;
            float smoothTime = 5f;
            float xRotationWithRecoil = Random.Range(0, newRecoilAmountX);
            transform.localRotation = Quaternion.Euler(xRotation + xRotationWithRecoil, 0f, 0f);
            GetComponentInParent<HunterMovement>().transform.Rotate(Vector3.up, Random.Range(-newRecoilAmountY, newRecoilAmountY));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            hunterBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void GetRecoilValue(float recoilAmountX, float recoilAmountY)
    {
        //works
        //xRotation += Random.Range(0, recoilAmountX);
        //GetComponentInParent<HunterMovement>().transform.Rotate(Vector3.up, Random.Range(-recoilAmountY, recoilAmountY));

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //hunterBody.Rotate(Vector3.up * mouseX);

        newRecoilAmountX = recoilAmountX;
        newRecoilAmountY = recoilAmountY;
    }
}
