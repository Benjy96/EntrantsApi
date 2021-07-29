/** 

This model is the "public" version of the Entrant model.

It contains fewer attributes than the "Entrant" model. Why?

- Hide things from client
- Reduce size of data transfer

*/

public class EntrantDTO 
{
    public long id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
}