using ProtoBuf;

namespace Apress.Recipes.WebApi
{
    [ProtoContract]
    public class Item
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}