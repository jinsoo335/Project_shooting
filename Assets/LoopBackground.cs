using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

public class LoopBackground : MonoBehaviour
{
    public Tilemap[] grounds = new Tilemap[9];
    public int sellSize = 9;

    private void Start()
    {
        resetArray();
    }


    private void OnTriggerExit2D(Collider2D cols)
    {
        if (!cols.gameObject.CompareTag("Player")) return;
        
    }

    public void tileMove(int index)
    {
        //grounds = new Tilemap[9];
        resetArray();

        switch (index)
        {
            case 0:
                for(int i = 0, j = 6; i < 3 && j < grounds.Length; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y + sellSize, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 3);
                    grounds[i + 3].tag = "Tile" + j;
                }
                resetArray();

                for (int i = 0, j = 2; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                { 
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x - sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 1);
                    grounds[i + 1].tag = "Tile" + (i + 2);
                }
                break;

            case 1:
                for (int i = 0, j = 6; i < 3 && j < grounds.Length; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y + sellSize, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 3);
                    grounds[i + 3].tag = "Tile" + j;
                }

                break;

            case 2:
                for (int i = 0, j = 6; i < 3 && j < grounds.Length; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y + 12, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 3);
                    grounds[i + 3].tag = "Tile" + j;
                }
                resetArray();

                for (int i = 2, j = 0; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x + sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i - 1);
                    grounds[i - 1].tag = "Tile" + (i - 2);
                }
                break;
                

            case 3:
                for (int i = 0, j = 2; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x - sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 1);
                    grounds[i + 1].tag = "Tile" + (i + 2);
                }
                break;

            case 4:
                // 항상 플레이어가 4번 위치에 있다고 가정
                break;

            case 5:
                for (int i = 2, j = 0; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x + sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i - 1);
                    grounds[i - 1].tag = "Tile" + (i - 2);
                }
                break;
                

            case 6:
                for (int i = 6, j = 0; i < grounds.Length && j < 3; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y - sellSize, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (j + 3);
                    grounds[j + 3].tag = "Tile" + j;
                }
                resetArray();

                for (int i = 0, j = 2; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x - sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i + 1);
                    grounds[i + 1].tag = "Tile" + (i + 2);
                }
                break;

            case 7:
                for (int i = 6, j = 0; i < grounds.Length && j < 3; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y - sellSize, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (j + 3);
                    grounds[j + 3].tag = "Tile" + j;
                }
                break;

            case 8:
                for (int i = 6, j = 0; i < grounds.Length && j < 3; i++, j++)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x, grounds[i].transform.position.y - sellSize, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (j + 3);
                    grounds[j + 3].tag = "Tile" + j;
                }
                resetArray();

                for (int i = 2, j = 0; i < grounds.Length && j < grounds.Length; i += 3, j += 3)
                {
                    grounds[j].transform.position = new Vector3(grounds[i].transform.position.x + sellSize, grounds[i].transform.position.y, 3);
                    grounds[j].tag = "Tile" + i;
                    grounds[i].tag = "Tile" + (i - 1);
                    grounds[i - 1].tag = "Tile" + (i - 2);
                }
                break;
            default:
                break;
        }
        resetArray();

    }

    public void resetArray()
    {
        for(int i =0; i < grounds.Length; i++)
        {
            grounds[i] = GameObject.FindGameObjectWithTag("Tile" + i).GetComponent<Tilemap>();
           
        }
    }



    
}
