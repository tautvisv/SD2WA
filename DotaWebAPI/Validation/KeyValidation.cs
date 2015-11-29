namespace Validation
{
    public class KeyValidation : IKeyValidation
    {
        public KeyValidation()
        {
            
        }
        public bool IsValid(string key)
        {
            return !string.IsNullOrEmpty(key);
        }
    }
}
