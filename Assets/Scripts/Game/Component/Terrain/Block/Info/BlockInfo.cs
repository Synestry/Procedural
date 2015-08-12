using System.Collections.Generic;

using Assets.Scripts.Framework.Utils.Vector;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public class BlockInfo : IBlockInfo
    {
        protected Dictionary<Vector3, Vector3[]> VertexOffsets = new Dictionary<Vector3, Vector3[]>
        {
            { Vector3.up, new []
                {
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                }
            },

            { Vector3.down, new []
                {
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                }
            },

            { Vector3.forward, new []
                {
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                }
            },

            { Vector3.right, new []
                {
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                }
            },

            { Vector3.back, new []
                {
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                }
            },
            { Vector3.left, new []
                {
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                }
            },
        };

        protected Dictionary<Vector3, IntVector2> TileCoordinates = new Dictionary<Vector3, IntVector2>
        {
            { Vector3.up, new IntVector2() { x = 2, y = 0 } },
            { Vector3.down, new IntVector2() { x = 1, y = 0 } },
            { Vector3.left, new IntVector2() { x = 3, y = 0 } },
            { Vector3.right, new IntVector2() { x = 3, y = 0 } },
            { Vector3.back, new IntVector2() { x = 3, y = 0 } },
            { Vector3.forward, new IntVector2() { x = 3, y = 0 } },
        }; 

        public virtual Vector3[] GetFaceVertexOffsets(Vector3 direction)
        {
            return VertexOffsets[direction];
        }

        public virtual IntVector2 GetTileCoordinates(Vector3 direction)
        {
            return TileCoordinates[direction];
        }

        public virtual bool IsSolidIn(Vector3 direction)
        {
            return true;
        }
    }
}
