namespace FollowerSystem
{
    public sealed class FollowerFixedUpdate : Follower
    {
        private void FixedUpdate()
        {
            MoveTo(UnityEngine.Time.fixedDeltaTime);
        }
    }
}