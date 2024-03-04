using static System.Net.Mime.MediaTypeNames;

namespace ZI4Lab
{
    internal class Program
    {
        public class CeasarCipher
        {
            private static string _defaultAlphabet = "abcdefghijklmnopqrstuvwxyz";
            private string _alphabet = "";
            private const int _key = 2;

            public CeasarCipher(string alphabet = null)
            {
                _alphabet = string.IsNullOrEmpty(alphabet) ? _defaultAlphabet : alphabet;
            }

            private string Encrypt(string originalMessage, int key)
            {
                originalMessage = originalMessage.ToLower();
                char[] encryptedText = new char[originalMessage.Length];

                for (int i = 0; i < originalMessage.Length; i++)
                {
                    char currentChar = originalMessage[i];
                    int position = _alphabet.IndexOf(currentChar);

                    if (position >= 0)
                    {
                        int newPosition = (position + key + _alphabet.Length) % _alphabet.Length;
                        encryptedText[i] = _alphabet[newPosition];
                    }
                    else
                    {
                        encryptedText[i] = currentChar;
                    }
                }

                return new string(encryptedText);
            }

            public string Encrypt(string originalMessage)
            {
                return Encrypt(originalMessage, _key);
            }
            public string Decrypt(string originalMessage)
            {
                return Encrypt(originalMessage, -_key);
            }

        }


        static void Main(string[] args)
        {
            var russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var ceasar = new CeasarCipher(russianAlphabet);



            Console.Write("Введите текст для шифрования: ");
            string text = Console.ReadLine();
            
            string encryptedText = ceasar.Encrypt(text);
            string decryptedText = ceasar.Decrypt(encryptedText);

            Console.WriteLine("Зашифрованный текст: ");
            Console.WriteLine(encryptedText);

            Console.WriteLine("\nРасшифрованный текст: ");
            Console.WriteLine(decryptedText);

        }
    }
}