// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using Dummy.Attributes;
using Newtonsoft.Json;

namespace Dummy.Dumbs.Contracts
{
    [EDummy]
    public partial class Textsoap
    {
        // NOTE: By hand ediqwe hard cap cross tree over ledge maximum text length business box (qwe max limit is 6k)
        [MaxLength(10000)]
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string CatID { get; set; }


    }
}
