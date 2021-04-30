using UnityEngine;

namespace MiniGames
{
    public class MazePlayerControls : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        [SerializeField] private Transform movePoint;
        
        [SerializeField] private LayerMask stopMovement;

        [SerializeField] private GameObject buttonPanel;
        
        [SerializeField] private float moveDistance;
        
        [SerializeField] private Vector3 cameraLeft = new Vector3(0,0,90);
        [SerializeField] private Vector3 cameraRight = new Vector3(0, 0, -90);

        [SerializeField] private int eulerAsInt;

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position,movePoint.position,moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position,movePoint.position) <= 0.05f)
            {
                buttonPanel.SetActive(true);
            }
        }

        public void MoveLeft()
        {
            Move(new Vector3(-1,0,0));
            transform.eulerAngles += cameraLeft;
        }

        public void MoveRight()
        {
            Move(new Vector3(1,0,0));
           transform.eulerAngles += cameraRight;
        }

        public void MoveUp() => Move(new Vector3(0,1,0));

            public void MoveDown() => Move(new Vector3(0, 1, 0));

        public void Move(Vector3 move)
        {
            if (Vector3.Distance(transform.position,movePoint.position) <= 0.05f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position+move,0.2f,stopMovement))
                {
                    buttonPanel.SetActive(false);
                    movePoint.position += move;
                }
            }
        }
    }
}
