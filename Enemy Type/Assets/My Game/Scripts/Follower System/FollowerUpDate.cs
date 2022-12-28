namespace FollowerSystem
{
    public sealed class FollowerUpDate : Follower
    {
        private void Update()
        {
            MoveTo(UnityEngine.Time.deltaTime);
        }
    }
}