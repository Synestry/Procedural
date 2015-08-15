using Assets.Scripts.Framework.Utils.Vector;
using Assets.Scripts.Game.Component.Terrain.Block.Info;
using Assets.Scripts.Game.Component.Terrain.Chunk;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public interface IBlock
    {
        ChunkEntity Chunk { get; }

        IntVector3 Position { get; }

        IntVector3 WorldPosition { get; }

        IBlockInfo Info { get; }

        IBlock GetAdjacentBlockIn(IntVector3 direction);
    }
}
