using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain.Block
{
    public class AirBlock : AbstractBlock
    {
        public override bool IsSolidIn(Vector3 direction)
        {
            return false;
        }
    }
}
