using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public interface IBlock
    {
        ChunkEntity ChunkEntity { get; }

        Vector3 Position { get; }

        void SetPosition(ChunkEntity chunkEntity, Vector3 position);

        IBlock GetAdjacentBlockIn(Vector3 direction);

        bool IsSolidIn(Vector3 direction);
    }
}
