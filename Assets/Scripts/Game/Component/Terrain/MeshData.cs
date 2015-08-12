using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Component.Terrain.Block;

using UnityEngine;

using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Game.Component.Terrain
{
    public class MeshData
    {
        public const float TileSize = 0.25f;

        public List<Vector3> Directions
        {
            get { return new List<Vector3>() { Vector3.down, Vector3.up, Vector3.back, Vector3.forward, Vector3.left, Vector3.right }; }
        }

        public List<Vector3> Vertices { get; private set; }
        public List<int> Triangles { get; private set; }
        public List<Vector2> UVs { get; private set; }

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
        }

        public void AddBlock(IBlock block)
        {
            foreach (var direction in Directions)
            {
                AddFaceIfSolid(block, direction);
            }
        }

        private void AddFaceIfSolid(IBlock block, Vector3 direction)
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

        private void AddFaceVertices(IBlock block, Vector3[] offsets)
        {
                foreach (var vector in offsets)
                {;
                    Vertices.Add(block.Position + vector);
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

        private void AddFaceUvs(IBlock block, Vector3 direction)
        {
            UVs.AddRange(GetFaceUvs(block, direction));
        }

        private IEnumerable<Vector2> GetFaceUvs(IBlock block, Vector3 direction)
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
