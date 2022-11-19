using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysGenerator : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public GameObject ColPrefab;
    public int ColsAmount;
    public int EnemysPerCol;
    public int TotalEnemys;

    private Vector2 enemyColliderSize;

    EnemyGrid enemyGrid;
    // Start is called before the first frame update
    void Start()
    {
        TotalEnemys = ColsAmount * EnemysPerCol;
        enemyColliderSize = EnemyPrefab.GetComponent<SpriteRenderer>().bounds.size;

        enemyGrid = gameObject.GetComponent<EnemyGrid>();
        GenerateGrid();
        Vector3 startingPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.9f));   //put it in the upper middle of the screen
        startingPosition.z = 0;
        gameObject.transform.position = startingPosition;
        GameManager.Instance.enemysLeft = TotalEnemys;
    }
    private void GenerateGrid()
    {
        for (int colIndex = 0; colIndex < ColsAmount; colIndex++)        
            GenerateCol(colIndex);        
    }
    private void GenerateCol(int colIndex)
    {
        GameObject col = Instantiate(ColPrefab, transform);
        Transform colTransform = col.transform;
        colTransform.position = new Vector2(ColsAmount - colIndex*enemyColliderSize.x*1.5f, 0);
        for (int enemyIndex = 0; enemyIndex < EnemysPerCol; enemyIndex++)        
            GenerateSingleEnemy(colTransform, enemyIndex);        
    }
    private void GenerateSingleEnemy(Transform colTransform, int enemyIndex)
    {
        Enemy enemyInstance = Instantiate(EnemyPrefab, colTransform);
        enemyInstance.transform.position = new Vector2(colTransform.position.x,  -(enemyColliderSize.y*1.5f * enemyIndex));
        enemyGrid.AddEnemy(enemyInstance);
    }    
}
