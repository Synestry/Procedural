using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public class AirBlockInfo : BlockInfo
    {
        public override Vector3[] GetFaceVertexOffsets(Vector3 direction)
        {
            return null;
        }

        public override bool IsSolidIn(Vector3 direction)
        {
            return false;
        }
    }
}
