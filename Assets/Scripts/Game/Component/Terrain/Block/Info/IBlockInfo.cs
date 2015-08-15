using Assets.Scripts.Framework.Utils.Vector;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public interface IBlockInfo
    {
        Vector3[] GetFaceVertexOffsets(IntVector3 direction);

        IntVector2 GetTileCoordinates(IntVector3 direction);

        bool IsSolidIn(IntVector3 direction);
    }
}
