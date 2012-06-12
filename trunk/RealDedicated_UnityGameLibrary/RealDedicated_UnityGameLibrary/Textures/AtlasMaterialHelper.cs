using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary
{
    public class AtlasMaterialHelper : MonoBehaviour
    {
        #region Static Instance
        private static AtlasMaterialHelper classInstance = null;

        public static AtlasMaterialHelper instance
        {
            get
            {
                if (classInstance == null)
                {
                    classInstance = FindObjectOfType(typeof(AtlasMaterialHelper)) as AtlasMaterialHelper;
                }

                if (classInstance == null)
                {
                    GameObject newObj = new GameObject("AtlasMaterialHelper");
                    classInstance = newObj.AddComponent(typeof(AtlasMaterialHelper)) as AtlasMaterialHelper;
                    Debug.Log("Could not find AtlasMaterialHelper, so I made one");
                }

                return classInstance;
            }
        }
        #endregion

        public List<Material> CreateMaterialsFromAtlas(Texture2D atlasToParse, Material newBaseMaterial, int newTextureSize)
        {
            List<Material> tempMats = new List<Material>();

            int tempRowSize = (int)atlasToParse.width / (int)newTextureSize;
            float tempOffsetSize = (float)1 / (float)tempRowSize;

            for (int i = 0; i < (tempRowSize * tempRowSize); i++)
            {
                Material tempMat = new Material(newBaseMaterial);
                tempMat.mainTextureScale = new Vector2(tempOffsetSize, tempOffsetSize);
                tempMats.Add(tempMat);
            }

            Vector2[] textureOffsets = this.GetOffsets(tempMats.Count, tempRowSize, tempOffsetSize);

            for (int i = 0; i < tempMats.Count; i++)
            {
                tempMats[i].mainTextureOffset = textureOffsets[i];
            }

            return tempMats;
        }

        private Vector2[] GetOffsets(int numOfMats,int rowSize, float offsetSize)
        {
            Vector2[] offsets = new Vector2[numOfMats];
            Vector2 tempOffset = Vector2.zero;
            int textureCounter = 0;
            for (int i = 0; i < rowSize; i++)
            {
                tempOffset.x = offsetSize * i;

                for (int j = 0; j < rowSize; j++)
                {
                    tempOffset.y = offsetSize * j;

                    offsets[textureCounter] = tempOffset;
                    textureCounter++;
                }
            }

            return offsets;
        }
    }
}
