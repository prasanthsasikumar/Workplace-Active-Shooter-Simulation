using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VerySimplePlayerHealth : HealthManager
{
    public float health = 100f;
    public float decayFactor = 0.8f;

    public GameObject FailCanvas, mainCanvas;
    public GameManager gameManager;

    public UnityEvent onDeath;

    public override void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart, GameObject origin)
    {
        health -= damage;        
    }

    private void Update()
    {
        if (health > 0f)
        {
        }
        else if (!dead)
        {
            dead = true;
            StartCoroutine("ReloadScene");
        }
    }

    private IEnumerator ReloadScene()
    {
        gameManager.ShowFailCanvas();
        SendMessage("PlayerDead", SendMessageOptions.DontRequireReceiver);
        onDeath.Invoke();
        yield return new WaitForSeconds(0.5f);
        AudioListener.pause = true;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
        Camera.main.cullingMask = LayerMask.GetMask();

        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
