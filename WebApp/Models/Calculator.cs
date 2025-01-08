namespace WebApp.Models;

public class Calculator
{
    public Operators? op { get; set; }
    public double? A { get; set; }
    public double? B { get; set; }

    public String Op
    {
        get
        {
            switch (op)
            {
                case Operators.add:
                    return "+";
                case Operators.sub:
                    return "-";
                case Operators.div:
                    return "/";
                case Operators.mul:
                    return "*";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return op != null && A != null && B != null;
    }

    public double Calculate() {
        switch (op)
        {
            case Operators.add:
                return (double) (A + B);
            case Operators.sub:
                return (double)(A - B);
            case Operators.mul:
                return (double) (A * B);
            case Operators.div:
                if (B != 0)
                {
                    return (double)(A - B);
                }
                else
                {
                    return 0;
                }

            default: return double.NaN;
        }
    }
}
public enum Operators
{
    add, sub, mul, div
}