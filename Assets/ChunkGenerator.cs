using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject terrainGeneratorPrefab;

    public int sizeX = 1;
    public int sizeY = 1;
    public int sizeZ = 1;


    private void OnValidate()
    {
        if (sizeX < 1) sizeX = 1;
        if (sizeY < 1) sizeY = 1;
        if (sizeZ < 1) sizeZ = 1;
    }

    public void Generate()
    {
        Debug.Log("RESTART: Chunk Gen");

        // Remove children.
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int dx = 0; dx < sizeX; dx++)
            for (int dy = 0; dy < sizeX; dy++)
                for (int dz = 0; dz < sizeX; dz++)
                    CreateChunk(dx, dy, dz);
    }

    public void CreateChunk(int dx, int dy, int dz)
    {
        int genSize = terrainGeneratorPrefab.GetComponent<TerrainGenerator>().size;
        Vector3 position = new Vector3(dx * genSize, dy * genSize, dz * genSize);

        GameObject g = Instantiate(terrainGeneratorPrefab, position, Quaternion.identity, transform);
        g.name = $"TerrainGen-{dx}-{dy}-{dz}";

        TerrainGenerator gen = g.GetComponent<TerrainGenerator>();
        gen.offsetX = position.x;
        gen.offsetY = position.y;
        gen.offsetZ = position.z;
        gen.size++;
        gen.Generate();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
