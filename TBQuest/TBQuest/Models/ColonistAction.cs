using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public enum ColonistAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Travel,
        ColonistInfo,
        EditColonistInfo,
        ColonistInventory,
        ColonistTreasure,
        ListLocations,
        ListItems,
        ListTreasures,
        EditName,
        EditAge,
        EditStrength,
        EditConstitution,
        EditMagic,
        EditAgility,
        EditWeaponName,
        ColonistLocationsVisited,
        ListGameObjects,
        AdminMenu,
		ObjectInteractionMenu,
        ReturnToMainMenu,
        ListNonplayerCharacters,
        NonplayerCharacterMenu,
        TalkTo,
        ColonistMenu,
        BattleMenu,
        Attack,
        RunAway,
		EquipObject,
		UnequipObject,
		EquippedItems,
		UseAbilityPoints,
        Exit
    }
}
