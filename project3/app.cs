using System;

class Program {
    static bool IsValid(string cardNumber) {
        int sum = 0;
        bool isSecondDigit = false;
        for (int i = cardNumber.Length - 1; i >= 0; i--) {
            if (cardNumber[i] < '0' || cardNumber[i] > '9') {
                // Invalid character, return false
                return false;
            }
            int digit = cardNumber[i] - '0';
            if (isSecondDigit) {
                digit *= 2;
                if (digit > 9) {
                    digit -= 9;
                }
            }
            sum += digit;
            isSecondDigit = !isSecondDigit;
        }
        return sum % 10 == 0;
    }
    
    static string GetCardType(string cardNumber) {
        if (cardNumber.Length == 15 && (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"))) {
            return "American Express";
        } else if (cardNumber.Length == 16 && (cardNumber.StartsWith("51") || cardNumber.StartsWith("52") || cardNumber.StartsWith("53") || cardNumber.StartsWith("54") || cardNumber.StartsWith("55"))) {
            return "MasterCard";
        } else if ((cardNumber.Length == 13 || cardNumber.Length == 16) && cardNumber.StartsWith("4")) {
            return "Visa";
        } else {
            return "Unknown";
        }
    }

    static void Main() {
        Console.Write("Enter credit card number: ");
        string cardNumber = Console.ReadLine();
        if (IsValid(cardNumber)) {
            Console.WriteLine("Valid credit card number!");
            Console.WriteLine($"Card type: {GetCardType(cardNumber)}");
        } else {
            Console.WriteLine("Invalid credit card number!");
        }
    }
}
