using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
void Start()
{
    anim = GetComponent<Animator>();
}

   public void Walk(bool move)
   {
    anim.SetBool(AnimationTags.Movement,move);
   }

   public void Punch1(){
    anim.SetTrigger(AnimationTags.punch_1_trigger);
   }

    public void Punch2(){
    anim.SetTrigger(AnimationTags.punch_2_trigger);
   }

    public void Punch3(){
    anim.SetTrigger(AnimationTags.punch_3_trigger);
   }

 public void Kick1(){
    anim.SetTrigger(AnimationTags.kick_1_trigger);
   }

    public void Kick2(){
    anim.SetTrigger(AnimationTags.kick_2_trigger);
   }

//ENEMY ANIMATIONS
 
 public void EnemyAttack(int attack){

if(attack == 0)
{
    anim.SetTrigger(AnimationTags.attack_1_trigger);
}

if(attack == 1)
{
    anim.SetTrigger(AnimationTags.attack_2_trigger);
}

if(attack == 2)
{
    anim.SetTrigger(AnimationTags.attack_3_trigger);
}
 }

 public void play_idleAnimation()
 {
    anim.Play(AnimationTags.idle_animation);
 }

 public void KnockDown()
 {
    anim.SetTrigger(AnimationTags.knock_down_trigger);
 }

 public void StandUp()
 {
    anim.SetTrigger(AnimationTags.stand_up_trigger);
 }

 public void Hit()
 {
    anim.SetTrigger(AnimationTags.hit_trigger);
 }

 public void Death()
 {
    anim.SetTrigger(AnimationTags.death_trigger);
 }
}
