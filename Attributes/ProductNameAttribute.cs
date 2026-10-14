using System.ComponentModel.DataAnnotations;

public class ProductNameAttribute : ValidationAttribute
{
    private readonly string invalidChars = """!\"#$&'()*+,/:;<=>?@[\\]^`{|}~""";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((value is null) || (value is not string)) return ValidationResult.Success;

        string productName = (string)value;

        foreach (char ch in invalidChars)
        {
            if (productName.Contains(ch)) return new("The product name contains invalid characters");
        }

        return ValidationResult.Success;
    }
}