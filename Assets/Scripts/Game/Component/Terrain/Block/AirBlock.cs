using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Block.Info;
using Assets.Scripts.Game.Component.Terrain.Chunk;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public class AirBlock : AbstractBlock
    {
        public AirBlock(ChunkEntity chunk = null, IntVector3 position = default(IntVector3)) : base(chunk, position)
        {
            Info = new AirBlockInfo();
        }
    }
}
