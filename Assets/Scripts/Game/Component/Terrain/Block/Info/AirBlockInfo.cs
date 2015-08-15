using Assets.Scripts.Framework.Utils.Vector;

using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public class AirBlockInfo : BlockInfo
    {
        public override Vector3[] GetFaceVertexOffsets(IntVector3 direction)
        {
            return null;
        }

        public override bool IsSolidIn(IntVector3 direction)
        {
            return false;
        }
    }
}
