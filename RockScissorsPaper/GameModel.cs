public class GameModel
{
    private readonly string[] choices = { "Камень", "Ножницы", "Бумага" };
    private readonly Random random = new();

    public string GetComputerChoice()
    {
        return choices[random.Next(choices.Length)];
    }

    public string DetermineWinner(string playerChoice, string computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return "Ничья!";
        }

        if ((playerChoice == "Камень" && computerChoice == "Ножницы") ||
            (playerChoice == "Ножницы" && computerChoice == "Бумага") ||
            (playerChoice == "Бумага" && computerChoice == "Камень"))
        {
            return "Вы победили!";
        }

        return "Вы проиграли!";
    }
}
