using UnityEditor;
using UnityEngine;
using System.IO;
[ExecuteInEditMode]
public class TextureImportSettings : MonoBehaviour
{
    //public bool change;

    //private void Update()
    //{
    //    if (change)
    //    {
    //        change = false;
    //        ChangeTextureImportSettings();
    //    }
    //}

    
    //static void ChangeTextureImportSettings()
    //{
    //    string scenesFolderPath = "Assets/Resources/Scenes"; // Adjust the path based on your actual folder structure

    //    // Get all subdirectories in the Scenes folder
    //    string[] sceneDirectories = Directory.GetDirectories(scenesFolderPath);

    //    foreach (string sceneDirectory in sceneDirectories)
    //    {
    //        // Get textures in each scene folder
    //        string skyboxTexturePath = Path.Combine(sceneDirectory, "skybox.jpg");
    //        string skyboxDepthTexturePath = Path.Combine(sceneDirectory, "skybox_depth.jpg");

    //        // Load the textures as assets
    //        TextureImporter skyboxTextureImporter = AssetImporter.GetAtPath(skyboxTexturePath) as TextureImporter;
    //        TextureImporter skyboxDepthTextureImporter = AssetImporter.GetAtPath(skyboxDepthTexturePath) as TextureImporter;

    //        if (skyboxTextureImporter != null)
    //        {
    //            // Modify import settings for skybox texture
    //            skyboxTextureImporter.mipmapEnabled = false;
    //            skyboxTextureImporter.filterMode = FilterMode.Point;
    //            skyboxTextureImporter.textureCompression = TextureImporterCompression.Uncompressed;
    //            skyboxTextureImporter.maxTextureSize = 8192;
    //            AssetDatabase.ImportAsset(skyboxTexturePath);
    //        }

    //        if (skyboxDepthTextureImporter != null)
    //        {
                
    //            // Modify import settings for skybox depth texture
    //            skyboxDepthTextureImporter.mipmapEnabled = false;
    //            skyboxDepthTextureImporter.filterMode = FilterMode.Point;
    //            skyboxDepthTextureImporter.textureCompression = TextureImporterCompression.Uncompressed;
    //            skyboxDepthTextureImporter.maxTextureSize = 8192;
    //            AssetDatabase.ImportAsset(skyboxDepthTexturePath);
    //        }
    //    }

    //    Debug.Log("Texture import settings updated for all scenes.");
    //}
}
