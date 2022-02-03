class Program
{
    static void Main()
    {
        int? i = 10; // a interrogação torna o valor da classe anulável
        
        Console.WriteLine(i.GetValueOrDefault()); // esse método imprime o valor de i ou por default, caso seja nulo
        // ou não exista, será 0.
        //o valor default pode ser definido, também, pelo valor que eu inserir do método(). 


        string s = null;

    try     // por padrão o comando é executado
    {
        Console.WriteLine(s.Length);
    }
    catch (System.Exception)            //caso dê algum erro no sistema, ele pega o erro e responde com
    // uma mensagem ou comando que podemos programar. 
    {
        
        Console.WriteLine("Erro de referência Nula");    // como aqui embaixo. Ao invé sde terminar o programa de forma
        // abrupta, o programa roda uma mensagem de erro.
    }


    Console.Write("Aperte 'Enter' para entrar nos resultados dos exercícios de Banco.");
    Console.ReadLine();
    
    Ilogger logger = new FileLogger();

    BankAccount account1 = new BankAccount("Lucifer", 100, logger);
    BankAccount account2 = new BankAccount("Diabo", 9, logger);

    account1.Deposit(550); // pelo código, é para ele ignorar um "depósito negativo" e manter o mesmo saldo.
    account2.Deposit(9);

    Console.WriteLine($"Your balance is: {account1.Balance}");
    Console.WriteLine($"Your balance is: {account2.Balance}");


    }
}

class FileLogger : Ilogger
{
    public void log(string message)
    {
        File.AppendAllText("log.txt", $"{message}{Environment.NewLine}");
        // cria um aquivo .txt com os registros (logs) dos erros (como o depósito negativo). 
    }
}

class ConsoleLogger : Ilogger // como são concretos, o compilador avisa o erro. 'CTRL.' ajuda a implementar.  
{
    public void log(string message)
    {
        Console.WriteLine($"LOGGER : {message}");
    }
}


interface Ilogger // não são concretos (não pode criar instâncias dele) e por padrão, acessibilidade é pública.
// ha o costume de começar os nomes das interfaces com "I", mas não é mandatório.
{
    void log(string message);
}


class BankAccount
{
    private string name;
    private readonly Ilogger logger;

    public decimal Balance 
    { 
        get; private set;                // temos que por privado, para tirar o acesso público e
                                        // assim impedir que qualquer pessoa mude o saldo.
    

         
    }

    public BankAccount(string name, decimal balance, Ilogger logger)
     { 

        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nome Inválido.", nameof(name));
        }
        if(balance < 0)
        {
            throw new Exception("Saldo não pode ser negativo.");
        }

        this.name = name;
        Balance = balance;
        this.logger = logger;
    }

    public void Deposit(decimal amount)
    {
        if(amount <= 0) // neste caso, está sendo especificado que o depósito não pode ser nem 0 e nem negativo;
        {
            logger.log($"Não é possível depositar {amount} na conta de {name}.");
            return;
        }
        Balance += amount; // mesma coisa que balance = balance + amount;
    }


    /*public decimal GetBalance() -------- fica em comentário, pois estamos testando "prop".
    {
        return balance;
    } */

}