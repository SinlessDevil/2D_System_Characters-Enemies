namespace EnemySystem.EnemyBehavior.Detection
{
    public sealed class EnemyVisibillityArea : EnemyDetection{
        private void OnTriggerEnter2D(UnityEngine.Collider2D collision){
            if (collision.gameObject.TryGetComponent(out PlayerSystem.Character character)){
                SetReferenceTarget(character);
            }
        }

     //   private void OnTriggerStay2D(UnityEngine.Collider2D collision){
     //       StateVisibility(collision);
     //   }

        private void OnTriggerExit2D(UnityEngine.Collider2D collision){
            if (collision.gameObject.TryGetComponent(out PlayerSystem.Character character)){
                 SetReferenceTarget(null);

                SetCurrentArea(true); // swipe on Derection area
            }
        }
    }
}