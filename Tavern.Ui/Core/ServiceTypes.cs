using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tavern.Services.Characters;

namespace Tavern.Ui.Core
{
    public class ServiceTypes
    {
        public static IReadOnlyList<TypeInfo> Types => new List<TypeInfo>()
        {
            typeof(CharacterService).GetTypeInfo(),
            //typeof(WidgetService).GetTypeInfo(),
            //typeof(SprocketService).GetTypeInfo(),
        };
    }
}
