using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RiverController : MonoBehaviour
{
    public Tilemap riverTilemap;
    public TileBase verticalRiverTile;
    public TileBase horizontalRiverTile;
    public TileBase cornerDownTile;
    public TileBase cornerRightTile;
    public TileBase obstacleTile;

    public int tilesToMoveHorizontal = 1;
    public int tilesToMoveVertical = 5;
    public float delayBetweenTiles = 0.5f;
    public Vector3Int startCellPosition = new Vector3Int(0, 0, 0);
    public bool moveVerticallyFirst = true;

    private void Start()
    {
        StartCoroutine(StartRiverFlow());
    }

    private IEnumerator StartRiverFlow()
    {
        int flowDirectionX = 1;
        int flowDirectionY = 0;

        if (moveVerticallyFirst)
        {
            flowDirectionX = 0;
            flowDirectionY = tilesToMoveVertical > 0 ? 1 : -1;

            for (int i = 0; i < Mathf.Abs(tilesToMoveVertical); i++)
            {
                Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
                PlaceRiverTile(targetPosition, flowDirectionX, flowDirectionY);
                startCellPosition = targetPosition;
                yield return new WaitForSeconds(delayBetweenTiles);
            }

            flowDirectionX = tilesToMoveHorizontal > 0 ? 1 : -1;
            flowDirectionY = 0;
        }
        else
        {
            flowDirectionX = tilesToMoveHorizontal > 0 ? 1 : -1;
            flowDirectionY = 0;
        }

        for (int i = 0; i < tilesToMoveHorizontal; i++)
        {
            Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
            PlaceRiverTile(targetPosition, flowDirectionX, flowDirectionY);
            startCellPosition = targetPosition;
            yield return new WaitForSeconds(delayBetweenTiles);
        }

        if (!moveVerticallyFirst)
        {
            flowDirectionX = 0;
            flowDirectionY = tilesToMoveVertical > 0 ? 1 : -1;

            for (int i = 0; i < Mathf.Abs(tilesToMoveVertical); i++)
            {
                Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
                PlaceRiverTile(targetPosition, flowDirectionX, flowDirectionY);
                startCellPosition = targetPosition;
                yield return new WaitForSeconds(delayBetweenTiles);
            }
        }
    }

    private void PlaceRiverTile(Vector3Int position, int flowDirectionX, int flowDirectionY)
    {
        if (flowDirectionY != 0)
        {
            riverTilemap.SetTile(position, verticalRiverTile);
        }
        else if (flowDirectionX != 0)
        {
            // Verifica la dirección y coloca el tile correcto
            if (flowDirectionX > 0)
            {
                if (flowDirectionY > 0)
                {
                    // Esquina inferior derecha
                    riverTilemap.SetTile(position, cornerRightTile);
                }
                else if (flowDirectionY < 0)
                {
                    // Esquina superior derecha
                    riverTilemap.SetTile(position, cornerRightTile);
                }
                else
                {
                    // Río horizontal
                    riverTilemap.SetTile(position, horizontalRiverTile);
                }
            }
            else
            {
                // Esquina inferior izquierda
                riverTilemap.SetTile(position, cornerDownTile);
            }
        }

        if (obstacleTile != null && riverTilemap.GetTile(position) == null)
        {
            riverTilemap.SetTile(position, obstacleTile);
        }
    }
}