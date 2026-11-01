//using System.Buffers;
//using Unity.VisualScripting;
//using UnityEngine;

//public class BankAccount
//{
//    public string owner = "";
//    private int balance = 0;

//    public BankAccount(string owner, int balance)
//    {
//        this.owner = owner;
//        this.balance = balance;
//    }

//    public void Deposit(int balance)
//    {
//        this.balance += balance;
//    }

//    public void Withdraw(int Withdraw)
//    {

//        if (balance < Withdraw)
//        {

//            Debug.Log("잔액 부족!");
//            return;

//        }
//        else
//        {
//            this.balance -= Withdraw;
//        }

//    }

//    public void ShowBalance()
//    {
//        Debug.Log("잔액 : " + balance);
//    }


//}

//public class Bank : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        BankAccount acc = new BankAccount("Miran", 1000);

//        acc.Deposit(500);
//        acc.Withdraw(300);
//        acc.Withdraw(2000);  // 잔액 부족

//        acc.ShowBalance();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
