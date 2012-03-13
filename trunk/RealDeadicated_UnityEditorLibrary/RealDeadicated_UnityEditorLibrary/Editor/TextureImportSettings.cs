using System.Collections;
using UnityEditor;
using UnityEngine;

namespace RealDedicated_UnityEditorLibrary
{
    public class TextureImportSettings : AssetPostprocessor
    {
        public int maxTextureSize = 4096;

        public void OnPreprocessTexture()
        {
            TextureImporter myTextImporter = (TextureImporter)assetImporter;

            myTextImporter.maxTextureSize = this.maxTextureSize;
        }
    }
}
