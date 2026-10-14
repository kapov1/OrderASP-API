using System.ComponentModel.DataAnnotations;

public class CustomerNameAttribute : ValidationAttribute
{
    private readonly string invalidChars = """ !\"#$%&'()*+,/:;<=>?@[\\]^`{|}~""";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((value is null) || (value is not string)) return ValidationResult.Success;

        string customerName = (string)value;

        foreach (char ch in invalidChars)
        {
            if (customerName.Contains(ch)) return new("The customer name contains invalid characters");
        }

        return ValidationResult.Success;
    }
}