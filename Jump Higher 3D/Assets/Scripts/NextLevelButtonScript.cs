using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButtonScript : MonoBehaviour
{
    [SerializeField] private void NextLevel()
    {
        SceneManager.LoadScene("GameplayScene");
    }

}
