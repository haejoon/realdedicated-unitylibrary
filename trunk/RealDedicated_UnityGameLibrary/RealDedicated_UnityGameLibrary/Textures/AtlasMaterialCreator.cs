using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary 
{
    public class AtlasMaterialCreator : MonoBehaviour
    {
        public Texture2D atlasToSplit;
        public int textureSize = 256;
        public Material baseMaterial;
        public Dictionary<int, Material> atlasedMaterialsDictionary = new Dictionary<int, Material>();

        private float offsetSize = 0;
        private int rowSize = 0;

        public void Start()
        {
            if(this.baseMaterial != null && this.atlasToSplit != null)
                this.ParseAtlas();
        }

        private void ParseAtlas()
        {
            this.DetermineOffsetSize();
            this.CreateMaterials();
            this.OffsetMaterials();            
        }

        private void DetermineOffsetSize()
        {
            rowSize = (int)this.atlasToSplit.width / (int)this.textureSize;

            this.offsetSize = (float)1 / (float)rowSize;
            Debug.Log(string.Format("RowSize {0}. Offsetsize {1}", rowSize, offsetSize));
        }

        private void CreateMaterials()
        {
            for(int i = 0; i < (this.rowSize * this.rowSize); i++)
            {
                Material tempMat = new Material(this.baseMaterial);
                tempMat.mainTextureScale = new Vector2(this.offsetSize, this.offsetSize);
                this.atlasedMaterialsDictionary.Add(i, tempMat);
            }
        }

        private void OffsetMaterials()
        {
            Vector2[] textureOffsets = this.GetOffsets();

            for(int i = 0; i < this.atlasedMaterialsDictionary.Count;i++)
            {
                this.atlasedMaterialsDictionary[i].mainTextureOffset = textureOffsets[i];
            }
        }

        private Vector2[] GetOffsets()
        {
            Vector2[] offsets = new Vector2[this.atlasedMaterialsDictionary.Count];
            Vector2 tempOffset = Vector2.zero;
            for (int i = 0; i < offsets.Length; i++)
            {
                if (i < this.rowSize)
                    tempOffset.x = this.offsetSize * i;
                else
                {
                    int currentRow = i / this.rowSize;
                    tempOffset.x = this.offsetSize * (i - (currentRow * rowSize));

                    Debug.Log(string.Format("CurrentRow {0}. i {1}", currentRow, i));
                }

                for (int j = 0; j < this.rowSize; j++)
                {
                    tempOffset.y = this.offsetSize * j;

                    Debug.Log(string.Format("Texture[{0}], OffsetX {1}. OffsetY {2}", i, tempOffset.x, tempOffset.y));

                    offsets[i] = tempOffset;
                }
            }

            return offsets;
        }

        private void SetMaterialProperties(Material matToSet, float offsetX, float offsetY)
        {
            matToSet.mainTextureOffset = new Vector2(offsetX, offsetY);
        }
    }
}
