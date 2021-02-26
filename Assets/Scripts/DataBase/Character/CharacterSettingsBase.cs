using UnityEngine;

namespace DataBase.Character
{
    [CreateAssetMenu(menuName = "Settings/CharacterSettingsBase", fileName = "CharacterSettingsBase")]
    public class CharacterSettingsBase : ScriptableObject, ICharacterSettingsBase
    {
        [SerializeField] private CharacterSettings characterSettings;

        public CharacterSettings CharacterSettings => characterSettings;
    }
}