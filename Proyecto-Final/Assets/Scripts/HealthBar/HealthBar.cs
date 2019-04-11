using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Text ratioText;

    
    private float hitpoints;
    private float maxhitpoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        hitpoints = gameObject.GetComponent<CharacterMovement>().Vida;
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        hitpoints = gameObject.GetComponent<CharacterMovement>().Vida;
        float ratio = hitpoints / maxhitpoints;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + "%";
    }

}
