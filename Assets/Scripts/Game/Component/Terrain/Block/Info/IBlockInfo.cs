using Assets.Scripts.Framework.Utils.Vector;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public interface IBlockInfo
    {
        Vector3[] GetFaceVertexOffsets(Vector3 direction);

        IntVector2 GetTileCoordinates(Vector3 direction);

        bool IsSolidIn(Vector3 direction);
    }
}
