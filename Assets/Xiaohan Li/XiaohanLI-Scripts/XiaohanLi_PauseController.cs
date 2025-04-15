using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaohanLi_PauseController : MonoBehaviour
{
    // ‘›Õ£≥°æ∞£®∞Û∂®µΩ‘›Õ£∞¥≈•£©
    public void PauseEntireScene()
    {
        Time.timeScale = 0;
        AudioListener.pause = true; // ‘›Õ£À˘”–“Ù∆µ

    }

    // ª÷∏¥≥°æ∞£®∞Û∂®µΩºÃ–¯∞¥≈•£©
    public void ResumeEntireScene()
    {
        Time.timeScale = 1;
        AudioListener.pause = false; // ª÷∏¥“Ù∆µ

    }

}
