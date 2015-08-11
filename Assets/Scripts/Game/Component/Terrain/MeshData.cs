using System.Collections.Generic;
using Assets.Scripts.Game.Component.Terrain.Block;
using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain
{
    public class MeshData
    {
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
            var offsets = new Dictionary<Vector3, Vector3[]>
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

            foreach (var direction in offsets.Keys)
            {
                if (block.GetAdjacentBlockIn(direction).IsSolidIn(-direction))
                {
                    foreach (var vector in offsets[direction])
                    {
                        Vertices.Add(block.Position + vector);
                    }

                    AddFaceTriangles();
                }
            }
        }

        private void AddFaceTriangles()
        {
            if (Vertices.Count < 4) return;

            Triangles.Add(Vertices.Count - 4);
            Triangles.Add(Vertices.Count - 3);
            Triangles.Add(Vertices.Count - 2);

            Triangles.Add(Vertices.Count - 4);
            Triangles.Add(Vertices.Count - 2);
            Triangles.Add(Vertices.Count - 1);
        }
    }
}
