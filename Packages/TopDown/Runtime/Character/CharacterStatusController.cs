using System;
using UnityEngine;

namespace Eshikivo.TopDown.Character
{
    [RequireComponent(typeof(CharacterStatComponent))]
    public class CharacterStatusController: MonoBehaviour, ICharacterAffectable
    {
        private CharacterStatComponent m_StatComponent;
        public CharacterStatComponent StatComponent => m_StatComponent;
        
        // instance
        [SerializeField] private float health;
        [SerializeField] private float exp;
        [SerializeField] private int level;
        [SerializeField] private bool isDead;

        public float Health => health;
        public float Exp => exp;
        public int Level => level;
        public bool IsDead => isDead;

        public Action OnInitialized;

        public Action OnCharacterDeath;
        public Action<int> OnCharacterLvlUp;
        public Action<float> OnCharacterDamage;
        public Action<float> OnCharacterHeal;

        private bool m_initialized = false;
        public bool Initialized => m_initialized;
        
        private void Awake()
        {
            m_StatComponent = this.GetComponent<CharacterStatComponent>();
        }

        public void Initialize(CharacterStat stat)
        {
            m_StatComponent.InitializeStat(stat);
            InitListeners();
            InitInstances();

            OnInitialized?.Invoke();
            m_initialized = true;
        }

        public void AffectHealth(float value)
        {
            if (value == 0 || isDead) return;
            bool isDamage = value < 0;

            if (isDamage)
            {
                value *= -1;
                health = health - value > 0 ? health - value : 0;

                if (health == 0)
                {
                    isDead = true;
                    OnCharacterDeath?.Invoke();
                    return;
                }

                OnCharacterDamage?.Invoke(value);
            }
            else
            {
                bool isHealed = health + value <= m_StatComponent.Stat.max_health;
                health = isHealed ? health + value : m_StatComponent.Stat.max_health;

                if (isHealed)
                {
                    OnCharacterHeal?.Invoke(value);
                }
            }
        }

        private void InitInstances()
        {
            CharacterStat stat = m_StatComponent.Stat;
            health = stat.max_health;
            exp = 0;
            level = 1;
            isDead = false;
        }

        private void InitListeners()
        {
            m_StatComponent.OnAddStat += OnAddStat;
            m_StatComponent.OnRemoveStat += OnRemoveStat;
        }

        private void OnAddStat(CharacterStat stat)
        {
        }

        private void OnRemoveStat(CharacterStat stat)
        {
            
        }
    }
}