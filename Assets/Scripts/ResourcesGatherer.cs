using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[ExecuteInEditMode]
public class ResourcesGatherer : MonoBehaviour
{
    public SkyboxRendererController skyboxRendererController;
    public bool loadResources = false;

    private void Update()
    {
        if (loadResources)
        {
            loadResources = false;
            LoadScenes();
        }
        
    }

    void LoadScenes()
    {
        string scenesFolderPath = "Assets/Resources/scenes"; 

        string[] sceneDirectories = Directory.GetDirectories(scenesFolderPath);

        skyboxRendererController.ScenesData = new SceneData[sceneDirectories.Length];

        for (int i = 0; i < sceneDirectories.Length; i++)
        {
            string skyboxTexturePath = "scenes/Scene" + (i+1) + "/" + "skybox";
            string skyboxDepthTexturePath = "scenes/Scene" + (i + 1) + "/" + "skybox_depth";
            string speechAudioPath = "scenes/Scene" + (i + 1) + "/" + "speech";
            string backgroundAudioPath = "scenes/Scene" + (i + 1) + "/" + "background_music";

            skyboxRendererController.ScenesData[i] = new SceneData
            {
                skyboxTexture = LoadTexture(skyboxTexturePath),
                skyboxDepthTexture = LoadTexture(skyboxDepthTexturePath),
                speechAudio = LoadAudio(speechAudioPath),
                backgroundAudio = LoadAudio(backgroundAudioPath),
            };
        }
    }

    Texture LoadTexture(string path)
    {
        Texture loadedTexture = Resources.Load<Texture>(path);
        if (loadedTexture == null)
            Debug.LogError("Texture not found at path: " + path);
        return loadedTexture;
    }

    AudioClip LoadAudio(string path)
    {
        return Resources.Load<AudioClip>(path);
    }
}
