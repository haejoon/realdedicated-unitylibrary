using UnityEngine;
using System.Collections.Generic;

namespace RealDedicated_UnityGameLibrary 
{
    public class AtlasMaterialCreator : MonoBehaviour
    {
        #region Members
        public Texture2D atlasToSplit;
        public int textureSize = 256;
        public Material baseMaterial;
        public List<Material> exposedMaterials = new List<Material>();

        private float offsetSize = 0;
        private int rowSize = 0;
        #endregion

        #region Methods
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
        }

        private void CreateMaterials()
        {
            for(int i = 0; i < (this.rowSize * this.rowSize); i++)
            {
                Material tempMat = new Material(this.baseMaterial);
                tempMat.mainTextureScale = new Vector2(this.offsetSize, this.offsetSize);
                this.exposedMaterials.Add(tempMat);
            }
        }

        private void OffsetMaterials()
        {
            Vector2[] textureOffsets = this.GetOffsets();

            for (int i = 0; i < this.exposedMaterials.Count; i++)
            {
                this.exposedMaterials[i].mainTextureOffset = textureOffsets[i];
            }
        }

        private Vector2[] GetOffsets()
        {
            Vector2[] offsets = new Vector2[this.exposedMaterials.Count];
            Vector2 tempOffset = Vector2.zero;
            int textureCounter = 0;
            for (int i = 0; i < this.rowSize; i++)
            {
                tempOffset.x = this.offsetSize * i;

                for (int j = 0; j < this.rowSize; j++)
                {
                    tempOffset.y = this.offsetSize * j;

                    offsets[textureCounter] = tempOffset;
                    textureCounter++;
                }
            }

            return offsets;
        }

        private void SetMaterialProperties(Material matToSet, float offsetX, float offsetY)
        {
            matToSet.mainTextureOffset = new Vector2(offsetX, offsetY);
        }
        #endregion
    }
}
