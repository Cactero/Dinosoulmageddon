using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    [SerializeField] private Image image;
    private float alphaValue;

    void Start()
    {
        image = GetComponent<Image>();
        alphaValue = 1f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, alphaValue);
    }
    public void Setup()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    //    while (image.color.a > 0f)
    //    {
    //        alphaValue -+ Time.deltaTime/fadeSpeed;
    //        image.color = new Color(image.color.r, image.color.g, image.color.b, alphaValue);
    //        yield return null;
    //    }
    }
}
