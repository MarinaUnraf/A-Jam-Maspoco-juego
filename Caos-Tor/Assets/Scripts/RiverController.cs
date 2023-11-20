using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RiverController : MonoBehaviour
{
    public Tilemap riverTilemap;
    public TileBase riverTile;
    public TileBase obstacleTile;

    public int tilesToMoveHorizontal = 1;
    public int tilesToMoveVertical = 5;
    public float delayBetweenTiles = 0.5f;
    public Vector3Int startCellPosition = new Vector3Int(0, 0, 0);
    public bool moveVerticallyFirst = true; // Nueva variable

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
            // Si se mueve verticalmente primero, cambia la dirección a vertical
            flowDirectionX = 0;
            flowDirectionY = tilesToMoveVertical > 0 ? 1 : -1;

            // Desplaza el río en la dirección vertical primero
            for (int i = 0; i < Mathf.Abs(tilesToMoveVertical); i++)
            {
                Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
                PlaceRiverTile(targetPosition);
                startCellPosition = targetPosition;
                yield return new WaitForSeconds(delayBetweenTiles);
            }

            // Cambia la dirección a horizontal
            flowDirectionX = tilesToMoveHorizontal > 0 ? 1 : -1;
            flowDirectionY = 0;
        }
        else
        {
            // Si se mueve horizontalmente primero, cambia la dirección a horizontal
            flowDirectionX = tilesToMoveHorizontal > 0 ? 1 : -1;
            flowDirectionY = 0;
        }

        // Desplaza el río en la dirección horizontal
        for (int i = 0; i < tilesToMoveHorizontal; i++)
        {
            Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
            PlaceRiverTile(targetPosition);
            startCellPosition = targetPosition;
            yield return new WaitForSeconds(delayBetweenTiles);
        }

        // Si se mueve verticalmente después, cambia la dirección a vertical
        if (!moveVerticallyFirst)
        {
            flowDirectionX = 0;
            flowDirectionY = tilesToMoveVertical > 0 ? 1 : -1;

            // Desplaza el río en la dirección vertical
            for (int i = 0; i < Mathf.Abs(tilesToMoveVertical); i++)
            {
                Vector3Int targetPosition = startCellPosition + new Vector3Int(flowDirectionX, flowDirectionY, 0);
                PlaceRiverTile(targetPosition);
                startCellPosition = targetPosition;
                yield return new WaitForSeconds(delayBetweenTiles);
            }
        }
    }

    private void PlaceRiverTile(Vector3Int position)
    {
        riverTilemap.SetTile(position, riverTile);

        if (obstacleTile != null && riverTilemap.GetTile(position) == null)
        {
            riverTilemap.SetTile(position, obstacleTile);
        }
    }
}
