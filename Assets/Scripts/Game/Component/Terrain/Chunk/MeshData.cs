using System.Collections.Generic;

using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Block;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Chunk
{
    public class MeshData
    {
        public const float TileSize = 0.25f;

        public List<Vector3> Vertices { get; private set; }
        public List<int> Triangles { get; private set; }
        public List<Vector2> UVs { get; private set; }

        public bool IsReady = false;

        public MeshData()
        {
            Vertices = new List<Vector3>();
            Triangles = new List<int>();
            UVs = new List<Vector2>();
        }

        public void Reset()
        {
            Vertices.Clear();
            Triangles.Clear();
            UVs.Clear();

            IsReady = false;
        }

        public void AddBlock(IBlock block)
        {
            foreach (var direction in IntVector3.Directions) AddFaceIfSolid(block, direction);
        }

        private void AddFaceIfSolid(IBlock block, IntVector3 direction)
        {
            if (block.GetType() == typeof(AirBlock)) return;

            if (!block.GetAdjacentBlockIn(direction).Info.IsSolidIn(-direction))
            {
                var offsets = block.Info.GetFaceVertexOffsets(direction);

                if (offsets != null)
                {
                    AddFaceVertices(block, offsets);
                    AddFaceTriangles();
                    AddFaceUvs(block, direction);
                }
            }
        }

        private void AddFaceVertices(IBlock block, IEnumerable<Vector3> offsets)
        {
            foreach (var vector in offsets)
            {
                Vertices.Add(block.Position.ToVector3() + vector);
            }
        }

        private void AddFaceTriangles()
        {
            Triangles.Add(Vertices.Count - 4);
            Triangles.Add(Vertices.Count - 3);
            Triangles.Add(Vertices.Count - 2);

            Triangles.Add(Vertices.Count - 4);
            Triangles.Add(Vertices.Count - 2);
            Triangles.Add(Vertices.Count - 1);
        }

        private void AddFaceUvs(IBlock block, IntVector3 direction)
        {
            UVs.AddRange(GetFaceUvs(block, direction));
        }

        private IEnumerable<Vector2> GetFaceUvs(IBlock block, IntVector3 direction)
        {
            var uvs = new Vector2[4];
            var tilePos = block.Info.GetTileCoordinates(direction);

            uvs[0] = new Vector2(TileSize * tilePos.x + TileSize,
                TileSize * tilePos.y);
            uvs[1] = new Vector2(TileSize * tilePos.x + TileSize,
                TileSize * tilePos.y + TileSize);
            uvs[2] = new Vector2(TileSize * tilePos.x,
                TileSize * tilePos.y + TileSize);
            uvs[3] = new Vector2(TileSize * tilePos.x,
                TileSize * tilePos.y);

            return uvs;
        }
    }
}
