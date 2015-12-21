using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public static Grid grid;

    //Public variables
    public int initialSizeX = 10;
    public int initialSizeY = 10;
    public GameObject terrainPrefab;
    //Private variables
    private int _sizeX;
    private int _sizeY;
    private int _sizeOfTerrain = 1;
    private GameObject[,] _gameGrid;
	// Use this for initialization
    void Awake()
    {
        if (grid == null)
        {
            DontDestroyOnLoad(gameObject);
            grid = this;
            //initialize it
            _sizeX = initialSizeX;
            _sizeY = initialSizeY;
            _gameGrid = new GameObject[_sizeX, _sizeY];
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    _gameGrid[i, j] = (GameObject)Instantiate(terrainPrefab, new Vector3((i * _sizeOfTerrain), (j * _sizeOfTerrain)), new Quaternion());
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int getSizeX()
    {
        return _sizeX;
    }
    public int getSizeY()
    {
        return _sizeY;
    }
    public int getSizeOfTerrain()
    {
        return _sizeOfTerrain;
    }
    
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
