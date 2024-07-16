using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags {
    public const string Movement = "Movement";

    public const string punch_1_trigger = "Punch1";
    public const string punch_2_trigger = "Punch2";
    public const string punch_3_trigger = "Punch3";

    public const string kick_1_trigger = "Kick1"; 
    public const string kick_2_trigger = "Kick2";

    public const string attack_1_trigger = "Attack1";
    public const string attack_2_trigger = "Attack2";
    public const string attack_3_trigger = "Attack3";

    public const string idle_animation = "Idle";

        public const string knock_down_trigger = "KnockDown";
        public const string stand_up_trigger = "StandUp";
        public const string hit_trigger = "Hit";    
        public const string death_trigger = "Death";
}

public class Axis {
    public const string horizontal_axis = "Horizontal";
    public const string vertical_axis = "Vertical";

}

public class Tags {
    public const string ground_tag = "Groud";
    public const string player_tag = "Player";
    public const string enemy_tag = "Enemy";

    public const string left_arm_tag = "LeftArm";
    public const string left_leg_tag = "LeftLeg";
    public const string untagged_tag = "Untagged";
    public const string main_camera_tag = "MainCamera";
    public const string health_ui = "HealthUI";
}
