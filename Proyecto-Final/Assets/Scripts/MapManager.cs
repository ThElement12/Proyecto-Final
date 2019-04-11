using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject fightingFloor, firstFloor, lastFloor, normalFloor, Boss;
    public float floorsize;

    Dictionary<char, GameObject> cellPrefabs;
    GameObject _newCell;
    XmlDocument level;

    private void Awake()
    {
        cellPrefabs = new Dictionary<char, GameObject>
        {
            {'_', fightingFloor },
            {'-', firstFloor },
            {'/', lastFloor },
            {'*', normalFloor },
            {'=', Boss }
            //{'E', fightingWallexit },
            //{';', lastWall },
            //{'f', firstWall },
            //{' ', nullWall }
        }; 
    }

    // Start is called before the first frame update
    void Start()
    {
        level = new XmlDocument();
        level.LoadXml(Resources.Load<TextAsset>("level" + ControlJuego.level.ToString()).text);
        LoadMap();
        
    }
    private void LoadMap()
    {
        int j, i = 0;
        float position = floorsize;
        foreach(XmlNode actualRow in level.SelectNodes("//Level/Map/Row"))
        {
            j = 0;
            i--;
            foreach(char actualCell in actualRow.InnerText)
            {
                //position = count * floorsize;

                _newCell = Instantiate(cellPrefabs[actualCell], new Vector3(j, i, cellPrefabs[actualCell].transform.position.z), Quaternion.identity);
                _newCell.transform.Translate(new Vector3(floorsize * j, 0));

                //count++;
                j++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
