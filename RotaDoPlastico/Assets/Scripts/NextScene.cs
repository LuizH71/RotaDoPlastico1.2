using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(2);
    }
    private void OnEnable()
    {
        SceneManager.LoadScene(2);
    }
}
