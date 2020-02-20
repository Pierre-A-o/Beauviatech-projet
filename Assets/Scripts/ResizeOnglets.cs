using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeOnglets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedRowCount;
        GetComponent<GridLayoutGroup>().constraintCount = 1;
        if (gameObject.transform.childCount > 0)
        {
            GetComponent<GridLayoutGroup>().cellSize = new Vector2(614 / gameObject.transform.childCount, GetComponent<GridLayoutGroup>().cellSize.y);
        } else
        {
            GetComponent<GridLayoutGroup>().cellSize = new Vector2(614, GetComponent<GridLayoutGroup>().cellSize.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
