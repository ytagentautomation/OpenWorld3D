using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public int citySize = 5;
    public float blockSize = 40f;

    void Start()
    {
        GenerateCity();
    }

    void CreateBox(string name, Vector3 pos, Vector3 scale)
    {
        GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
        o.name = name;
        o.transform.position = pos;
        o.transform.localScale = scale;
    }

    void GenerateCity()
    {
        // Ground
        CreateBox("CityGround", Vector3.zero, new Vector3(220, 0.2f, 220));

        // Roads
        for (int i = -2; i <= 2; i++)
        {
            float p = i * blockSize;
            CreateBox("Road_X", new Vector3(0, 0.15f, p),
                new Vector3(220, 0.15f, 10));
            CreateBox("Road_Z", new Vector3(p, 0.15f, 0),
                new Vector3(10, 0.15f, 220));
        }

        // Buildings
        int id = 0;
        for (int x = -2; x <= 2; x++)
        {
            for (int z = -2; z <= 2; z++)
            {
                float px = x * blockSize + 13;
                float pz = z * blockSize + 13;
                float h = 8 + ((id % 4) * 3);

                CreateBox("Building_" + id,
                    new Vector3(px, h / 2f, pz),
                    new Vector3(18, h, 18));

                id++;
            }
        }

        // Important locations
        CreateBox("PoliceStation", new Vector3(-53, 5, -53),
            new Vector3(18, 10, 18));

        CreateBox("PetrolPump", new Vector3(53, 2, -53),
            new Vector3(18, 4, 18));

        CreateBox("ShopArea", new Vector3(-53, 3, 53),
            new Vector3(18, 6, 18));

        Debug.Log("OpenWorld3D: CITY FOUNDATION READY");
    }
}
