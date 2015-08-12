using Assets.Scripts.Framework.Entity;
using Assets.Scripts.Game.Component.Terrain.Block;
using UnityEngine;

namespace Assets.Scripts.Game.Component.Terrain
{
    public class ChunkEntity : AbstractEntity
    {
        public const int ChunkSize = 16;

        public Vector3 Position { get; private set; }

        private TerrainComponent TerrainComponent { get { return GameManager.Instance.Get<TerrainComponent>(); } }

        private MeshFilter MeshFilter { get { return GameObject.GetComponent<MeshFilter>(); } }
        private MeshRenderer MeshRenderer { get { return GameObject.GetComponent<MeshRenderer>(); } }
        private MeshCollider MeshCollider { get { return GameObject.GetComponent<MeshCollider>(); } }

        private IBlock[,,] blocks;

        private MeshData MeshData { get; set; }

        private bool isDirty;

        public ChunkEntity(Vector3 position, Quaternion rotation)
        {
            Position = position;

            MeshData = new MeshData();

            Initialise(GameManager.Instance.ChunkPrefab);
            GameObject.transform.position = position;
            GameObject.transform.rotation = rotation;

            blocks = new IBlock[ChunkSize, ChunkSize, ChunkSize];

            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    for (int z = 0; z < ChunkSize; z++)
                    {
                        SetBlock(new AirBlock(), x, y, z);
                    }
                }
            }

            SetBlock(new DirtBlock(), 3, 5, 2);

            UpdateChunk();
        }

        public override void Update(float dt)
        {
            if (isDirty)
            {
                UpdateChunk();
                isDirty = false;
            }
        }

        public void UpdateChunk()
        {
            MeshData.Reset();

            for (int x = 0; x < ChunkSize; x++)
            {
                for (int y = 0; y < ChunkSize; y++)
                {
                    for (int z = 0; z < ChunkSize; z++)
                    {
                        MeshData.AddBlock(blocks[x, y, z]);
                    }
                }
            }

            MeshFilter.mesh.Clear();
            MeshFilter.mesh.vertices = MeshData.Vertices.ToArray();
            MeshFilter.mesh.triangles = MeshData.Triangles.ToArray();
            MeshFilter.mesh.uv = MeshData.UVs.ToArray();
            MeshFilter.mesh.RecalculateNormals();
        }

        public void SetBlock(IBlock block, int x, int y, int z)
        {
            blocks[x, y, z] = block;
            block.SetPosition(this, new Vector3(x, y, z));
            isDirty = true;
        }

        public IBlock GetBlock(int x, int y, int z)
        {
            if (InRange(x) && InRange(y) && InRange(z))
            {
                return blocks[x, y, z];
            }

            return TerrainComponent.GetBlock((int)Position.x + x, (int)Position.y + y, (int)Position.z + z);
        }

        public IBlock GetBlock(Vector3 chunkPosition)
        {
            return GetBlock((int)chunkPosition.x, (int)chunkPosition.y, (int)chunkPosition.z);
        }

        private bool InRange(int index)
        {
            return index > 0 && index < ChunkSize;
        }
    }
}
