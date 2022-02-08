using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
