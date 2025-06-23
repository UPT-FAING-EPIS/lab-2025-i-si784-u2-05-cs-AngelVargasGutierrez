/// <summary>
/// Representa una cuenta bancaria con operaciones de débito y crédito.
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Mensaje de error cuando el monto a debitar excede el saldo.
    /// </summary>
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    /// <summary>
    /// Mensaje de error cuando el monto a debitar es menor que cero.
    /// </summary>
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
    /// <summary>
    /// Nombre del cliente propietario de la cuenta.
    /// </summary>
    private readonly string m_customerName;
    /// <summary>
    /// Saldo actual de la cuenta.
    /// </summary>
    private double m_balance;
    /// <summary>
    /// Constructor privado para evitar instanciación sin parámetros.
    /// </summary>
    private BankAccount() { }
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="BankAccount"/>.
    /// </summary>
    /// <param name="customerName">Nombre del cliente.</param>
    /// <param name="balance">Saldo inicial.</param>
    public BankAccount(string customerName, double balance)
    {
        m_customerName = customerName;
        m_balance = balance;
    }
    /// <summary>
    /// Obtiene el nombre del cliente.
    /// </summary>
    public string CustomerName { get { return m_customerName; } }
    /// <summary>
    /// Obtiene el saldo actual de la cuenta.
    /// </summary>
    public double Balance { get { return m_balance; }  }
    /// <summary>
    /// Debita un monto de la cuenta.
    /// </summary>
    /// <param name="amount">Monto a debitar.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es mayor al saldo o menor que cero.</exception>
    public void Debit(double amount)
    {
        if (amount > m_balance)
            throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
        m_balance -= amount; 
    }
    /// <summary>
    /// Acredita un monto a la cuenta.
    /// </summary>
    /// <param name="amount">Monto a acreditar.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si el monto es menor que cero.</exception>
    public void Credit(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount");
        m_balance += amount;
    }
} 