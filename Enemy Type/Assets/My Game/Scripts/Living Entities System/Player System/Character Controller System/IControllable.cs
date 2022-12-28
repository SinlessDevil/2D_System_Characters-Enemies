namespace PlayerSystem.CharacterControllerSystem
{
    public interface IControllable
    {
        void MoveTo(float direction);

        bool IsJumping { get; set; }
        bool IsGound { get; }
        void Jump();
    }
}