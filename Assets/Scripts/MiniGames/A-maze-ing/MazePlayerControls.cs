using UnityEngine;

namespace MiniGames
{
    public class MazePlayerControls : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        //[SerializeField] private float rotateSpeed;
        [SerializeField] private Transform movePoint;
        
        [SerializeField] private LayerMask stopMovement;

        [SerializeField] private GameObject buttonPanel;

        //[SerializeField] private Camera mainCamera;
        
      //  [SerializeField] private Quaternion leftRotate;
        //[SerializeField] private Quaternion rightRotate;
        //[SerializeField] private Quaternion upRotate;

        //[SerializeField] private int whichRotatePosition; //0 facing up, 1 facing left, 2 facing right
        [SerializeField] private float moveDistance;
        [SerializeField] private Vector3 moveUpValue;
        [SerializeField] private Vector3 moveLeftValue;
        [SerializeField] private Vector3 moveRightValue;

        //[SerializeField] private Vector3 cameraUp = new Vector3(0,0,0);
        [SerializeField] private Vector3 cameraLeft = new Vector3(0,0,90);
        [SerializeField] private Vector3 cameraRight = new Vector3(0, 0, -90);

        [SerializeField] private int eulerAsInt;

        private void FixedUpdate()
        {
            eulerAsInt = Mathf.FloorToInt(transform.eulerAngles.z);
            print(transform.eulerAngles.z);
            transform.position = Vector3.MoveTowards(transform.position,movePoint.position,moveSpeed * Time.deltaTime);
            var transformEulerAngles = transform.eulerAngles;
            if (transformEulerAngles.z >= 360f)
            {
                transformEulerAngles.z -= 360f;
            }
            else if (transformEulerAngles.z < 0f)
            {
                transformEulerAngles.z += 360f;
            }
            switch (eulerAsInt)
            {
                case 0:
                    moveUpValue = new Vector3(0, moveDistance,0);
                    moveLeftValue = new Vector3(-moveDistance, 0,0);
                    moveRightValue = new Vector3(moveDistance, 0,0);
                    //mainCamera.transform.eulerAngles += cameraUp;
                    break;
                case 90:
                    moveUpValue = new Vector3(-moveDistance,0,0);
                    moveLeftValue = new Vector3(0,-moveDistance,0);
                    moveRightValue = new Vector3(0,moveDistance,0);
                    break;
                case 180:
                    moveUpValue = new Vector3(0,-moveDistance, 0);
                    moveLeftValue = new Vector3(moveDistance,0,0);
                    moveRightValue = new Vector3(-moveDistance, 0,0);
                    break;
                case 270:
                    moveUpValue = new Vector3(moveDistance, 0, 0);
                    moveLeftValue = new Vector3(0,moveDistance,0);
                    moveRightValue = new Vector3(0,-moveDistance,0);
                    break;
                default:
                    print("fuck");
                    break;
            }

            if (Vector3.Distance(transform.position,movePoint.position) <= 0.05f)
            {
                buttonPanel.SetActive(true);
            }
        }

        public void MoveLeft()
        {
           // transform.rotation = Quaternion.RotateTowards(transform.rotation,leftRotate, rotateSpeed * Time.deltaTime);
           Move(moveLeftValue);
           //whichRotatePosition = 1;
           //mainCamera.transform.eulerAngles += cameraLeft;
           transform.eulerAngles += cameraLeft;
        }

        public void MoveRight()
        {
           // transform.rotation = Quaternion.RotateTowards(transform.rotation,rightRotate, rotateSpeed * Time.deltaTime);
           Move(moveRightValue);
           //whichRotatePosition = 2;
           //mainCamera.transform.eulerAngles += cameraRight;
           transform.eulerAngles += cameraRight;
        }

        public void MoveUp()
        {
            //  transform.rotation = Quaternion.RotateTowards(transform.rotation,upRotate, rotateSpeed * Time.deltaTime);
          Move(moveUpValue);
          //whichRotatePosition = 0;
        }

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
