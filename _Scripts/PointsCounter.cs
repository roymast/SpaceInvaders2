using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    int pointsCount;
    // Start is called before the first frame update
    void Start()
    {
        pointsCount = 0;
        pointsText.text = "Points: " + pointsCount.ToString();                
    }

    public void AddPoints(int pointsToAdd)
    {
        pointsCount += pointsToAdd;
        pointsText.text = ("Points: " + pointsCount.ToString()).ToString();
    }

}
