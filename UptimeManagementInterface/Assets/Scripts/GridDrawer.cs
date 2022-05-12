using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    List<GameObject> cells = new List<GameObject>();
    [SerializeField] GameObject cellPrefab;
    [Space,Space]
    [SerializeField] Vector2 gridSize = Vector2.one * 10;
    [SerializeField] Vector2 lineSpaceing = Vector2.one;

    void DrawGrid()
    {
        #region Guards

        if (lineSpaceing.x <= 0 || lineSpaceing.y <= 0)
            return;

        if (gridSize.x <= 0 || gridSize.y <= 0)
            return;

        #endregion

        if(cells.Count > 0)
            cells.ForEach(i => Destroy(i));

        //Note: transforms and positions are local.

        //Top edgeposes
        for (float x = 0; x < gridSize.x; x += lineSpaceing.x)
        {
            for (float y = 0; y < gridSize.y; y += lineSpaceing.y)
            {
                var cell = Instantiate(cellPrefab, transform);
                cell.transform.localPosition = new Vector3(x, y);
                cell.transform.localScale = new Vector3(lineSpaceing.x, lineSpaceing.y, 1);

                cells.Add(cell);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawGrid();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x + gridSize.x / 2, transform.position.y + gridSize.y / 2, transform.position.z), gridSize);
    }
}
