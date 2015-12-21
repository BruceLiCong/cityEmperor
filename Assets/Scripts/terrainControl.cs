using UnityEngine;
using System.Collections;

public class terrainControl : MonoBehaviour {

    public Sprite dryTerrain;
    public Sprite lowMoistureTerrain;
    public Sprite highMoistureTerrain;
    public Sprite waterTerrain;

    private int _moisture;
    private int _xLocation;
    private int _yLocation;
    private bool _isWater;
    private SpriteRenderer _renderer;
	// Use this for initialization
	void Start () {
        _renderer = GetComponent<SpriteRenderer>();
        _isWater = false;
        _moisture = 0;
        reRender();
	}
    private void reRender()
    {
        if (!_isWater)
        {
            if (_moisture >= 2)
            {
                _renderer.sprite = highMoistureTerrain;
            }
            else if (_moisture >= 1)
            {
                _renderer.sprite = lowMoistureTerrain;
            }
            else
            {
                _renderer.sprite = dryTerrain;
            }
        }
        else
        {
            _renderer.sprite = waterTerrain;
        }
    }
    public void moisturize(int moisture)
    {
        _moisture += moisture;
        if (_moisture >= 2)
        {
            _moisture = 2;
        }
        reRender();
    }
    private void moistureAdjacent(int radius, int drySpots)
    {
        if (drySpots >= radius)
        {
            throw new System.ArgumentException("drySpots needs to be smaller than radius", "drySpots");
        }
        else
        {
            int initialPositionX = _xLocation - radius;
            int initialPositionY = _yLocation - radius;

            for (int i = 0; i < (radius * 2) + 1; i++)
            {
                for (int j = 0; j < (radius * 2) + 1; j++)
                {
                    if (Grid.grid.validatePosition((initialPositionX + i), (initialPositionY + j)))
                    {
                        terrainControl temp = Grid.grid.getGridElement((initialPositionX + i), (initialPositionY + j)).GetComponent<terrainControl>();
                        if (i < drySpots || i > ((radius * 2) - drySpots) || j < drySpots || j > ((radius * 2) - drySpots))
                        {
                            if (temp.getMoisture() < 1)
                            {
                                temp.moisturize(1);
                            }
                        }
                        else
                        {
                            temp.moisturize(2);
                        }
                    }
                }
            }
        }
    }
    public void setLocation(int x, int y)
    {
        _xLocation = x;
        _yLocation = y;
    }
    public int getMoisture()
    {
        return _moisture;
    }
    public void turnIntoWater()
    {
        if (!_isWater)
        {
            _isWater = true;
            Debug.Log(_xLocation + " " + _yLocation);
            reRender();
            moistureAdjacent(15, 4);
        }
    }
	// Update is called once per frame
    //void Update () {
	
    //}
}
