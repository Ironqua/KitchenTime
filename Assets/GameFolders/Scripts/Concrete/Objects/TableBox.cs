

public class TableBox : ItemBox,IPutItemFull
{
    public Table table;

    public bool canTake;


    public bool PutItem(ItemType item)
    {
            
            return    table.PutItem(item);
            
    }
}
