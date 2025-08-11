//using DesingPattern.DependencyInjection;
using DesingPattern.Builder;
using DesingPattern.Factory;
using DesingPattern.Models;
using DesingPattern.Repository;
using DesingPattern.Singleton;
using DesingPattern.Strategy;
using DesingPattern.UnitOfWork;

// Implementacion del patron de diseño Singleton
//var singleton = Singleton.Instance;
//Console.WriteLine(singleton);

//var log = Log.Instance;

//log.Save("Hola");
//log.Save("En Singleton");

//var a = Log.Instance;
//var b = Log.Instance;

//Console.WriteLine(a == b);
//----------------------------------------------//


// Implementacion del patron de diseño Factory Method

////--------- INICIALIZACION DE LAS FABRICAS ---------//
//SaleFactory storeSale = new StoreSaleFactory(10);
//SaleFactory internetSale = new InternetSaleFactory(2);

////-------- CREACION DE LOS PRODUCTOS -------------//
//ISale sale1 = storeSale.GetSale();
//sale1.Sell(15);
//ISale sale2 = internetSale.GetSale();
//sale2.Sell(15);

//---------------------------------------------------//


// Implementacion del pantron de diseño de Inyeccion de dependencia

//var beer = new Beer("Pikantus", "Erdinger");
//var drinkWithBeer = new DrinkWithBeer(10, 1, beer);
//drinkWithBeer.Build();

//----------------------------------------------------//

//--------- PRIMER EJEMPLO DE USO DEL PATRON REPOSITORY ----------//
//using (var context = new DesignPatternsContext()) { 

//    var beerRepository = new BeerRepository(context);
//    var beer = new Beer();

//    beer.Name = "Victoria Clasica";
//    beer.Style = "Lata";

//    beerRepository.Add(beer);
//    beerRepository.Save();

//    foreach(var item in beerRepository.Get())
//    {
//        Console.WriteLine(item.Name);
//    }
//}

//-------- SEGUNDO EJEMPLO DEL USO DEL PATRON REPOSITORY ---------//
//using(var context = new DesignPatternsContext())
//{

//    var beerRepository = new Repository<Beer>(context);
//    beerRepository.Delete(5);
//    beerRepository.Save();

//    foreach (var item in beerRepository.Get())
//    {
//        Console.WriteLine($" {item.BeerId} - {item.Name}");
//    }

//    var brandRepository = new Repository<Brand>(context);
//    var brand = new Brand() { Name = "Fuller" };

//    brandRepository.Add(brand);
//    brandRepository.Save();

//    foreach (var item in brandRepository.Get())
//    {
//        Console.WriteLine($" {item.BranId} - {item.Name}");
//    }
//}

//-------- EJEMPLO DEL USO DEL PATRON UNITOFWORK ---------//
//using (var context = new DesignPatternsContext())
//{

//    var unitOfWork = new UnitOfWork(context);
//    var beers = unitOfWork.Beers;

//    var idBrand = Guid.NewGuid();

//    var beer = new Beer()
//    {
//        Name = "Fuller 2",
//        Style = "Potter 2",
//        BrandId = idBrand,//Guid.Parse("009238f2-1dc1-45ab-a6e7-720128d648dd"),
//    };

//    beers.Add(beer);

//    var brands = unitOfWork.Brands;
//    var brand = new Brand()
//    {
//        BrandId = idBrand,
//        Name = "Fuller 2"
//    };

//    brands.Add(brand);
//    unitOfWork.Save();
//}

//-------- EJEMPLO DEL USO DEL PATRON STRATEGY ---------//

//var context = new Context(new CarStrategy());
//context.Run();
//context.Strategy = new MotoStrategy();
//context.Run();
//context.Strategy = new BicycleStrategy();
//context.Run();

//-------- EJEMPLO DEL USO DEL PATRON BUILDER ---------//

var builder = new PreparedAlcoholicDrinkConcreteBuilder();
var barmandirector = new BarmanDirector(builder);

Console.WriteLine("//----- MARGARITA -----//");
barmandirector.PreparedMargarita(); // LA RECETA MARGARITA

var preparedDrink = builder.GetPreparedDrink();
Console.WriteLine(preparedDrink.Result);

Console.WriteLine("//----- PIÑA COLADA -----//");
barmandirector.PreparedPinaColada(); // LA RECETA PIÑA COLADDA

preparedDrink = builder.GetPreparedDrink();
Console.WriteLine(preparedDrink.Result);

Console.ReadLine();