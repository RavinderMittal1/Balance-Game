using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundRestart : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SceneManager.LoadScene("GameOver");
    }
}