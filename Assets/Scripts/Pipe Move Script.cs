using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    void Update()
    {
        // МАКСИМАЛЬНО ПРОСТО: берем актуальную скорость напрямую из скрипта спавнера
        float speed = PipeSpawnerScript.CurrentPipeSpeed;

        // Двигаем трубу с этой скоростью
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        // Уничтожаем, если улетела за экран
        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }
}

