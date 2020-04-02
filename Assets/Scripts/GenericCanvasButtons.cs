using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCanvasButtons : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        FadeHandler.instance.FadeToScene(sceneName, 0.25f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateSecret(AudioClip secretAudioClip)
    {
        GameManager.instance.ActivateSecret(secretAudioClip);
    }
}
