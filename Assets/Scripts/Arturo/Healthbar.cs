using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthbarSprite;
    [SerializeField] private float _reduceSpeed = 2f;

    private float _target = 1f;
    private Camera _cam;

    // Start is called before the first frame update
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }

    void Start()
    {
        _cam = Camera.main;
    }
    void Update ()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position, _cam.transform.position);
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, _target, _reduceSpeed*Time.deltaTime);
    }
}
