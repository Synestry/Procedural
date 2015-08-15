using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Framework.Entity;
using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Block;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Chunk
{
    public class ChunkEntity : AbstractEntity
    {
        public const int ChunkSize = 8;

        public IntVector3 Position { get; private set; }

        private TerrainComponent TerrainComponent { get { return GameManager.Instance.Get<TerrainComponent>(); } }

        private MeshFilter MeshFilter { get; set; }

        private Dictionary<IntVector3, IBlock> Blocks { get; set; }

        private MeshData MeshData { get; set; }

        public ChunkEntity()
        {
            MeshData = new MeshData();
            Blocks = new Dictionary<IntVector3, IBlock>();

            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    for (int z = 0; z < ChunkSize; z++)
                    {
                        SetBlock(new AirBlock(this, new IntVector3(x, y, z)));
                    }
                }
            }
        }

        public void Initialise(IntVector3 position)
        {
            base.Initialise(GameManager.Instance.ChunkPrefab);
            Position = position;
            GameObject.name = "ChunkEntity " + Position;
            GameObject.transform.position = position.ToVector3();
            MeshFilter = GameObject.GetComponent<MeshFilter>();
        }

        public void UpdateChunk()
        {
            MeshData.Reset();

            Blocks.Values.ToList().ForEach(MeshData.AddBlock);

            MeshData.IsReady = true;
        }

        public void RenderChunk()
        {
            if (!MeshData.IsReady) return;

            MeshFilter.mesh.Clear();
            MeshFilter.mesh.vertices = MeshData.Vertices.ToArray();
            MeshFilter.mesh.triangles = MeshData.Triangles.ToArray();
            MeshFilter.mesh.uv = MeshData.UVs.ToArray();
            MeshFilter.mesh.RecalculateNormals();
        }

        public IBlock SetBlock(IBlock block)
        {
            Blocks[block.Position] = block;
            return block;
        }

        public void DeleteBlock(IBlock block)
        {
            Blocks[block.Position] = new AirBlock(this, Position);
        }

        public void DeleteBlock(IntVector3 position)
        {
            Blocks[Position] = new AirBlock(this, Position);
        }

        public IBlock GetBlock(IntVector3 position)
        {
            if (Blocks.ContainsKey(position)) return Blocks[position];

            return TerrainComponent.GetBlock(Position + position);
        }

        public override void Destroy()
        {
            MeshData = null;
            Blocks = null;

            base.Destroy();
        }
    }
}
