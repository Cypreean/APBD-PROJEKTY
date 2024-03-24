namespace cw3.Exception;

public class OverfillException : System.Exception
{ 
    public OverfillException(){}

    public OverfillException(string msg):base(msg){}
    public OverfillException(string msg, System.Exception inner) : base(msg, inner){}

}