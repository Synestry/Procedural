using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Chunk;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public class GrassBlock : AbstractBlock
    {
        public GrassBlock(ChunkEntity chunk, IntVector3 position) : base(chunk, position) { }
    }
}
