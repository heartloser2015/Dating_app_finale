namespace Dating_app_final.Shared.Domin
{
    public class BlockedUser
    {
        public int Id { get; set; }

        public string BUser_Cause { get; set; }
        public virtual User User { get; set; }
    }
}
