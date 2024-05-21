using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkelHealth : MonoBehaviour
{
    public float Value = 100;
    public RectTransform ValueRectTransform;
    public Animator Animator;
    public Mover Mover;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;



    private float _maxValue;

    public void AddHealth(float Amount)
    {
        Value += Amount;
        Value = Mathf.Clamp(Value, 0, _maxValue);
        DrawHeathlBar();
    }

    private void Start()
    {
        _maxValue = Value;

        DrawHeathlBar();
    }
    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            Death();
        }

        DrawHeathlBar();
    }

    //private void PlayerIsDead()
    //{
    //    GameplayUI.SetActive(false);
    //    GameOverScreen.SetActive(true);

    //    Animator.SetTrigger("death");

    //    GetComponent<PlayerController>().enabled = false;
    //    GetComponent<CameraRotation>().enabled = false;
    //}
    private void DrawHeathlBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Value / _maxValue, 1);
    }

    private void Death()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GetComponent<Mover>().enabled = false;
        GetComponent<CtrelaCaster>().enabled = false;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
