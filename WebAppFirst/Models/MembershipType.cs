namespace WebAppFirst.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }
        public static readonly byte Unkown = 0;
        public static readonly byte Boier = 1;
        public static readonly byte Starter_PACK = 2;
        public static readonly byte Medium_PACK = 3;
        public static readonly byte Milioner = 4;
    }
}
