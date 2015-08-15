using System.Collections.Generic;

using Assets.Scripts.Framework.Utils.Vector;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public class BlockInfo : IBlockInfo
    {
        protected Dictionary<IntVector3, Vector3[]> VertexOffsets = new Dictionary<IntVector3, Vector3[]>
        {
            { 
                IntVector3.Up, new []
                {
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                }
            },

            { 
                IntVector3.Down, new []
                {
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                }
            },

            { 
                IntVector3.Forward, new []
                {
                    new Vector3(0.5f, -0.5f, 0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, -0.5f, 0.5f),
                }
            },

            { IntVector3.Right, new []
                {
                    new Vector3(0.5f, -0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, 0.5f),
                    new Vector3(0.5f, -0.5f, 0.5f),
                }
            },

            { 
                IntVector3.Back, new []
                {
                    new Vector3(-0.5f, -0.5f, -0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, 0.5f, -0.5f),
                    new Vector3(0.5f, -0.5f, -0.5f),
                }
            },
            { 
                IntVector3.Left, new []
                {
                    new Vector3(-0.5f, -0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, 0.5f),
                    new Vector3(-0.5f, 0.5f, -0.5f),
                    new Vector3(-0.5f, -0.5f, -0.5f),
                }
            },
        };

        protected Dictionary<IntVector3, IntVector2> TileCoordinates = new Dictionary<IntVector3, IntVector2>
        {
            { IntVector3.Up, new IntVector2() { x = 2, y = 0 } },
            { IntVector3.Down, new IntVector2() { x = 1, y = 0 } },
            { IntVector3.Left, new IntVector2() { x = 3, y = 0 } },
            { IntVector3.Right, new IntVector2() { x = 3, y = 0 } },
            { IntVector3.Back, new IntVector2() { x = 3, y = 0 } },
            { IntVector3.Forward, new IntVector2() { x = 3, y = 0 } },
        };

        public virtual Vector3[] GetFaceVertexOffsets(IntVector3 direction)
        {
            return VertexOffsets[direction];
        }

        public virtual IntVector2 GetTileCoordinates(IntVector3 direction)
        {
            return TileCoordinates[direction];
        }

        public virtual bool IsSolidIn(IntVector3 direction)
        {
            return true;
        }
    }
}
