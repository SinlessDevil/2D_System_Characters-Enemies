namespace EnemySystem.EnemyBehavior.Detection
{
    public sealed class EnemyTriggerDetectionArea : EnemyDetection{
        private void OnTriggerEnter2D(UnityEngine.Collider2D collision){
            if(collision.gameObject.TryGetComponent(out PlayerSystem.Character character)){
                SetReferenceTarget(character);

                SetCurrentArea(false); // swipe on Visibility area
            }
        }
    }
}