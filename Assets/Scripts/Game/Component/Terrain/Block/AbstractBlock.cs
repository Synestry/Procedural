using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Block.Info;
using Assets.Scripts.Game.Component.Terrain.Chunk;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public class AbstractBlock : IBlock
    {
        public ChunkEntity Chunk { get; set; }

        public IntVector3 Position { get; set; }

        public IntVector3 WorldPosition { get { return Chunk.Position + Position; } }

        public IBlockInfo Info { get; protected set; }

        public AbstractBlock(ChunkEntity chunk, IntVector3 position)
        {
            Chunk = chunk;
            Position = position;
            Info = new BlockInfo();
        }

        public IBlock GetAdjacentBlockIn(IntVector3 direction)
        {
            return Chunk.GetBlock(Position + direction);
        }
    }
}
