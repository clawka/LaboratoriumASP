namespace WebApp.Models;

public class Calculator
{
    public Operators? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public String Op
    {
        get
        {
            switch (Operator)
            {
                case Operators.Add:
                    return "+";
                    ...
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate() {
        switch (Operator)
        {
            case Operators.Add:
                return (double) (X + Y);
                ...
            default: return double.NaN;
        }
    }
}

enum Operators
{
    Add,
    Sub,
    Mul,
    Div
}