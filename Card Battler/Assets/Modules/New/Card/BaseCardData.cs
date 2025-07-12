using System;
using UnityEngine;

namespace Modules.New
{
    [Serializable]
    public abstract class BaseCardData : ScriptableObject
    {
        [field: SerializeField] public int ManaAmount { get; private set; }  
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
    }
}