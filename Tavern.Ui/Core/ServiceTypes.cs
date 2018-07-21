using System.Collections.Generic;
using System.Reflection;
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
