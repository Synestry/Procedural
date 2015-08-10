using Assets.Scripts.Framework;

namespace Assets.Scripts.Game
{
    public class GameManager : AbstractGameManager 
    {
        public static new GameManager Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Instance = this;
        }
    }
}