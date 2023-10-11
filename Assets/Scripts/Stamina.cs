using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandartAssets.Characters.FirstPerson;

public class Stamina : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float jumpCost = 20.0f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Speed Parameters")]
    [SerializeField] private float slowedRunSpeed = 2.0f;
    [SerializeField] private float normalRunSpeed = 5.33f;

    private Moviment _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<Moviment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!weAreSprinting)
        {
            if(playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;

                if(playerStamina >= maxStamina)
                {
                    //set to normal speed
                    _characterController.SetRunSpeed(normalRunSpeed);
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

            if(playerStamina <= 0)
            {
                hasRegenerated = false;
                //slow the player
                _characterController.SetRunSpeed(slowedRunSpeed);
            }
        }
    }
    public void StaminaJump()
    {
        if(playerStamina >+ (maxStamina * jumpCost / maxStamina))
        {
            playerStamina -= jumpCost;

        }
    }
    void UpdateStamina()
    {

    }

}
