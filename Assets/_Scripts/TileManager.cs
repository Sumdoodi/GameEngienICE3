using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    //Declares tile(game object) queue
    private Queue<GameObject> tilePool;

    public int maxTiles;

    // Start is called before the first frame update
    void Awake()
    {
        //Initialize Tile Pool
        tilePool = new Queue<GameObject>();
        BuildTilePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildTilePool()
    {
        for(var i = 0; i < maxTiles; i++)
        {
            //Enqueue tiles from factory
            var tempTile = TileFactory.Instance().CreateTile();
            tempTile.SetActive(false);
            tilePool.Enqueue(tempTile);
        }
    }
    public GameObject GetTile()
    {
        var tempTile = tilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    public void ReturnTile(GameObject tile) 
    {
        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }
}
