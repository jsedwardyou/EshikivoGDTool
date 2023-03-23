using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.TopDown.Character
{
    [Serializable]
    public class CharacterStat
    {
        // [Health]
        public float max_health;
        public float health_regen;
        public float armour;

        // [Speed]
        public float movement_speed;

        // [Attack]
        public float attack_damage;
        public float attack_speed;
        public float attack_range;
        public float critical_chance; // 0 ~ 1
        public float critical_damage;

        public static CharacterStat operator +(CharacterStat stat1, CharacterStat stat2)
        {
            CharacterStat stat = new CharacterStat();

            stat.max_health = stat1.max_health + stat2.max_health;
            stat.health_regen = stat1.health_regen + stat2.health_regen;
            stat.armour = stat1.armour + stat2.armour;

            stat.movement_speed = stat1.movement_speed + stat2.movement_speed;
            stat.attack_damage = stat1.attack_damage + stat2.attack_damage;
            stat.attack_speed = stat1.attack_speed + stat2.attack_speed;
            stat.attack_range = stat1.attack_range + stat2.attack_range;
            stat.critical_chance = stat1.critical_chance + stat2.critical_chance;
            stat.critical_damage = stat1.critical_damage + stat2.critical_damage;

            return stat;
        }

        public static CharacterStat operator -(CharacterStat stat1, CharacterStat stat2)
        {
            CharacterStat stat = new CharacterStat();

            stat.max_health = stat1.max_health - stat2.max_health;
            stat.health_regen = stat1.health_regen - stat2.health_regen;
            stat.armour = stat1.armour - stat2.armour;

            stat.movement_speed = stat1.movement_speed - stat2.movement_speed;
            stat.attack_damage = stat1.attack_damage - stat2.attack_damage;
            stat.attack_speed = stat1.attack_speed - stat2.attack_speed;
            stat.attack_range = stat1.attack_range - stat2.attack_range;
            stat.critical_chance = stat1.critical_chance - stat2.critical_chance;
            stat.critical_damage = stat1.critical_damage - stat2.critical_damage;

            return stat;
        }

        public static CharacterStat operator *(CharacterStat stat1, CharacterStat stat2)
        {
            CharacterStat stat = new CharacterStat();

            stat.max_health = stat1.max_health * stat2.max_health;
            stat.health_regen = stat1.health_regen * stat2.health_regen;
            stat.armour = stat1.armour * stat2.armour;

            stat.movement_speed = stat1.movement_speed * stat2.movement_speed;
            stat.attack_damage = stat1.attack_damage * stat2.attack_damage;
            stat.attack_speed = stat1.attack_speed * stat2.attack_speed;
            stat.attack_range = stat1.attack_range * stat2.attack_range;
            stat.critical_chance = stat1.critical_chance * stat2.critical_chance;
            stat.critical_damage = stat1.critical_damage * stat2.critical_damage;

            return stat;
        }

        public static CharacterStat operator /(CharacterStat stat1, CharacterStat stat2)
        {
            CharacterStat stat = new CharacterStat();

            stat.max_health = stat1.max_health / stat2.max_health;
            stat.health_regen = stat1.health_regen / stat2.health_regen;
            stat.armour = stat1.armour / stat2.armour;

            stat.movement_speed = stat1.movement_speed / stat2.movement_speed;
            stat.attack_damage = stat1.attack_damage / stat2.attack_damage;
            stat.attack_speed = stat1.attack_speed / stat2.attack_speed;
            stat.attack_range = stat1.attack_range / stat2.attack_range;
            stat.critical_chance = stat1.critical_chance / stat2.critical_chance;
            stat.critical_damage = stat1.critical_damage / stat2.critical_damage;

            return stat;
        }
    }

    [Serializable]
    public class FixedStat : CharacterStat
    {
        public FixedStat()
        {
            this.max_health = 0;
            this.health_regen = 0;
            this.armour = 0;

            this.movement_speed = 0;
            this.attack_damage = 0;
            this.attack_speed = 0;
            this.attack_range = 0;
            this.critical_chance = 0;
            this.critical_damage = 0;
        }
    }
    
    [Serializable]
    public class ProportionStat : CharacterStat
    {

        public ProportionStat()
        {
            this.max_health = 1;
            this.health_regen = 1;
            this.armour = 1;

            this.movement_speed = 1;
            this.attack_damage = 1;
            this.attack_speed = 1;
            this.attack_range = 1;
            this.critical_chance = 1;
            this.critical_damage = 1;
        }
    }

}
