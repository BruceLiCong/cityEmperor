using UnityEngine;
using System.Collections;

public class levelGrid : MonoBehaviour {

    public static levelGrid grid;
    public GameObject terrainPrefab;

    private int _sizeX;
    private int _sizeY;
    private int _sizeOfTerrain = 1;
    private GameObject[,] _gameGrid;

    void Awake()
    {
        if (grid == null)
        {
            DontDestroyOnLoad(gameObject);
            grid = this;
            //initialize it
            readLevel();
        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
    private void readLevel()
    {
        string levelInfo = System.IO.File.ReadAllText("levelFile.txt");
        JSONObject json = new JSONObject(levelInfo);

        _sizeX = (int)json["x"].n;
        _sizeY = (int)json["y"].n;
        _gameGrid = new GameObject[_sizeX, _sizeY];

        if (json["terrainTiles"].list.ToArray().Length != 0)
        {
            foreach (JSONObject tile in json["terrainTiles"].list)
            {
                //Debug.Log(tile["x"].n + ", " + tile["y"].n + ", " + tile["isWater"].b + ", " + tile["moisture"].n);
                GameObject temp = (GameObject)Instantiate(terrainPrefab, new Vector3(tile["x"].n, tile["y"].n), new Quaternion());
                temp.GetComponent<terrainControl>().initialize((int)(tile["x"].n), (int)(tile["y"].n), tile["isWater"].b, (int)tile["moisture"].n);
                _gameGrid[(int)(tile["x"].n), (int)(tile["y"].n)] = temp;
            }
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
