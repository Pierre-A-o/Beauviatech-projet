using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeContents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        GetComponent<GridLayoutGroup>().constraintCount = 1;
        if (gameObject.transform.childCount > 0)
        {
            GetComponent<GridLayoutGroup>().cellSize = new Vector2(500f, 335 / gameObject.transform.childCount);
        } else
        {
            GetComponent<GridLayoutGroup>().cellSize = new Vector2(500f, 335);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
