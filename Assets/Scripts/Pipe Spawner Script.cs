using System.Collections;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    [Header("Настройки спавна")]
    [SerializeField] private GameObject pipe;
    [SerializeField] private float startExpectation = 2.5f; // Начальное время между трубами
    [SerializeField] private float minExpectation = 1.0f;   // Быстрее этого трубы спавниться не будут
    [SerializeField] private float spawnSpeedUpStep = 0.03f; // На сколько уменьшать ожидание с каждой трубой

    [Header("Настройки скорости труб")]
    [SerializeField] private float startPipeSpeed = 5f;     // Начальная скорость движения труб
    [SerializeField] private float maxPipeSpeed = 12f;      // Максимальная скорость движения труб
    [SerializeField] private float speedUpStep = 0.1f;      // На сколько ускорять движение с каждой трубой

    // СТАТИЧЕСКАЯ ПЕРЕМЕННАЯ (ее видит скрипт PipeMoveScript)
    public static float CurrentPipeSpeed; 

    private float currentExpectation;

    private void Start()
    {
        // Задаем стартовые значения при запуске сцены
        currentExpectation = startExpectation;
        CurrentPipeSpeed = startPipeSpeed; 
        
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // Небольшая пауза на старте, чтобы игрок успел среагировать
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            // 1. Создаем трубу
            GameObject pipeobj = Instantiate(pipe);
            pipeobj.transform.position = transform.position + new Vector3(0, Random.Range(-2f, 2f), 0);

            // 2. Ускоряем темп игры (уменьшаем время ожидания)
            if (currentExpectation > minExpectation)
            {
                currentExpectation -= spawnSpeedUpStep;
                currentExpectation = Mathf.Max(currentExpectation, minExpectation);
            }

            // 3. Ускоряем движение самих труб
            if (CurrentPipeSpeed < maxPipeSpeed)
            {
                CurrentPipeSpeed += speedUpStep;
                CurrentPipeSpeed = Mathf.Min(CurrentPipeSpeed, maxPipeSpeed);
            }

            // 4. Ждем перед спавном следующей трубы
            yield return new WaitForSeconds(currentExpectation);
        }
    }
}
