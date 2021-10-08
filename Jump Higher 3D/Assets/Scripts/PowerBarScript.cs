using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarScript : MonoBehaviour
{
    [SerializeField] private Image PowerBarImage;

    bool isPowerUp = true;
    bool isDirection = true;
    public float power = 0;
    float powerSpeed = 100;

    private void Update()
    {
        if(isPowerUp == true)
        {
            PowerActive();
        }
    }

    void PowerActive()
    {
        if(isDirection == true)
        {
            power += Time.deltaTime * powerSpeed;
            
            if(power > 100)
            {
                isDirection = false;
                power = 100;
            }
        }
        else
        {
            power -= Time.deltaTime * powerSpeed;

            if (power < 0)
            {
                isDirection = true;
                power = 0;
            }
        }
        PowerBarImage.fillAmount = power / 100;
    }

    public void EndPower()
    {
        isPowerUp = false;
    }

}
