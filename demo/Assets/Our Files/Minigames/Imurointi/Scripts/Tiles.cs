using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    private GameObject[][] tiles = new GameObject[14][];
    [SerializeField]
    private GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        //Luodaan pelikenttä (vakiona likaiset ruudut)
        for(int x = 0; x < 14; x++)
        {
            tiles[x] = new GameObject[10];
            for(int y = 0; y < 10; y++)
            {
                tiles[x][y] = Instantiate(tile);
                tiles[x][y].transform.position = new Vector3(x, y, 0);
            }
        }
        //Muutetaan ulkoreunat seiniksi
        for(int i = 0; i < 14; i++)
        {
            tiles[i][0].GetComponent<Tile>().changeType(0);
            tiles[i][9].GetComponent<Tile>().changeType(0);
        }
        for(int j = 0; j < 10; j++)
        {
            tiles[0][j].GetComponent<Tile>().changeType(0);
            tiles[13][j].GetComponent<Tile>().changeType(0);
        }

        //Kasataan loppu kenttä, x kasvaa oikealle, y ylöspäin
        tiles[1][8].GetComponent<Tile>().changeType(0);
        tiles[2][8].GetComponent<Tile>().changeType(0);
        tiles[4][8].GetComponent<Tile>().changeType(0);
        tiles[5][8].GetComponent<Tile>().changeType(0);
        tiles[6][8].GetComponent<Tile>().changeType(0);
        tiles[7][8].GetComponent<Tile>().changeType(0);
        tiles[8][8].GetComponent<Tile>().changeType(0);
        tiles[9][8].GetComponent<Tile>().changeType(0);
        tiles[10][8].GetComponent<Tile>().changeType(0);
        tiles[11][8].GetComponent<Tile>().changeType(0);
        tiles[12][8].GetComponent<Tile>().changeType(0);

        tiles[9][7].GetComponent<Tile>().changeType(0);
        tiles[10][7].GetComponent<Tile>().changeType(0);
        tiles[11][7].GetComponent<Tile>().changeType(0);
        tiles[12][7].GetComponent<Tile>().changeType(0);

        tiles[1][4].GetComponent<Tile>().changeType(0);
        tiles[2][4].GetComponent<Tile>().changeType(0);
        tiles[5][4].GetComponent<Tile>().changeType(0);
        tiles[6][4].GetComponent<Tile>().changeType(0);
        tiles[9][4].GetComponent<Tile>().changeType(0);
        tiles[10][4].GetComponent<Tile>().changeType(0);
        tiles[11][4].GetComponent<Tile>().changeType(0);
        tiles[12][4].GetComponent<Tile>().changeType(0);

        tiles[1][3].GetComponent<Tile>().changeType(0);
        tiles[2][3].GetComponent<Tile>().changeType(0);
        tiles[9][3].GetComponent<Tile>().changeType(0);
        tiles[10][3].GetComponent<Tile>().changeType(0);
        tiles[11][3].GetComponent<Tile>().changeType(0);
        tiles[12][3].GetComponent<Tile>().changeType(0);

        tiles[1][2].GetComponent<Tile>().changeType(0);
        tiles[2][2].GetComponent<Tile>().changeType(0);
        tiles[9][2].GetComponent<Tile>().changeType(0);
        tiles[10][2].GetComponent<Tile>().changeType(0);
        tiles[11][2].GetComponent<Tile>().changeType(0);
        tiles[12][2].GetComponent<Tile>().changeType(0);

        tiles[1][1].GetComponent<Tile>().changeType(0);
        tiles[2][1].GetComponent<Tile>().changeType(0);
        tiles[5][1].GetComponent<Tile>().changeType(0);
        tiles[6][1].GetComponent<Tile>().changeType(0);
        tiles[9][1].GetComponent<Tile>().changeType(0);
        tiles[10][1].GetComponent<Tile>().changeType(0);
        tiles[11][1].GetComponent<Tile>().changeType(0);
        tiles[12][1].GetComponent<Tile>().changeType(0);
    }
}
