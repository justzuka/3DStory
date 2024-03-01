using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public Texture skyboxTexture;
    public Texture skyboxDepthTexture;
    public AudioClip speechAudio;
    public AudioClip backgroundAudio;
}

public class SkyboxRendererController : MonoBehaviour
{
    public SceneData[] ScenesData;
    public Material material;
    public AudioSource speechAudioSource;
    public AudioSource backgroundAudioSource;
    public AnimationCurve backgroundVolumeCurve;
    public float transitionDuration = 1;
    int SceneIndex = 1;
    float timeToWait = 0;
    float startTime = 0;
    private void Start()
    {
        material.SetTexture("_MainTex", ScenesData[0].skyboxTexture);
        material.SetTexture("_Depth", ScenesData[0].skyboxDepthTexture);
        material.SetFloat("_Blend", 0);
        speechAudioSource.clip = ScenesData[0].speechAudio;
        speechAudioSource.Play();
        timeToWait = ScenesData[0].speechAudio.length;
        startTime = Time.time;

        backgroundAudioSource.clip = ScenesData[0].backgroundAudio;
        backgroundAudioSource.Play();
        StartCoroutine(BackgroundVolumeMapping());
    }

    private void Update()
    {
        if (SceneIndex == ScenesData.Length)
        {
            return;
        }
        if (Time.time > startTime + timeToWait)
        {
            material.SetTexture("_BlendMainTex", ScenesData[SceneIndex].skyboxTexture);
            material.SetTexture("_BlendDepth", ScenesData[SceneIndex].skyboxDepthTexture);
            speechAudioSource.clip = ScenesData[SceneIndex].speechAudio;
            timeToWait = ScenesData[SceneIndex].speechAudio.length;
            speechAudioSource.Play();
            startTime = Time.time;
            StartCoroutine(LerpMaterialProperty());

            backgroundAudioSource.clip = ScenesData[SceneIndex].backgroundAudio;
            backgroundAudioSource.Play();
            StartCoroutine(BackgroundVolumeMapping());

            SceneIndex += 1;
        }
    }

    IEnumerator LerpMaterialProperty()
    {
        float elapsedTime = 0f;
        float startValue = 0f;
        float endValue = 1f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            float lerpedValue = Mathf.Lerp(startValue, endValue, t);

            material.SetFloat("_Blend", lerpedValue);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        material.SetFloat("_Blend", startValue);

        material.SetTexture("_MainTex", material.GetTexture("_BlendMainTex"));
        material.SetTexture("_Depth", material.GetTexture("_BlendDepth"));
    }

    IEnumerator BackgroundVolumeMapping()
    {
        float elapsedTime = 0;
        backgroundAudioSource.volume = backgroundVolumeCurve.Evaluate(0);
        while (true)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Min(elapsedTime / timeToWait, 1);
            print(t);
            if (t == 1)
            {
                backgroundAudioSource.volume = backgroundVolumeCurve.Evaluate(1);
                break;
            }
            backgroundAudioSource.volume = backgroundVolumeCurve.Evaluate(t);

            yield return null;
        }

    }
}
