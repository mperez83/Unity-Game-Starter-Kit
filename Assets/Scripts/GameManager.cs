using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float globalCamShakeMultiplier;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;

    float screenTopEdge;
    float screenBottomEdge;
    float screenLeftEdge;
    float screenRightEdge;

    bool secretActive;



    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

        UpdateScreenEdges();
    }

    void Update()
    {
        UpdateScreenEdges();
    }

    void UpdateScreenEdges()
    {
        Camera mainCam = Camera.main;
        screenTopEdge = mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, -(mainCam.transform.position.z))).y;
        screenBottomEdge = mainCam.ScreenToWorldPoint(new Vector3(0, 0, -(mainCam.transform.position.z))).y;
        screenLeftEdge = mainCam.ScreenToWorldPoint(new Vector3(0, 0, -(mainCam.transform.position.z))).x;
        screenRightEdge = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, -(mainCam.transform.position.z))).x;
    }

    public bool IsTransformOffCamera(Transform transform)
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        if (pos.y > screenTopEdge || pos.y < screenBottomEdge || pos.x < screenLeftEdge || pos.x > screenRightEdge) return true;
        else return false;
    }

    public void ActivateSecret(AudioClip secretMusicToPlay)
    {
        if (!secretActive)
        {
            secretActive = true;
            musicAudioSource.clip = secretMusicToPlay;
            musicAudioSource.Play();
        }
    }
}
