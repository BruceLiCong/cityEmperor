using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        centerCamera();
	}
	// Update is called once per frame
	void Update () {
	
	}
    private void centerCamera()
    {
        float xposition = (float)(Grid.grid.getSizeX() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        float yposition = (float)(Grid.grid.getSizeY() * Grid.grid.getSizeOfTerrain()) / 2 - (float)(Grid.grid.getSizeOfTerrain())/2;
        transform.position = new Vector3(xposition, yposition);
    }
}
