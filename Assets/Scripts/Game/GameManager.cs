using Assets.Scripts.Framework;
using Assets.Scripts.Game.Component.Terrain;

using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameManager : AbstractGameManager 
    {
        public static new GameManager Instance { get; private set; }

        public GameObject ChunkPrefab;

        protected override void Awake()
        {
            base.Awake();

            Instance = this;

            var terrain = new TerrainComponent();

            Components.Add(terrain);

            terrain.Initialise();
        }
    }
}