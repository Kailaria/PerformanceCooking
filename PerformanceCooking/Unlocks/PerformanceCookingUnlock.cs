using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using Unity.Entities;
using KitchenPerformanceCooking;

namespace KitchenPerformanceCooking.Unlocks
{
    public class PerformanceCookingUnlock : CustomUnlockCard
    {
        //private EntityQuery Tables, Hobs, Ovens, ActiveAppliances, Players;

        public override string UniqueNameID => "Kailaria.PlateUp.PerforamanceCooking:Unlock";

        public override bool IsUnlockable => true;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Generic;
        public override CardType CardType => CardType.Default;

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo(
                name: "Performance Cooking", 
                description: "<b>Bring the heat!</b>\n" +
                    $"40% less {References.SPRITE_PATIENCE_SERVICE} and {References.SPRITE_PATIENCE_WAITFORFOOD}.\n" +
                    $"Hobs instead give 20% *more* {References.SPRITE_PATIENCE_WAITFORFOOD} when placed near tables.\n" +
                    "<b>Entertain us!</b>\n" +
                    "Patience decreases slower when customers look at players.\n" +
                    $"Patience decreases much slower when customers see players and nearby appliances are actively {References.SPRITE_PROCESS_CHOP} {References.SPRITE_PROCESS_KNEAD} {References.SPRITE_PROCESS_COOK} or {References.SPRITE_PROCESS_BREW}.", 
                flavourText: "")
                    //"Customer: \"The volcano is erupting!\"\n" +
                    //"Hibachi/Teppanyaki cook: \"That's just a tower of onions. ;P\"")
            )
        };

        public override List<Unlock> HardcodedBlockers => new List<Unlock>()
        {
            (Unlock) GDOUtils.GetExistingGDO(UnlockCardReferences.LosePatienceInView) // Locale.English = "Victorian Standards"
        };

        //TODO: Add RestaurantStatus for the systems to recognize whether to actually run the update fully.

        public override List<UnlockEffect> Effects => new List<UnlockEffect>()
        {
            //new GlobalEffect()
            //{
            //    EffectCondition = new CEffectAlways(),
            //    EffectType = new CTableModifier
            //    {
            //        PatienceModifiers = new()
            //        {
            //            WaitForFood = -0.4f
            //        }
            //    }
            //},
            new StatusEffect()
            {
                Status = PERFORMANCE_COOKING_STATUS
            }
        };
    }
}
