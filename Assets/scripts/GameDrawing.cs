using UnityEngine;

public class GameDrawing : MonoBehaviour
{

    [SerializeField] float zBuffer = 1;  //����Z�l
    float baseSize; //�\���T�C�Y
    public float nearSize;
    public float farSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (farSize < zBuffer)
            {
                zBuffer -= 0.1f;
                transform.position += new Vector3(0, 0.05f, 0); // Y�������Ɉړ�
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (nearSize > zBuffer)
            {
                zBuffer += 0.1f;
                transform.position -= new Vector3(0, 0.05f, 0); // Y�������Ɉړ�
            }
        }

        baseSize = zBuffer; 

        transform.localScale = new Vector3(baseSize, baseSize, baseSize);

    }

    
}
