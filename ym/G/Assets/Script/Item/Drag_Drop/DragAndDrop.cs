using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
{
    public Image data;
    public Item itemdata;

    public DragAndDropContainer dragAndDropContainer;

    bool isDragging = false;


    // �巡�� ������Ʈ���� �߻�
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemdata = this.gameObject.GetComponent<Slot>().item;
        Debug.Log(this.gameObject.name + "�巡�׽���");
        //Debug.Log(this.gameObject.name + "�̸�" + this.gameObject.GetComponent<Slot>().ReturnNumber());

        if (this.gameObject.GetComponent<Image>().sprite == null)
        {
            return;
        }
        Debug.Log(this.gameObject.name + "�巡�� ���� �Ϸ�");

        // Activate Container
        dragAndDropContainer.gameObject.SetActive(true);

        // Set Data 
        dragAndDropContainer.image.sprite = data.sprite;//this.gameObject.GetComponent<Image>().sprite;
        dragAndDropContainer.item = itemdata;
        dragAndDropContainer.Use = this.gameObject.GetComponent<Slot>().UseSlot;
        isDragging = true;
    }
    // �巡�� ������Ʈ���� �߻�
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + "�巡����");
        if (isDragging)
        {
            dragAndDropContainer.transform.position = eventData.position;
        }
        else
        {
            return;
        }
    }
    // �巡�� ������Ʈ���� �߻�        ������ �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + "�巡�׳�");
        //Debug.Log("�̸�"+data.sprite.name);
        if (isDragging)
        {
            if (dragAndDropContainer.image.sprite != null)
            {
                // set data from dropped object  
                data.sprite = dragAndDropContainer.image.sprite;
                this.gameObject.GetComponent<Slot>().item = dragAndDropContainer.item;

                this.gameObject.GetComponent<Slot>().ChangeItem();
                if (this.gameObject.GetComponent<Slot>().UseSlot ^ dragAndDropContainer.Use)
                {
                    Debug.Log("�ִ� �ڸ����� �̺�Ʈ �߻�");
                    this.gameObject.GetComponent<Slot>().UseAndItemChange();
                }

            }
            else
            {
                // Clear Data
                data.sprite = null;
                this.gameObject.GetComponent<Slot>().item = null;
                itemdata = null;
            }
        }

        isDragging = false;
        // Reset Contatiner
        itemdata = null;
        dragAndDropContainer.image.sprite = null;
        dragAndDropContainer.item = null;
        dragAndDropContainer.gameObject.SetActive(false);
        dragAndDropContainer.Use = false;
        
    }


    //--------------------------------------------------------------------------------

    // ��� ������Ʈ���� �߻�     //OnEndDrag���� ���� �߻���
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name+"���");

        if (dragAndDropContainer.image.sprite != null)
        {
            // keep data instance for swap 
            Sprite tempSprite = data.sprite;
            Item tempitem = this.gameObject.GetComponent<Slot>().item;


            // set data from drag object on Container
            data.sprite = dragAndDropContainer.image.sprite;
            this.gameObject.GetComponent<Slot>().item = dragAndDropContainer.item;
            this.gameObject.GetComponent<Slot>().ChangeItem();

            if (this.gameObject.GetComponent<Slot>().UseSlot^dragAndDropContainer.Use)
            {
                Debug.Log("�޴� �ڸ����� �̺�Ʈ �߻�");
                this.gameObject.GetComponent<Slot>().UseAndItemChange();
            }

            // put data from drop object to Container. 
            dragAndDropContainer.image.sprite = tempSprite;
            dragAndDropContainer.item = tempitem;
            dragAndDropContainer.Use = this.gameObject.GetComponent<Slot>().UseSlot;
        }
        else
        {
            Debug.Log("�ƹ��͵� ������  ���� �ʾ�");
            dragAndDropContainer.image.sprite = null;
            dragAndDropContainer.item = null;
        }
    }

    public void ChangeSlotNumber()
    {
        
    }
}