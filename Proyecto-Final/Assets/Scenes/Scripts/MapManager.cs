using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject enemyGen, fightingWallenter, fightingWallexit, lastWall, firstWall, nullWall;
    public GameObject floor, firstFloor, lastFloor;
    public float floorsize;

    Dictionary<char, GameObject> cellPrefabs;
    GameObject _newCell;
    XmlDocument level;

    private void Awake()
    {
        cellPrefabs = new Dictionary<char, GameObject>
        {
            {'_', floor },
            {'-', firstFloor },
            {'/', lastFloor },
            {'*', fightingWallenter },
            {'E', fightingWallexit },
            {';', lastWall },
            {'f', firstWall },
            {' ', nullWall }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        level = new XmlDocument();
        level.LoadXml(Resources.Load<TextAsset>("level1").text);
        LoadMap();
        
    }
    private void LoadMap()
    {
        int j, i = 0, count = 0;
        float position = floorsize;
        foreach(XmlNode actualRow in level.SelectNodes("//Level/Map/Row"))
        {
            j = 0;
            i--;
            foreach(char actualCell in actualRow.InnerText)
            {
                position = count * floorsize;
                
                if (cellPrefabs[actualCell] == firstWall || cellPrefabs[actualCell] == nullWall || cellPrefabs[actualCell] == lastWall)
                {
                    _newCell = Instantiate(cellPrefabs[actualCell], new Vector3(j, i, cellPrefabs[actualCell].transform.position.z), Quaternion.identity);
                    _newCell.transform.Translate(new Vector3(_newCell.transform.position.x + 2.53f + position, _newCell.transform.position.y - 5f));
                }

                else if(cellPrefabs[actualCell] == fightingWallenter)
                {
                    _newCell = Instantiate(cellPrefabs[actualCell], new Vector3(j, i, cellPrefabs[actualCell].transform.position.z), Quaternion.identity);
                    _newCell.transform.Translate(new Vector3(_newCell.transform.position.x + position - 21,_newCell.transform.position.y - 5f));
                    Instantiate(enemyGen, new Vector3(_newCell.transform.position.x + 1, _newCell.transform.position.y), Quaternion.identity);
                }
                else if(cellPrefabs[actualCell] == fightingWallexit)
                {
                    _newCell = Instantiate(cellPrefabs[actualCell], new Vector3(j, i, cellPrefabs[actualCell].transform.position.z), Quaternion.identity);
                    _newCell.transform.Translate(new Vector3(_newCell.transform.position.x + position + 21, _newCell.transform.position.y - 5f));
                    Instantiate(enemyGen, new Vector3(_newCell.transform.position.x - 1, _newCell.transform.position.y), Quaternion.identity);
                }
                else
                {
                    _newCell = Instantiate(cellPrefabs[actualCell], new Vector3(j, i, cellPrefabs[actualCell].transform.position.z), Quaternion.identity);
                    _newCell.transform.Translate(new Vector3(floorsize * j, 0));
                }
                count++;
                j++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
