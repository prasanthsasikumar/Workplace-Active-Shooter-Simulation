using EnemyAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public InputActionReference menuButton;
    public GameObject optionsCanvas, statsCanvas, sucessCanvas, failCanvas, leftController, rightController;
    public GameObject RifleEnemy;
    public GameObject hidePoints, runPoints, FightPoints;
    public AudioSource shooterStart;
    public RecordPlayerMovement recorder;
    public UnityEvent onSuccess, onAttempt;

    public GameObject player, destination;
    public LineRenderer lineRenderer;
    public KillEnemy enemyHead;
    private float perceptionRadius;

    private float TimeDelayBetweenToogle = 0.5f;
    private float LastTimeFrame = 0f;

    private void Start()
    {
        sucessCanvas.SetActive(false);
        failCanvas.SetActive(false);
        perceptionRadius = RifleEnemy.GetComponent<StateController>().perceptionRadius;
        RifleEnemy.SetActive(false);

    }
    private void OnEnable()
    {
        menuButton.action.Enable();
    }

    private void OnDisable()
    {
        menuButton.action.Disable();
    }

    public void ShowStatsCanvas()
    {
        if ((Time.time - LastTimeFrame) < TimeDelayBetweenToogle) return;

        if (statsCanvas.activeSelf) HideStats();
        else ShowStats();

        LastTimeFrame = Time.time;
    }

    public void ShooterStart()
    {
        RifleEnemy.SetActive(true);
        shooterStart.GetComponent<AudioSource>().Play();
        ShowOptionsMenu();
        onAttempt.Invoke();
    }

    public void HideOptionsMenu()
    {
        optionsCanvas.SetActive(false);
        disableRayInteraction();
    }

    public void ShowOptionsMenu()
    {
        optionsCanvas.SetActive(true);
        enableRayInteraction();
    }

    public void HideStats()
    {
        statsCanvas.SetActive(false);
        disableRayInteraction();
    }

    public void ShowStats()
    {
        statsCanvas.SetActive(true);
        enableRayInteraction();
    }

    public void HideSucessCanvas()
    {
        sucessCanvas.SetActive(false);
        disableRayInteraction();
    }

    public void ShowSucessCanvas()
    {
        sucessCanvas.SetActive(true);
        enableRayInteraction();
        recorder.finishedRecording = true;
        onSuccess.Invoke();
    }

    public void HideFailCanvas()
    {
        failCanvas.SetActive(false);
        disableRayInteraction();
    }

    public void ShowFailCanvas()
    {
        failCanvas.SetActive(true);
        enableRayInteraction();
    }

    public void enableRayInteraction()
    {
        leftController.GetComponent<XRInteractorLineVisual>().enabled = true;
        leftController.GetComponent<XRRayInteractor>().enabled = true;
        rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
        rightController.GetComponent<XRRayInteractor>().enabled = true;
    }

    public void disableRayInteraction()
    {
        leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
        leftController.GetComponent<XRRayInteractor>().enabled = false;
        rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
        rightController.GetComponent<XRRayInteractor>().enabled = false;
    }

    private void Update()
    {        
        if (menuButton.action.ReadValue<float>() == 1)
        {
            ShowStatsCanvas();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SetupforRun()
    {
        HideOptionsMenu();
        recorder.isRecording = true;
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in runPoints.transform)
        {
            wayPoints.Add(child);
        }
        RifleEnemy.GetComponent<StateController>().patrolWayPoints = wayPoints;
    }

    public void SetupforHide()
    {
        HideOptionsMenu();
        recorder.isRecording = true;
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in hidePoints.transform)
        {
            wayPoints.Add(child);
        }
        RifleEnemy.GetComponent<StateController>().patrolWayPoints = wayPoints;
    }

    public void SetupforFight()
    {
        HideOptionsMenu();
        recorder.isRecording = true;
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in FightPoints.transform)
        {
            wayPoints.Add(child);
        }
        RifleEnemy.GetComponent<StateController>().patrolWayPoints = wayPoints;
        RifleEnemy.GetComponent<StateController>().perceptionRadius = 0f;
        enemyHead.isActive = true;
    }
}
