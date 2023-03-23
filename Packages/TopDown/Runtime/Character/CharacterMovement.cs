using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eshikivo.TopDown.Character
{
    public abstract class CharacterMovement: CharacterComponent
    {
        protected Vector2 m_movement; 
        
        public abstract IEnumerator MoveCo();
    }
}