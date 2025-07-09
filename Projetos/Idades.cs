using System;
class Principal
{
    static void Main()
    {
        Console.WriteLine("Digite sua idade:");
        int idade = int.Parse(Console.ReadLine());

        if (idade >= 0 && idade <= 12)
        {
            Console.WriteLine("Você é uma criança");
        }
        else if (idade >= 13 && idade <= 18)
        {
            Console.WriteLine("Você é um adolescente");
        }
        else if (idade >= 19 && idade <= 65)
        {
            Console.WriteLine("Você é um adulto");
        }
        else
        {
            Console.WriteLi
            ne("Você é um idoso");
        }
    }
}
