using System;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.TopDown.Character
{
    public class CharacterStatComponent: MonoBehaviour
    {
        private CharacterStat m_addStat = new FixedStat();
        private CharacterStat m_multStat = new ProportionStat();
        
        private CharacterStat m_totalStat = new CharacterStat();
        private Dictionary<string, CharacterStat> m_statMap = new Dictionary<string, CharacterStat>();

        private bool m_initialized = false;

        public Action<CharacterStat> OnAddStat;
        public Action<CharacterStat> OnRemoveStat;
        public Action<CharacterStat> OnUpdateStat;

        public Action OnInitialized;

        public CharacterStat Stat => m_addStat * m_multStat;

        public bool Initialized => m_initialized;

        public void InitializeStat(CharacterStat stat)
        {
            m_addStat = stat;

            OnInitialized?.Invoke();
            m_initialized = true;
        }

        public void AddStat(string key, CharacterStat stat)
        {
            bool isAdded = m_statMap.TryAdd(key, stat);

            if (!isAdded)
            {
                Debug.LogWarning($"Failed to add {key}");
                return;
            }

            Type statType = stat.GetType();
            if (statType == typeof(FixedStat))
            {
                m_addStat += stat;    
            }
            else if (statType == typeof(ProportionStat))
            {
                m_multStat *= stat;
            }
            
            OnAddStat?.Invoke(stat);
            OnUpdateStat?.Invoke(Stat);
        }

        public void RemoveStat(string key, CharacterStat stat)
        {
            if (!m_statMap.TryGetValue(key, out var removedStat))
            {
                Debug.LogWarning($"Failed to find stat with key: {key}");
                return;
            }

            m_statMap.Remove(key);

            Type statType = stat.GetType();
            if (statType == typeof(FixedStat))
            {
                m_addStat -= stat;
            }
            else if (statType == typeof(ProportionStat))
            {
                m_multStat /= stat;
            }
            
            OnRemoveStat?.Invoke(stat);
            OnUpdateStat?.Invoke(Stat);
        }
    }
}