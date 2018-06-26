using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ft.Common.ContractResolvers
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public ShouldSerializeContractResolver(NamingStrategy strategy)
        {
            NamingStrategy = strategy;
        }
        public ShouldSerializeContractResolver()
        {

        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(Exception))
            {
                property.ShouldDeserialize = instance => false;
            }

            if (property.DeclaringType == typeof(Exception) && 
                (property.PropertyName.Equals("TargetSite", StringComparison.InvariantCultureIgnoreCase) ||
                 property.PropertyName.Equals("target_site", StringComparison.InvariantCultureIgnoreCase)))
            {
                property.ShouldSerialize =
                    instance => false;
            }

            return property;
        }
    }
}
