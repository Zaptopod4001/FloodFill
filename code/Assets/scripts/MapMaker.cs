using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Eses.FloodTest
{

    // Copyright Sami S. 

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.


    // NOTE:
    // Demo class which shows how the
    // Non-recursive flood fill class can be used

    public class MapMaker : MonoBehaviour
    {

        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Texture2D texture;
        [SerializeField] Texture2D textureCopy;

        [SerializeField] int[,] arr;
        
        [SerializeField] int[,] arrTest =
        {
            {1,0,0,0,1},
            {0,1,1,0,0},
            {0,1,0,1,0},
            {0,0,0,0,0},
            {1,0,0,0,1}
        };


        void Start()
        {
            arr = Convert(texture);

            textureCopy = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false, false);
            spriteRenderer.sprite = Sprite.Create(textureCopy, new Rect(0, 0, textureCopy.width, textureCopy.height), new Vector2(0.5f, 0.5f), 32);

            StartCoroutine(Fill());
        }

        IEnumerator Fill()
        {
            var filled = new FloodFill(arr).FloodFillArea(new Vector2Int(0, 0), 0);

            var steps = 0;

            foreach (var key in filled.Keys)
            {
                var cell = filled[key];
                textureCopy.SetPixel(cell.pos.x, cell.pos.y, Color.red);

                steps++;

                if (steps > 100)
                {
                    steps = 0;
                    textureCopy.Apply();
                    yield return null;
                }
            }

            textureCopy.Apply();
        }

        static int[,] Convert(Texture2D texture)
        {
            var arr = new int[texture.height, texture.width];

            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    arr[y, x] = texture.GetPixel(x, y) == Color.white ? 0 : 1;
                }
            }

            return arr;
        }

    }

}
