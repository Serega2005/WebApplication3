namespace  WebApplication3;

public class Catalog
{
    public string GetProducts(string? userAgent)
    {
        double multiplier = 1;
        DateTime date = DateTime.Now;
        string curDate = date.ToShortDateString();
        
        if (date.DayOfWeek == DayOfWeek.Wednesday)
        {
            //  Наценка 50% в среду
            multiplier *= 1.5;
        }

        switch (userAgent)
        {
            case "Android":
                //  Скидка 10%
                multiplier *= 0.9;
                break;
            case "iPhone":
                //  Наценка 50%
                multiplier *= 1.5;
                break;
        }
        
        return multiplier.ToString();
    }
}