using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block.Info
{
    public class AirBlockInfo : BlockInfo
    {
        public override bool IsSolidIn(Vector3 direction)
        {
            return false;
        }
    }
}
