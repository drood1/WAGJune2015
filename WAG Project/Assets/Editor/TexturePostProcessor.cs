using UnityEngine;
using UnityEditor;

public class TexturePostProcessor : AssetPostprocessor
{
    void OnPreprocessTexture(Texture2D texture)
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.filterMode = FilterMode.Point;

        Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Texture2D));
        if (asset)
        {
            EditorUtility.SetDirty(asset);
        }
        else
        {
            texture.filterMode = FilterMode.Point;          
        } 
    }
}