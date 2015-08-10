using Assets.Scripts.Framework;
using Assets.Scripts.Game.Component.Terrain;

namespace Assets.Scripts.Game
{
    public class GameManager : AbstractGameManager 
    {
        public static new GameManager Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Instance = this;

            Components.Add(new TerrainComponent());
        }
    }
}