using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float jumpCost = 20;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Speed Parameters")]
    [SerializeField] private float slowedRunSpeed = 2.0f;
    [SerializeField] private float normalRunSpeed = 5.0f;

    [Header("Stamina UI Parameters")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private CharacterMovement playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!weAreSprinting)
        {
            if(playerStamina<= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if(playerStamina >= maxStamina)
                {
                    //set to normal speed
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;

                }
            }
        }        
    }
    public void Sprinting()
    {
        if(hasRegenerated)
        {
            weAreSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if(playerStamina <= 0)
            {
                hasRegenerated = false;
                //slow the player
                sliderCanvasGroup.alpha = 0;
            }
        }
    }
    public void StaminaJump()
    {
        if(playerStamina >= (maxStamina * jumpCost / maxStamina))
        {
            playerStamina -= jumpCost;
            //allow the player to jump
            UpdateStamina(1);
        }
    }
    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if(value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
