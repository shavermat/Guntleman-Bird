using UnityEngine;

using TMPro;

public class TextScoreScript : MonoBehaviour
{
        public TextMeshPro textElement; 
        public float SpeedScore = 2f;
   public static float Score;
    public static int finalScore;
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
   void Update()
{
    Score += Time.deltaTime * SpeedScore;

    // 1. Создаем целое число (дробь отрезается полностью)
   finalScore = Mathf.FloorToInt(Score); 

    // 2. Выводим чистый int без всяких хвостов
    textElement.text = "Score: " + finalScore.ToString();
}

}
