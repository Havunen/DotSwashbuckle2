// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using Dummy.Attributes;
using Newtonsoft.Json;

namespace Dummy.Dumbs.Contracts
{
    [EDummy]
    public partial class Reasonsoap
    {
        /// <summary>
        /// XX-200-soap
        /// XX-200-soap-shake
        /// XX-140-dummy (Forbidden)
        /// XX-140-dummy-shake
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public rubysoap Reasonruby { get; set; }

        /// <summary>
        /// XX-200-soap
        /// XX-200-soap-Cat
        /// XX-762-dummy (Forbidden)
        /// XX-762-dummy-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> ReasonDescription { get; set; }


    }
}
