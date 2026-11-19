using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;
public class MoveScript : MonoBehaviour
{
   
    public float JumpForce;
    private Rigidbody2D rb;
    private bool jumpinput;
    private bool isDead = false;
      

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            jumpinput = true;
          
        }

    }
    void FixedUpdate()
    {
        


if (jumpinput == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

          jumpinput = false;
        }

    }

private void OnCollisionEnter2D(Collision2D other)
    {

        int finalScore = TextScoreScript.finalScore; // берет текущее на момент столкновения количесто очков

         if (other.gameObject.CompareTag("Enemy") && !isDead)
    {
        isDead = true; // Блокируем повторный вход, если физика сработает дважды за кадр
        
        Debug.Log("Вы проиграли");
        
          

           if (finalScore > PlayerPrefs.GetInt("HighScore", 0)) // проверяет, больше ли текущее количество очков, записаного значения
        {
            PlayerPrefs.SetInt("HighScore", finalScore); // если текущее значение больше заменяем прошлый рекорд на новый
            PlayerPrefs.Save(); // принудительно сохраняем
        }
        

        // запускаем смену сцены
        SceneManager.LoadScene(2);
       
    }


    }


}