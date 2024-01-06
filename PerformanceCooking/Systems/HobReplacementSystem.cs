using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using KitchenPerformanceCooking;
using Unity.Entities;

namespace KitchenPerformanceCooking.Systems
{
    public class HobReplacementSystem : GenericSystemBase
    {
        private EntityQuery Hobs;
        private EntityQuery SafetyHobs;
        private EntityQuery StarterHobs;
        private EntityQuery BurnerHobs;

        protected override void Initialise()
        {
            base.Initialise();
            Hobs = GetEntityQuery(new QueryHelper()
                        .All(typeof(CAppliance), typeof(CPosition), typeof(CAppliesEffect),
                            typeof(CItemHolder), typeof(CCausesSpills))
                        .None(typeof(CPerformanceModeCooker))
                    );
        }

        // TODO: testing purposes only - Create PrefManager preference that toggles hob's WaitForFood modifier
        // TODO: [2023-11-10] Ignore above, just make a new set of appliances: flat-top hobs (starter, regular, safety, danger)
        //      and then replace all existing with the appropriate version.
        //Appliance hob = GDOUtils.GetExistingGDO(ApplianceReferences.Hob) as Appliance;
        //hob.EffectType = new CTableModifier
        //{
        //    PatienceModifiers = new PatienceValues
        //    {
        //        WaitForFood = 0.2f
        //    }
        //};
        protected override void OnUpdate()
        {
            //if (GetSingleton<SGlobalStatusList>().Has(References.PERFORMANCE_COOKING_STATUS))
            //{

            //}
        }
    }
}
