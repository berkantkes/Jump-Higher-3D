using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButtonScript : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("GameplayScene");
    }

}
