namespace Reflector.Core.Describing.Models
{
    public class MemberDescription
    {
        public int Id { get; }

        public string MemberName { get; }

        public MemberDescription(int id, string memberName)
        {
            Id = id;
            MemberName = memberName;
        }
    }
}