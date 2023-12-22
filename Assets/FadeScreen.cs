using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Image fadeImage; // Ссылка на компонент Image
    public float fadeSpeed = 0.1f;

    private void Update()
    {
        // Получаем текущий цвет Image
        
        Color currentColor = fadeImage.color;

        // Вычисляем новую альфа-компоненту с использованием Lerp
        float alpha = currentColor.a + (Time.deltaTime * fadeSpeed);
        if (alpha < 1) { 
        
            currentColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

           
            fadeImage.color = currentColor;
        };
       
    }
}
