using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");



IMenuItem m1 = new MenuItem("Svampebob", 129, "Ost, tomat, skinke, spids nøgenhat, champingoner, carl-johan", MenuType.PIZZASPECIALI);
ICustomer c1= new Customer("Poul","31231","Gade 123 Roskilde"); 


c1.ClubMember = true; 
Console.WriteLine(c1.ToString());

CustomerRepository cusRepo = new CustomerRepository();
MenuItemRepository menRepo = new MenuItemRepository();


menRepo.AddMenuItem(m1);
cusRepo.AddCustomer(c1);

Console.WriteLine(menRepo.Count);
Console.WriteLine(cusRepo.Count);

menRepo.PrintAllMenuItems();
cusRepo.PrintAllCustomers();


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


foreach (ICustomer member in cusRepo.GetMemberList())                     //test af member list. 
{
    Console.WriteLine("Medlem : " + member.ToString()); 
}



foreach (ICustomer person in cusRepo.GetFromRoskilde())                     //test af folk fra roskilde list. 
{ 
    Console.WriteLine("Person fra Roskilde : "+person.ToString());
}

foreach (IMenuItem item in menRepo.GetAllByType(MenuType.PIZZECLASSSICHE))      //test af liste med given menu type. 
{
    Console.WriteLine("Pizza klassisk : " + item.ToString());
}

Console.WriteLine("Den mest dyre genstand : " + menRepo.GetPriciest().ToString());                           //test af søgning efter den mest dyre. 


IMenuItem m2 = new MenuItem("Super club sandwich", 139, "luksus sandwich med grillet ost, kylling, hjemmelavet karry og brød", MenuType.SANDWICHES);
menRepo.AddMenuItem(m2);

Console.WriteLine("Den mest dyre pizza : " + menRepo.GetPriciestPizza().ToString());                       //test af søgning efter den mest dyre pizza. Super club sandwich bliver ikke fundet. 



menRepo.PrintMenu();                //test af menu

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

VIPCustomer vC1 = new VIPCustomer("Thor", "242424", "Rosmaringade 2");
cusRepo.AddCustomer(vC1);
vC1.SetDiscountForVip(15); //tester vip customer med discount rate

//vil det være en god ide at lave klassen customer til abstrakt?

cusRepo.PrintAllCustomers();


CarryContainer cM1 = new CarryContainer("æske",true,ContainerSize.LARGE );

Console.WriteLine(cM1.ToString()); //tester bag objekt


ICustomer cTest = new Customer("sanne", "12121212", "vej2"); //Test person med samme mobil som en i mockdata
try
{
    cusRepo.AddCustomer(cTest);
}
catch (CustomerMobileNumberExist CME)
{
    Console.WriteLine(CME.Message); //fanger exception og skriver beskeden til console
}

//test af singleton
//new CompanyInfo() //virker ikke, private constructor

CompanyInfo i1 = CompanyInfo.GetInstance;
CompanyInfo i2 = CompanyInfo.GetInstance;
Console.WriteLine(i1.Equals(i2)); //returnerer true, hvilke vil sige at objektreferencerne peger på den samme instans


