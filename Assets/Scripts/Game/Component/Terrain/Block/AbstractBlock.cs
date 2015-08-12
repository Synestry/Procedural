using Assets.Scripts.Game.Component.Terrain.Block.Info;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public class AbstractBlock : IBlock
    {
        public ChunkEntity ChunkEntity { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 WorldPosition { get { return ChunkEntity.Position + Position; } }

        public IBlockInfo Info { get; protected set; }

        public AbstractBlock()
        {
            Info = new BlockInfo();
        }

        public void SetPosition(ChunkEntity chunkEntity, Vector3 position)
        {
            ChunkEntity = chunkEntity;
            Position = position;
        }

        public IBlock GetAdjacentBlockIn(Vector3 direction)
        {
            return ChunkEntity.GetBlock(Position + direction);
        }
    }
}
