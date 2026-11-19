using UnityEngine;
using TMPro;
public class NewRecordScript : MonoBehaviour
{
   public TextMeshProUGUI textEl;
   void Start()
    {
        
        UpdateUI();
    }
    void UpdateUI()
    {
        int record = PlayerPrefs.GetInt("HighScore", 0);
    

textEl.text = "Record:" + record;
    }

 
}
