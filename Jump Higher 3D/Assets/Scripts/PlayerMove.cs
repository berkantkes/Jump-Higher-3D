using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject gun;
    public Camera cam;
    public GameObject PowerBarScript;
    public GameObject gameOverCanvas;
    public static bool ifLevelComplete = false;

    private void Start()
    {
        ifLevelComplete = false;
    }

    public void Move()
    {
        float tapTiming = PowerBarScript.GetComponent<PowerBarScript>().power / 100;
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "trampoline")
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<JoystickPlayerExample>().enabled = false;

            gun.gameObject.GetComponent<Gun>().ifFlyFalse();

            cam.GetComponent<CameraScript>().isJumpTrue();
            cam.GetComponent<CameraScript>().CameraShootMode();

            TrampolineJump(); 
            Invoke("isJumpMakeFalse", 4f);
        }
        if(collision.gameObject.tag == "enemy")
        {
            if (!ifLevelComplete)
            {
                gameOverCanvas.SetActive(true);
                GameOver();
            } 
        }
    }


    private void Jump()
    {
        float tapTiming = PowerBarScript.GetComponent<PowerBarScript>().power / 50;
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 1) * tapTiming * 600 + new Vector3 (0,2,1) * 500);
    }

    private void TrampolineJump()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 1) * 1500);
    }

    private void isJumpMakeFalse()
    {
        cam.GetComponent<CameraScript>().isJumpFalse();
    }

    public void GameOver()
    {
        gun.GetComponent<Gun>().ifFlyTrue();
        cam.GetComponent<CameraScript>().isUpFalse();
        cam.GetComponent<CameraScript>().isJumpFalse();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ifLevelCompleteTrue()
    {
        ifLevelComplete = true;
    }

}
