using System;

class HammingChecker {
    public static bool Check(string code) {
        // Determine the number of parity bits needed.
        int n = code.Length;
        int k = 1;
        while (Math.Pow(2, k) < n + k + 1) {
            k++;
        }
        
        // Initialize the parity bit positions.
        int[] parityPositions = new int[k];
        for (int i = 0; i < k; i++) {
            parityPositions[i] = (int) Math.Pow(2, i) - 1;
        }
        
        // Compute the parity bits.
        int[] parityBits = new int[k];
        for (int i = 0; i < k; i++) {
            int mask = 1 << i;
            for (int j = 0; j < n; j++) {
                if ((j & mask) != 0) {
                    parityBits[i] ^= code[j] - '0';
                }
            }
        }
        
        // Check if the parity bits match.
        int errorPosition = 0;
        for (int i = 0; i < k; i++) {
            if (parityBits[i] != 0) {
                errorPosition += parityPositions[i];
            }
        }
        if (errorPosition > 0) {
            Console.WriteLine("Error detected at position " + errorPosition + ".");
            return false;
        }
        
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        // Example usage.
        string code = "1011100110011110";
        Console.WriteLine("Code: " + code);
        bool result = HammingChecker.Check(code);
        Console.WriteLine("Result: " + result);
    }
}
