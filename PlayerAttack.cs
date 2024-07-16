using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    Punch1,
    Punch2,
    Punch3,
    Kick1,
    Kick2

}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_anim;

    private bool activateTimerToReset;

    private float default_combo_timer = 0.4f;
    private float current_combo_timer;

    private ComboState current_combo_State;

    void Awake()
    {
        player_anim = GetComponentInChildren<CharacterAnimation>();
    }

    void Start()
    {
        current_combo_timer = default_combo_timer;
        current_combo_State = ComboState.NONE;
    }

    void Update()
    {
       ComboAttacks(); 
       ResetComboState();
    }

    void ComboAttacks()
    {
       if(Input.GetKeyDown(KeyCode.Z))
       {
        if(current_combo_State == ComboState.Punch3 || current_combo_State == ComboState.Kick1 || current_combo_State == ComboState.Kick2 )
        return;

       current_combo_State++;
       activateTimerToReset = true ;
       current_combo_timer = default_combo_timer;

       if(current_combo_State == ComboState.Punch1){
        player_anim.Punch1();
       }

       if(current_combo_State == ComboState.Punch2){
        player_anim.Punch2();
       }

       if(current_combo_State == ComboState.Punch3){
        player_anim.Punch3();
       }
       }

       if(Input.GetKeyDown(KeyCode.X))
       {

        if(current_combo_State == ComboState.Kick2 || current_combo_State == ComboState.Punch3)
       { return;
       }
        if(current_combo_State == ComboState.NONE || current_combo_State == ComboState.Punch1 || current_combo_State == ComboState.Punch2)
        {
            current_combo_State = ComboState.Kick1;
        }

      else if(current_combo_State == ComboState.Kick1)
      {
        current_combo_State++;
      }

      activateTimerToReset = true;
      current_combo_timer = default_combo_timer; 

      if(current_combo_State == ComboState.Kick1)
      {
        player_anim.Kick1();
      }

       if(current_combo_State == ComboState.Kick2)
      {
        player_anim.Kick2();
      }
       }
    }

    void ResetComboState()
    {
       if(activateTimerToReset)
       current_combo_timer -= Time.deltaTime;
       if(current_combo_timer  <= 0f)
        {
           current_combo_State = ComboState.NONE;
           activateTimerToReset = false;
           current_combo_timer = default_combo_timer;
        }
    }

}
