using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace P2Playworks.MainProjectAssets
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class Pixelation : MonoBehaviour
    {
        [Range(64f, 512f)]
        public float resolution = 128f;

        private Shader shader;

        private Material materialCached;

        private Material material
        {
            get
            {
                if(materialCached == null)
                {
                    //materialCached = new Material(shader);
                    materialCached = new Material(shader);
                    material.hideFlags = HideFlags.HideAndDontSave;
                }

                return materialCached;
            }
        }

        private void Awake()
        {
            shader = Shader.Find("Hidden/Custom/Pixelation");
        }

        private void OnEnable()
        {
            if (!shader.isSupported)
            {
                enabled = false;

                return;
            }
        }

        private void OnDisable()
        {
            if(material != null)
            {
                DestroyImmediate(material);
            }
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            float k = Camera.main.aspect;
            Vector2 count = new Vector2(resolution, resolution / k);
            Vector2 size = new Vector2(1.0f / count.x, 1.0f / count.y);

            material.SetVector("BlockCount", count);
            material.SetVector("BlockSize", size);

            Graphics.Blit(source, destination, material);
        }
    }
}
