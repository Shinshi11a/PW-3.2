public class SmsMessage
{
    private const int MaxLength = 250;
    private const int MaxTaxedLength = 65;
    private const decimal BasePrice = 1.5m;
    private const decimal TaxPrice = 0.5m;

    private string messageText;
    private decimal price;

    public SmsMessage(string messageText)
    {
        MessageText = messageText;
        Price = CalculatePrice(messageText);
    }

    public string MessageText
    {
        get { return messageText; }
        set { messageText = value.Substring(0, Math.Min(value.Length, MaxLength)); }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public static SmsMessage CreateFromUserInput()
    {
        Console.WriteLine("Введите текст сообщения:");
        string messageText = Console.ReadLine();
        return new SmsMessage(messageText);
    }

    private static decimal CalculatePrice(string messageText)
    {
        int length = Math.Min(messageText.Length, MaxLength);
        decimal price = BasePrice;

        if (length > MaxTaxedLength)
        {
            int taxedLength = length - MaxTaxedLength;
            price += taxedLength * TaxPrice;
        }

        return price;
    }
}