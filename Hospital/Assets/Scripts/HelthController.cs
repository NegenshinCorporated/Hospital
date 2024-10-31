using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelthController : MonoBehaviour
{
    private float startHP = 100;
    private float minHP = 0;
    private float hp;
    public TMPro.TextMeshProUGUI hpText;
    void Start()
    {
        hp = startHP;
        hpText.text = $"HP: {hp}";
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= minHP)
        {
            SceneManager.LoadScene(0);
        }
        if (hp >= startHP)
        {
            hp = startHP;
        }
        hpText.text = $"HP: {hp}";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Virus"))
        {
            hp -= 20;
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            hp += 10;
            Destroy(collision.gameObject);
        }
    }
}
