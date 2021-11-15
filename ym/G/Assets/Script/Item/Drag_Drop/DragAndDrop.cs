using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
{
    public Image data;
    public Item itemdata;

    public DragAndDropContainer dragAndDropContainer;

    bool isDragging = false;


    // 드래그 오브젝트에서 발생
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemdata = this.gameObject.GetComponent<Slot>().item;
        Debug.Log(this.gameObject.name + "드래그시작");
        //Debug.Log(this.gameObject.name + "이름" + this.gameObject.GetComponent<Slot>().ReturnNumber());

        if (this.gameObject.GetComponent<Image>().sprite == null)
        {
            return;
        }
        Debug.Log(this.gameObject.name + "드래그 시작 완료");

        // Activate Container
        dragAndDropContainer.gameObject.SetActive(true);

        // Set Data 
        dragAndDropContainer.image.sprite = data.sprite;//this.gameObject.GetComponent<Image>().sprite;
        dragAndDropContainer.item = itemdata;
        dragAndDropContainer.Use = this.gameObject.GetComponent<Slot>().UseSlot;
        isDragging = true;
    }
    // 드래그 오브젝트에서 발생
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + "드래그중");
        if (isDragging)
        {
            dragAndDropContainer.transform.position = eventData.position;
        }
        else
        {
            return;
        }
    }
    // 드래그 오브젝트에서 발생        마지막 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + "드래그끝");
        //Debug.Log("이름"+data.sprite.name);
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
                    Debug.Log("주는 자리에서 이벤트 발생");
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

    // 드롭 오브젝트에서 발생     //OnEndDrag보다 먼저 발생함
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name+"드롭");

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
                Debug.Log("받는 자리에서 이벤트 발생");
                this.gameObject.GetComponent<Slot>().UseAndItemChange();
            }

            // put data from drop object to Container. 
            dragAndDropContainer.image.sprite = tempSprite;
            dragAndDropContainer.item = tempitem;
            dragAndDropContainer.Use = this.gameObject.GetComponent<Slot>().UseSlot;
        }
        else
        {
            Debug.Log("아무것도 가지고  있지 않아");
            dragAndDropContainer.image.sprite = null;
            dragAndDropContainer.item = null;
        }
    }

    public void ChangeSlotNumber()
    {
        
    }
}