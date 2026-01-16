using System.ComponentModel.DataAnnotations;

namespace Blog_Management_Application.ValidationAttributes
{
    public class CommentTextValidator: ValidationAttribute
    {
        private readonly HashSet<string> _blacklist;

        public CommentTextValidator() 
        { 
            _blacklist = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "spam",
                "advertisement",
                "offensive",
                "Technology"
            };
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var text = value as string;
            if(string.IsNullOrWhiteSpace(text))
            {
                return new ValidationResult.Success;
            }
            var words = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var word in words)
            {
                if (_blacklist.Contains(word))
                {
                    return new ValidationResult($"The comment contains inappropriate content: '{word}' is not allowed.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
