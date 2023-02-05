using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerLogic : MonoBehaviour
{
    public float maxFallDistance = 20f;
    public Animator handAnimator;
    
    private RootsAttractor attractor;
    private GameObject detractor;
    private FirstPersonController fpsController;

    // Animation tracking
    private bool handup = false;

    // Fall Tracking
    private bool lastOnGround = true;
    private float lastHeight;

    private Vector2 m_Look;
    private Vector2 m_Move;
    private bool m_Fire;
    private bool m_Aim;

    private void Start()
    {
        attractor = GameManager.S.rootsAttractor.GetComponent<RootsAttractor>();
        detractor = GameManager.S.rootsDetractor;
        fpsController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        // Fall detection
        if (!fpsController.Grounded)
        {
            SoundManager.S.PlayerWalkingSoundOff(); 
            if (lastOnGround)
            {
                lastHeight = transform.position.y;
                lastOnGround = false;
            }
            else
            {
                float fallDistance = Mathf.Abs(lastHeight - transform.position.y);
                if (fallDistance > maxFallDistance)
                {
                    ReturnToCheckpoint();
                }
            }
        }
        else if (fpsController.Grounded)
        {
            if (!lastOnGround)
            {
                // Landing sound
                SoundManager.S.PlayerLandSound();
            }
            lastOnGround = true;
        }
    }

    private void ReturnToCheckpoint()
    {
        GameManager.S.blackFade.gameObject.SetActive(true);
        GameManager.S.blackFade.ResetFade();
        transform.position = GameManager.S.lastCheckpoint.transform.position;
    }

    private IEnumerator SummonDetractor()
    {
        yield return new WaitForSeconds(0.15f);
        detractor.SetActive(!detractor.activeSelf);
    }

    private IEnumerator HandUpDown()
    {
        handAnimator.Play("Base Layer.hand up");
        yield return new WaitForSeconds(0.2f);
        handAnimator.Play("Base Layer.hand down");
    }

    // Input functions
    public void OnFire()
    {
        // Make sure detractor is off to fire
        if (detractor.activeSelf == false)
        {
            //Instantiate(projectilePrefab);
            Debug.Log("Fire");

            // Fire attractor
            attractor.FireAttractor();

            SoundManager.S.AttractorFireSound();

            // Update ammo
            //GameManager.S.ammoCount--;
            //GameManager.S.UpdateTextUI();

            //StartCoroutine(HandUpDown());
        }
    }

    public void OnAim()
    {
        // Activate detractor
        if (attractor.state == RootsAttractor.AttractorState.off)
        {
            Debug.Log("Detract");
            StartCoroutine(SummonDetractor());
            if (!handup)
            {
                handup = true;
                //handAnimator.Play("Base Layer.hand up");
                SoundManager.S.DectractorOnSound();
            }
            else
            {
                handup = false;
                //handAnimator.Play("Base Layer.hand down");
                SoundManager.S.DectractorOffSound();

            }
        }
        else
        {
            // play a null sound
        }
    }

    // 'Move' input action has been triggered.
    public void OnMove(InputValue value)
    {
        m_Move = value.Get<Vector2>();
        //Debug.Log("Moving");
        if (fpsController.Grounded)
        {
            SoundManager.S.PlayerWalkingSoundOn();
        }

    }

    // 'Look' input action has been triggered.
    public void OnLook(InputValue value)
    {
        m_Look = value.Get<Vector2>();
        //Debug.Log("Look");
    }

    public void OnQuit() //Temp Solution
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void OnUpdate()
    {
        // Update transform from m_Move and m_Look
    }
}
