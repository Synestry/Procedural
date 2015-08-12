using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Framework.Component;
using Assets.Scripts.Game.Component.Terrain.Block;
using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain
{
    public class TerrainComponent : AbstractGameComponent
    {
        public List<ChunkEntity> Chunks = new List<ChunkEntity>(); 

        public void Initialise()
        {
            CreateChunk(1, 1, 1);
        }

        public override void Update(float dt)
        {
            Chunks.ForEach(ch => ch.Update(dt));
        }

        public void CreateChunk(int x, int y, int z)
        {
            Chunks.Add(new ChunkEntity(new Vector3(x, y, z), Quaternion.Euler(Vector3.zero)));
        }

        public ChunkEntity GetChunk(int x, int y, int z)
        {
            var pos = new Vector3();
            pos.x = Mathf.FloorToInt(x / ChunkEntity.ChunkSize) * ChunkEntity.ChunkSize;
            pos.y = Mathf.FloorToInt(y / ChunkEntity.ChunkSize) * ChunkEntity.ChunkSize;
            pos.z = Mathf.FloorToInt(z / ChunkEntity.ChunkSize) * ChunkEntity.ChunkSize;

            return Chunks.SingleOrDefault(ch => ch.Position == pos);
        }

        public IBlock GetBlock(int x, int y, int z)
        {
            var chunk = GetChunk(x, y, z);

            if (chunk != null)
            {
                return chunk.GetBlock(x - (int)chunk.Position.x, y - (int)chunk.Position.y, z - (int)chunk.Position.z);
            }

            return new AirBlock();
        }
    }
}
