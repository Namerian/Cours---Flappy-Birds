using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour
{

    private GameObject bg_tile;
    private Camera mainCamera;

    private float bg_tile_halfWidth;
    private float screen_halfWidth;

    private List<GameObject> bg_tiles;

    // Use this for initialization
    void Start()
    {
        bg_tile = Resources.Load<GameObject>("Prefabs/BG_Tile");
        mainCamera = Camera.main;

        bg_tile_halfWidth = bg_tile.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        screen_halfWidth = 8f; //mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, 0f, 0f)).x;

        bg_tiles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bg_tiles.Count > 0)
        {
            GameObject _leftTile = bg_tiles[0];
            if (_leftTile.transform.position.x < mainCamera.transform.position.x - screen_halfWidth - bg_tile_halfWidth)
            {
                bg_tiles.Remove(_leftTile);
                Destroy(_leftTile);
            }

            GameObject _rightTile = bg_tiles[bg_tiles.Count - 1];
            if (_rightTile.transform.position.x < mainCamera.transform.position.x + screen_halfWidth - bg_tile_halfWidth)
            {
                GameObject _newBG_Tile = (GameObject)Instantiate(bg_tile, this.transform, false);
                _newBG_Tile.transform.position = new Vector3(_rightTile.transform.position.x + 2f * bg_tile_halfWidth, 0f, 0f);
                bg_tiles.Add(_newBG_Tile);
            }
        }
    }

    public void OnStartGame()
    {
        bg_tiles.Clear();

        float _x = mainCamera.transform.position.x - screen_halfWidth;

        do
        {
            GameObject _newBG_Tile = (GameObject)Instantiate(bg_tile, this.transform, false);
            _newBG_Tile.transform.position = new Vector3(_x, 0f, 0f);
            bg_tiles.Add(_newBG_Tile);
            _x += bg_tile_halfWidth * 2f;
        }
        while (_x < mainCamera.transform.position.x + screen_halfWidth);
    }
}
