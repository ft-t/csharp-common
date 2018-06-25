using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ft.Common.ContractResolvers
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(Exception))
            {
                property.ShouldDeserialize = instance => false;
            }

            if (property.DeclaringType == typeof(Exception) && property.PropertyName == "TargetSite")
            {
                property.ShouldSerialize =
                    instance => false;
            }

            return property;
        }
    }
}
