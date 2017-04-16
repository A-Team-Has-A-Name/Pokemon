
namespace Pokemon.Client.Interfaces
{
    public interface IFacingDirection
    {
        bool IsFacingLeft { get; set; }
        bool IsFacingRight { get; set; }
        bool IsFacingUp { get; set; }
        bool IsFacingDown { get; set; }
    }
}
