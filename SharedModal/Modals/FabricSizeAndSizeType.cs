using SharedModal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModal.Modals
{
    public class Fabric
    {
        public List<string> AllFabric { get; set; }

        public Fabric()
        {
            List<string> fabricName = new List<string>()
            {
                 FabricEnum.FabricType.Wool.ToString(),
                 FabricEnum.FabricType.Velvet.ToString(),
                 FabricEnum.FabricType.Silk.ToString(),
                 FabricEnum.FabricType.Rayon.ToString(),
                 FabricEnum.FabricType.Polyester.ToString(),
                 FabricEnum.FabricType.Nylon.ToString(),
                 FabricEnum.FabricType.Linen.ToString(),
                 FabricEnum.FabricType.Leather.ToString(),
                 FabricEnum.FabricType.Cotton.ToString(),
                 FabricEnum.FabricType.Denim.ToString()
            };
            AllFabric = fabricName;
        }
    }
}
