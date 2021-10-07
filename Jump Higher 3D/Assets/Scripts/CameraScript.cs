using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public float cameraSensitivity;
    public GameObject gun;
    public Camera cam;
    public Image aim;
    public float smooth = 5f;
    Vector2 lookInput;
    float cameraPitch;
    
    bool isFlyBegan = false;
    bool isUp = true;
    bool isJump = false;

    private void Update()
    {
        if (isFlyBegan)
        {
            if (isUp || isJump)
            {
                GetTouchInput();
                LookAround();
            }
            Invoke("Fly",5f);
        }
    }

    public void Fly()
    {
        if (!isJump)
        {
            gun.GetComponent<Gun>().ifFlyTrue();
            aim.enabled = false;
            isUp = false;

            GameObject player = GameObject.Find("Player");
            player.GetComponent<JoystickPlayerExample>().enabled = true;

            gun.gameObject.transform.parent = player.transform;

            cam.transform.position = new Vector3(0.054f, 1.52f, -6.28f) + player.transform.position;
            Quaternion newRotation = Quaternion.Euler(16.7f, 0, 0);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, newRotation, Time.deltaTime * smooth);
            gun.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    private void GetTouchInput()
    {
        
        if (Input.touchCount > 0)
        {

            Touch t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Moved:
                    lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                    break;

                case TouchPhase.Stationary:
                    lookInput = Vector2.zero;
                    break;

                case TouchPhase.Ended:
                    lookInput = Vector2.zero;
                    break;
            }
        }
    }

    private void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90, 90);

        float xRotation = Mathf.Clamp(lookInput.x, -90, 90);
        transform.Rotate(Vector3.up, xRotation);
        transform.Rotate(Vector3.right, -lookInput.y);
    }

    public void CameraShootMode()
    {
        aim.enabled = true;

        GameObject player = GameObject.Find("Player");
        cam.transform.position = new Vector3(0.054f, -0.285f, 0.467f) + player.transform.position;

        Quaternion newRotation = Quaternion.Euler(0, 0, 0);
        cam.transform.rotation = newRotation;

        gun.gameObject.transform.parent = cam.transform;
        gun.transform.position = new Vector3(0.06f, -0.25f, 0.2f) + cam.transform.position;
    }

    public void isFlyBeganTrue()
    {
        isFlyBegan = true;
    }

    public void isJumpTrue()
    {
        isJump = true;
    }

    public void isJumpFalse()
    {
        isJump = false;
    }

    public void isUpFalse()
    {
        isUp = false;
    }
}
