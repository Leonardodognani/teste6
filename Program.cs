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

    
    BankAccount account1 = new BankAccount();
    account1.name = "Leonardo";
    account1.balance = 500;

    BankAccount account2 = new BankAccount();

    }
}
class BankAccount
{
    private string name;
    private decimal balance;


    public BankAccount(string name, decimal balance);
     { 
                this.name = name;
                this.balance = balance;


    }

}