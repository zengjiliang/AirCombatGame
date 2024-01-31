using UnityEditor;

public class TextureSettings: AssetPostprocessor{
    private void OnpreprocessTexture(){
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}